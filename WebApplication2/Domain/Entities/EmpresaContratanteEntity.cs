using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("tb_empresa_contratante")]
    public class EmpresaContratanteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")]
        public required string Cnpj { get; set; }

        [Required]
        [StringLength(50)]
        public required string NumeroContrato { get; set; }

        public virtual ICollection<PlanoEntity>? Planos { get; set; }
        public virtual ICollection<BeneficiarioEntity>? Beneficiarios { get; set; }
    }
}
