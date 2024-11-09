using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("tb_plano")]
    public class PlanoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required DateTime DataExpiracao { get; set; }

        [Required]
        public required double PrecoCobrado { get; set; }

        public DateTime? DataFinalCarencia { get; set; }

        // Foreign Keys

        [Required]
        [ForeignKey("tb_tipo_plano")]
        public required int TipoPlanoId { get; set; }

        [ForeignKey("tb_empresa_contratante")]
        public int EmpresaContratanteId { get; set; }

        // Virtual Entities

        public virtual EmpresaContratanteEntity? EmpresaContratante { get; set; }
        public virtual TipoPlanoEntity? TipoPlano { get; set; }
        public virtual ICollection<BeneficiarioEntity>? Beneficiarios { get; set; }
    }
}
