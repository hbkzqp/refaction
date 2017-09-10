using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models
{
    public class ProductModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal DeliveryPrice { get; set; }

    }
}