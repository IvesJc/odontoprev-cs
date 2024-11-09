using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("tb_recompensa")]
    public class RecompensaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required DateTime ResgatadoEm { get; set; }

        [Required]
        public required DateTime ExpiraEm { get; set; }

        [Required]
        [ForeignKey("tb_beneficiario")]
        public required int BeneficiarioId { get; set; }

        [Required]
        [ForeignKey("tb_tipo_recompensa")]
        public required int TipoRecompensaId { get; set; }

        public virtual BeneficiarioEntity? Beneficiario { get; set; }
        public virtual TipoRecompensaEntity? TipoRecompensa { get; set; }
    }
}
