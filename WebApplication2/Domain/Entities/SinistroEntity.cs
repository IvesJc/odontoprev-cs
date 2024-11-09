using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("tb_sinistro")]
    public class SinistroEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required DateTime DataSolicitacao { get; set; }

        [Required]
        public required DateTime DataAutorizacao { get; set; }

        public double? ValorPagoParaPrestador { get; set; }

        [Required]
        [ForeignKey("tb_beneficiario")]
        public required int BeneficiarioId { get; set; }

        [Required]
        [ForeignKey("tb_prestador_servico")]
        public required int PrestadorServicoId { get; set; }

        public virtual BeneficiarioEntity? Beneficiario { get; set; }
        public virtual PrestadorServicoEntity? PrestadorServico { get; set; }
        public virtual ICollection<ServicoEntity>? Servicos { get; set; }
    }
}
