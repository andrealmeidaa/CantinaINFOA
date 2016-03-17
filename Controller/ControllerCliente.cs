using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCantina;
using System.Data.SqlClient;
namespace Controller
{
    public class ControllerCliente
    {
        public bool GravarCliente(Cliente cliente)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();

            if (cliente.IDCliente == 0)
            {
                comando.CommandText = "insert into tbl_cliente (nome_cliente,telefone_cliente) values(@nome,@telefone)";
                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
            }else
            {
                comando.CommandText = "update tbl_cliente set nome_cliente=@nome,telefone_cliente=@telefone where id_cliente=@id_cliente";
                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@id_cliente", cliente.IDCliente);
            }

            
            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }
        public bool ExcluirCliente(int idCliente)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "delete from tbl_cliente where id_cliente=@idcliente";
            comando.Parameters.AddWithValue("@idcliente", idCliente);
            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }

        public List<Cliente> ListarClientes()
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tbl_cliente";
            List<Cliente> listaClientes = new List<Cliente>();
            Cliente cliente;
            conexao.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    cliente = new Cliente();
                    cliente.IDCliente = reader.GetInt32(0);
                    cliente.Nome = reader.GetString(1);
                    cliente.Telefone = reader.GetString(2);
                    listaClientes.Add(cliente);
                }
                conexao.Close();
                return listaClientes;
            }
        }
        public Cliente LocalizarClientePorID(int idCliente)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tbl_cliente where id_cliente=@idcliente";
            comando.Parameters.AddWithValue("@idcliente", idCliente);
            Cliente cliente = null;
            conexao.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                if (reader.Read())
                {
                    cliente = new Cliente();
                    cliente.IDCliente = reader.GetInt32(0);
                    cliente.Nome = reader.GetString(1);
                    cliente.Telefone = reader.GetString(2);
                }
                conexao.Close();
                return cliente;
            }
        }
    }
}
