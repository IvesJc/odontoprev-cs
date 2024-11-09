using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("tb_missao")]
    public class MissaoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(0, 1)]
        [DefaultValue(0)]
        public required int Concluido { get; set; }

        public int RecompensaRecebida { get; set; }

        [Required]
        public required DateTime ExpiraEm { get; set; }

        [Required]
        [ForeignKey("tb_tipo_missao")]
        public required int TipoMissaoId { get; set; }

        [Required]
        [ForeignKey("tb_beneficiario")]
        public required int BeneficiarioId { get; set; }

        public virtual TipoMissaoEntity? TipoMissao { get; set; }
        public virtual BeneficiarioEntity? Beneficiario { get; set; }
    }
}
