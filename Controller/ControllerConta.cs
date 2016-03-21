using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCantina;
using System.Data.SqlClient;
namespace Controller
{
    public class ControllerConta
    {
        public bool GravarConta(Conta conta)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "update tbl_conta set limite=@limite where id_conta=@idconta";
            comando.Parameters.AddWithValue("@idconta", conta.IDConta);
            comando.Parameters.AddWithValue("@limite", conta.Limite);
            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }

        public Conta LocalizarContaPorCliente(int idCliente)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select id_conta,limite,tbl_cliente.id_cliente,nome_cliente,telefone_cliente from tbl_conta join tbl_cliente" 
                +" on tbl_conta.id_cliente=tbl_cliente.id_cliente where tbl_conta.id_cliente=@idcliente";
            comando.Parameters.AddWithValue("@idcliente", idCliente);
            conexao.Open();
            Conta conta = null;
            using (SqlDataReader reader = comando.ExecuteReader())
            {

                if (reader.Read())
                {
                    conta = new Conta();
                    conta.IDConta = reader.GetInt32(0);
                    conta.Limite = reader.GetSqlMoney(1).ToDouble();
                    conta.Cliente = new Cliente();
                    conta.Cliente.IDCliente = reader.GetInt32(2);
                    conta.Cliente.Nome = reader.GetString(3);
                    conta.Cliente.Telefone = reader.GetString(4);
                   
                }
                conexao.Close();
                return conta;
            }
        }
    }
}
