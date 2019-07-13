using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using NashTechAdsAPI.Data;
using NashTechAdsAPI.Models;
using NashTechAdsAPI.Services;
using NashTechAdsAPI.ViewModels;

namespace NashTechAdsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdsController : ControllerBase
    {
        private readonly AdsDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IQueueService _queueService;

        public AdsController(AdsDbContext context, IStorageService storageService, IQueueService queueService)
        {
            _context = context;
            _storageService = storageService;
            _queueService = queueService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AdView>>> GetAds()
        {
            var ads = (await _context.Ads.Include(x => x.Category).OrderByDescending(x => x.PostedDate)
                .ToListAsync()).Select(ad => new AdView
            {
                Id = ad.Id,
                Title = ad.Title,
                Price = ad.Price,
                Description = ad.Description,
                CategoryId = ad.CategoryId,
                CategoryName = ad.Category.Name,
                PostedDate = ad.PostedDate,
                CreatedBy = ad.CreatedBy,
                Status = ad.Status.ToString(),
                ThumbnailUrl = _storageService.GetMediaUrl(ad.Thumbnail),
            });

            return Ok(ads);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AdView>> GetAd(int id)
        {
            var ad = await _context.Ads.FindAsync(id);

            if (ad == null)
            {
                return NotFound();
            }

            var adView = new AdView
            {
                Id = ad.Id,
                Title = ad.Title,
                Price = ad.Price,
                Description = ad.Description,
                PostedDate = ad.PostedDate,
                ThumbnailUrl = _storageService.GetMediaUrl(ad.Thumbnail),
                ImageUrl = _storageService.GetMediaUrl(ad.Image)
            };

            return adView;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAd(int id, Ad ad)
        {
            if (id != ad.Id)
            {
                return BadRequest();
            }

            _context.Entry(ad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Ad>> PostAd([FromForm] AdForm adForm)
        {
            var ad = new Ad
            {
                CategoryId = adForm.CategoryId,
                Title = adForm.Title,
                Price = adForm.Price,
                Description = adForm.Description,
                CreatedBy = User.Identity.Name
            };

            ad.Image = await SaveFile(adForm.Image);

            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();
            await _queueService.SendMessage($"{ad.Id}###{ad.Image}");

            return CreatedAtAction("GetAd", new { id = ad.Id }, ad);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ad>> DeleteAd(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();

            return ad;
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}
