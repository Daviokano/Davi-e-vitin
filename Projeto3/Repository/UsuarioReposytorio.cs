using MySql.Data.MySqlClient;
using Projeto3.Models;
using Projeto3.Repository.Contract;

namespace Projeto3.Repository
{
    public class UsuarioReposytorio : IUsuarioRepository
    {
        private readonly string _conexaoMySQl;
        public UsuarioReposytorio(IConfiguration conf)
        {
            _conexaoMySQl = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            using( var conexao = new MySqlConnection(_conexaoMySQl) ) 
            {
                
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into usuario(nomeUsu, Cargo, DataNasc)" +
                                                    "values (@nomeUsu, @Cargo, @DataNasc)", conexao);

                cmd.Parameters.Add("@nomeUsu", MySqlDbType.VarChar).Value = usuario.nomeUsu;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            throw new NotImplementedException();
        }

        public Usuario ObterUsuario(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
