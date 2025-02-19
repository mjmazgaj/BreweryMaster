﻿using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderRequest
    {
        [Required]
        [MinIntValidation]
        public int RecipeId { get; set; }

        [Required]
        [MinIntValidation]
        public int Capacity { get; set; }

        [Required]
        [MinIntValidation]
        public int ContainerId { get; set; }

        [Required]
        public DateTime TargetDate { get; set; }
    }
}
