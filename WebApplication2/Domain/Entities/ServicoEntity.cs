using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("tb_servico")]
    public class ServicoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double ValorPago { get; set; }

        [Required]
        [ForeignKey("tb_tipo_servico")]
        public required int TipoServicoId { get; set; }

        [Required]
        [ForeignKey("tb_sinistro")]
        public required int SinistroId { get; set; }

        public virtual TipoServicoEntity? TipoServico { get; set; }
        public virtual SinistroEntity? Sinistro { get; set; }
    }
}
