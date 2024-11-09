
using WebApplication2.Models;

namespace WebApplication2.Domain.Interfaces
{
    public interface IBeneficiarioRepository
    {
        IEnumerable<BeneficiarioEntity>? ObterTodos();
        BeneficiarioEntity? ObterPorId(int id);
        BeneficiarioEntity? SalvarDados(BeneficiarioEntity entidade);
        BeneficiarioEntity? EditarDados(int id, BeneficiarioEntity entidade);
        BeneficiarioEntity? DeletarDados(int id);

    }
}
