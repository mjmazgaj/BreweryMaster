﻿using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class PriceEstimationRequest
    {
        [Required]
        public string? BeerType { get; set; }
        [Required]
        public string? ContainerType { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
