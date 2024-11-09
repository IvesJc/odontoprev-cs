using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("tb_rede_credenciada")]
    public class RedeCredenciadaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nome { get; set; }

        public virtual ICollection<EnderecoEntity>? Enderecos { get; set; }
        public virtual ICollection<PrestadorServicoEntity>? PrestadorServicos { get; set; }
    }
}
