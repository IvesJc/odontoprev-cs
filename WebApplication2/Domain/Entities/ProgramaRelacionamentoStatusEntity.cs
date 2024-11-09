using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("tb_programa_relacionamento_status")]
    public class ProgramaRelacionamentoStatusEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DefaultValue(0)]
        public required int QtdePontos { get; set; }

        [Required]
        public required DateTime DataAdesao { get; set; }

        [Required]
        [ForeignKey("tb_beneficiario")]
        public required int BeneficiarioId { get; set; }

        public virtual BeneficiarioEntity? Beneficiario { get; set; }
    }
}
