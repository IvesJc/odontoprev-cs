using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public enum TipoEnum
    {
        IndividualEFamiliar,
        PMEeMEI,
        Empresarial
    }

    [Table("tb_tipo_plano")]
    public class TipoPlanoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nome { get; set; }

        [Required]
        [EnumDataType(typeof(TipoEnum))]
        public required string Tipo { get; set; }

        [Required]
        public required double Preco { get; set; }

        [Required]
        public required int CarenciaDias { get; set; }

        [Required]
        public required int ValidadeDias { get; set; }

        public virtual ICollection<TipoServicoEntity>? TipoServicos { get; set; }
        public virtual ICollection<PlanoEntity>? Planos { get; set; }
    }
}
