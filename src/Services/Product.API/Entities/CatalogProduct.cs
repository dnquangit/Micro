using Contracts.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Entities
{
    public class CatalogProduct : EntityAuditBase<long>
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public required string No { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public required string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public required string Summary { get; set; }

        [Column(TypeName = "text")]
        public required string Description { get; set; }
        public decimal Price { get; set; }
    }
}
