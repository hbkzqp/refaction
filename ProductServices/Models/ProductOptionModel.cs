using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models
{
    public class ProductOptionModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}