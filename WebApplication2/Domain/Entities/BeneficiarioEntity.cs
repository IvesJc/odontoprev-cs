using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public enum TipoBeneficiarioEnum
    {
        Pessoal,
        Empresa,
        Familiar, // Para planos familiares, onde o contratante terá o tipo Pessoal, e o familiar terá o tipo Familiar
    }

    [Table("tb_beneficiario")]
    public class BeneficiarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$")]
        public required string Cpf { get; set; }

        [Required]
        [EnumDataType(typeof(TipoBeneficiarioEnum))]
        public required TipoBeneficiarioEnum Tipo { get; set; }

        [Required]
        [RegularExpression(@"^(\+55\s ?)?(0?(\(?\d{2}\)?)?\s?\d{4,5}-?\d{4}$)")]
        public required string Telefone { get; set; }

        [Required]
        public required DateTime DataAdesao { get; set; }

        [StringLength(300)]
        public string? FotoUrl { get; set; }

        [StringLength(50)]
        public string? NumeroContrato { get; set; }

        [ForeignKey("tb_endereco")]
        public int? EnderecoId { get; set; }

        [ForeignKey("tb_empresa_contratante")]
        public int? EmpresaContratanteId { get; set; }

        public virtual ProgramaRelacionamentoStatusEntity? ProgramaRelacionamentoStatus { get; set; }
        public virtual EnderecoEntity? Endereco { get; set; }
        public virtual EmpresaContratanteEntity? EmpresaContratante { get; set; }

        public virtual ICollection<PlanoEntity>? Planos { get; set; }
        public virtual ICollection<SinistroEntity>? Sinistros { get; set; }
        public virtual ICollection<MissaoEntity>? Missoes { get; set; }
        public virtual ICollection<RecompensaEntity>? Recompensas { get; set; }
    }
}
