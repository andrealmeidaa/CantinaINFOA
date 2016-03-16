using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ModelCantina;

namespace Controller
{
    public class ControllerFuncionario
    {
        public bool GravarFuncionario(Funcionario func)
        {
            //Cria a conexão
            SqlConnection conexao = ADODBConnection.Connection();
            conexao.Open();//Abre a conexão
            SqlCommand comando = conexao.CreateCommand();//Cria um comando para ser enviado ao SQL Server
            //Se o id for 0, significa que devemos realizar um insert
            if (func.IDFuncionario == 0)
            {
                comando.CommandText = "insert into tbl_funcionario (nome_funcionario,matricula_funcionario) values(@nome,@matricula)";
                comando.Parameters.AddWithValue("@nome", func.Nome);
                comando.Parameters.AddWithValue("@matricula", func.Matricula);
            }
            else //Caso contrário, significa que devemos realizar um update
            {
                comando.CommandText = "update tbl_funcionario set " +
                    " nome_funcionario=@nome," +
                    " matricula_funcionario=@matricula " +
                    " where id_funcionario=@idfuncionario";
                comando.Parameters.AddWithValue("@nome", func.Nome);
                comando.Parameters.AddWithValue("@matricula", func.Matricula);
                comando.Parameters.AddWithValue("@idfuncionario", func.IDFuncionario);

            }
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }

        public bool ExcluirFuncionario(int idFuncionario)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            conexao.Open();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "delete from tbl_funcionario " +
                " where id_funcionario=@idfuncionario";
            comando.Parameters.AddWithValue("@idfuncionario", idFuncionario);
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Funcionario> ListarFuncionarios()
        {
            SqlConnection conexao = ADODBConnection.Connection();
            conexao.Open();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select id_funcionario,nome_funcionario," +
                "matricula_funcionario from tbl_funcionario" +
                " order by nome_funcionario";
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                List<Funcionario> lista = new List<Funcionario>();
                Funcionario func;
                while (reader.Read())
                {
                    func = new Funcionario();
                    func.IDFuncionario = reader.GetInt32(0);
                    func.Nome = reader.GetString(1);
                    func.Matricula = reader.GetString(2);
                    lista.Add(func);
                }
                conexao.Close();
                return lista;
            }
        }

        public Funcionario LocalizarFuncionarioPorID(int idFuncionario)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            conexao.Open();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select id_funcionario,nome_funcionario," +
                "matricula_funcionario from tbl_funcionario" +
                " where id_funcionario=@idfuncionario "+
                " order by nome_funcionario";
            comando.Parameters.AddWithValue("@idfuncionario", idFuncionario);
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                Funcionario func=null;
                if (reader.Read())
                {
                    func = new Funcionario();
                    func.IDFuncionario = reader.GetInt32(0);
                    func.Nome = reader.GetString(1);
                    func.Matricula = reader.GetString(2);
                }
                conexao.Close();
                return func;
            }
        }
    }
}
