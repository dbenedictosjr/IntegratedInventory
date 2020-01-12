using System.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System.Domain.Entities
{
    public class Category2Entity : IAuditableRepository
    {
        [Key]
        public Guid Cat2ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Cat2Code { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Cat2Desc { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Cat2Img { get; set; }

        public Guid Cat1ID { get; set; }

        public Guid CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        public Guid UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }

        [ForeignKey("Cat1ID")]
        public virtual Category1Entity Category1 { get; set; }
    }
}
