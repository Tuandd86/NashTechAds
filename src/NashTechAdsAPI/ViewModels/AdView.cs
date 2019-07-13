using System;

namespace NashTechAdsAPI.ViewModels
{
    public class AdView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public DateTime PostedDate { get; set; }

        public string CreatedBy { get; set; }

        public string Status { get; set; }
    }
}
