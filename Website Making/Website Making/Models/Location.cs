﻿using System.ComponentModel.DataAnnotations;

namespace Website_Making.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Profile Profile { get; set; }
    }
}
