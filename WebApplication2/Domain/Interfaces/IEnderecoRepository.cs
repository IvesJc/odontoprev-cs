using WebApplication2.Models;

namespace WebApplication2.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        IEnumerable<EnderecoEntity>? ObterTodos();
        EnderecoEntity? ObterPorId(int id);
        EnderecoEntity? SalvarDados(EnderecoEntity entidade);
        EnderecoEntity? EditarDados(int id, EnderecoEntity entidade);
        EnderecoEntity? DeletarDados(int id);
    }
}
