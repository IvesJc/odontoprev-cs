using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public enum EspecialidadeEnum
    {
        Ortodontia,
        Odontopediatria,
        Odontologia,
        Implantologia,
        Estomatologia,
        Periodontia,
        OdontologiaEstetica,
    }

    [Table("tb_prestador_servico")]
    public class PrestadorServicoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nome { get; set; }

        [Required]
        public required int NumeroCro { get; set; }

        [Required]
        [EnumDataType(typeof(EspecialidadeEnum))]
        public required EspecialidadeEnum Especialidade { get; set; }

        [Required]
        [StringLength(50)]
        public required string NumeroContrato { get; set; }

        [Range(1, 5)]
        public int? Avaliacao { get; set; }

        [Required]
        [ForeignKey("tb_rede_credenciada")]
        public required int RedeCredenciadaId { get; set; }

        public virtual RedeCredenciadaEntity? RedeCredenciada { get; set; }
        public virtual ICollection<TipoServicoEntity>? TipoServicos { get; set; }
        public virtual ICollection<SinistroEntity>? Sinistros { get; set; }
    }
}
