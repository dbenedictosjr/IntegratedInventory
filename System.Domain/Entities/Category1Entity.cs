using System.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System.Domain.Entities
{
    public class Category1Entity : IAuditableRepository
    {
        [Key]
        public Guid Cat1ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Cat1Code { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Cat1Desc { get; set; }

        [Column(TypeName = "varchar(max)")] 
        public string Cat1Img { get; set; }

        public Guid CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        public Guid UpdatedBy { get; set; }

        [Column(TypeName = "datetime")] 
        public DateTime UpdatedDate { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }
    }
}
