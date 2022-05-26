﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public double Rating { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
    }
}
