using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace System.Infrastructure.Models
{
    public class ProductModel
    {
        [Required]
        public Guid ID { get; set; }

        [StringLength(10, ErrorMessage = "Limit Code to 10 characters.")]
        public string Code { get; set; }

        [StringLength(40, ErrorMessage = "Limit Short Description to 40 characters.")]
        [Display(Name = "Short Description")]
        public string ShortDesc { get; set; }

        [StringLength(100, ErrorMessage = "Limit Long Description to 100 characters.")]
        [Display(Name = "Long Description")]
        public string LongDesc { get; set; }

        [Required]
        [Display(Name = "Category")]
        public Guid Cat3ID { get; set; }

        [Required]
        [Display(Name = "Minimum Stock")]
        public double MinStock { get; set; }

        [Required]
        [Display(Name = "Maximum Stock")]
        public double MaxStock { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        [Display(Name = "Markup Amount")]
        public double? MarkupAmount { get; set; }

        [Required]
        [Display(Name = "Markup Percent")]
        public double? MarkupPercent { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool? Vatable { get; set; }

        [StringLength(20, ErrorMessage = "Limit Barcode to 20 characters.")]
        public string Barcode { get; set; }

        [Required]
        public double Stock { get; set; }

        [Required]
        public bool? Active { get; set; }

        [Display(Name = "Category")]
        public string Cat3Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}