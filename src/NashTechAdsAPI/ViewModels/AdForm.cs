using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NashTechAdsAPI.ViewModels
{
    public class AdForm
    {
        [Required]
        public string Title { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public int CategoryId { get; set; }
    }
}
