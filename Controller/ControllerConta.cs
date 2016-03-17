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
            comando.CommandText = "select id_conta,limite from tbl_conta where id_cliente=@idcliente";
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
                    /*Precisamos agora recuperar a referência ao cliente dessa conta
                     para isso utilizaremos o controllerCliente
                     */
                    conexao.Close();//Precisamos fechar a conexão para que o controller cliente realize a operação
                    ControllerCliente controleCliente = new ControllerCliente();
                    conta.Cliente = controleCliente.LocalizarClientePorID(idCliente);
                }
                else
                    conexao.Close();
                return conta;
            }
        }
    }
}
