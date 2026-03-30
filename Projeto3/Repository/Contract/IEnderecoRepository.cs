using Projeto3.Models;

namespace Projeto3.Repository
{
    public interface IEnderecoRepository
    {
        void Cadastrar(Endereco endereco);

        void Atualizar(Endereco endereco);

        void Excluir(int Id);

        Endereco ObterEndereco(int Id);

        IEnumerable<Endereco> ObterTodosEnderecos();
    }
}
