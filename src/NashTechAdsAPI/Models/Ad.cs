using System;
using System.ComponentModel.DataAnnotations;

namespace NashTechAdsAPI.Models
{
    public class Ad
    {
        public Ad()
        {
            PostedDate = DateTime.Now;
            Status = AdStatus.Pending;
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(200)]
        public string Thumbnail { get; set; }

        public DateTime PostedDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public AdStatus Status { get; set; }

        public string CreatedBy { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
