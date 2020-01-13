using System.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System.Domain.Entities
{
    public class ProductEntity : IAuditableRepository
    {
        [Key]
        public Guid ProdID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string ProdCode { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string ShortDesc { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string LongDesc { get; set; }

        public Guid Cat3ID { get; set; }

        public double MinStock { get; set; }

        public double MaxStock { get; set; }

        public double Cost { get; set; }

        public double MarkupAmount { get; set; }

        public double MarkupPercent { get; set; }

        public double Price { get; set; }

        public bool? Vatable { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Barcode { get; set; }

        public double Stock { get; set; }

        public bool? Active { get; set; }

        public Guid CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        public Guid UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }

        [ForeignKey("Cat3ID")]
        public virtual Category3Entity Category3 { get; set; }
    }
}
