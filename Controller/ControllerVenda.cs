using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCantina;
using System.Data.SqlClient;
namespace Controller
{
    public class ControllerVenda
    {
        public bool GravarVenda(Venda venda)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            conexao.Open();
                //Abertura da transação
            SqlTransaction transacao = conexao.BeginTransaction();
            try
            {
                SqlCommand comando = conexao.CreateCommand();
                comando.Transaction=transacao;
                comando.CommandText = "insert into tbl_venda (id_funcionario,id_cliente,data_venda) values(@idfuncionario,@idcliente,@datavenda)";
                comando.Parameters.AddWithValue("@idfuncionario", venda.Funcionario.IDFuncionario);
                comando.Parameters.AddWithValue("@idcliente", venda.Cliente.IDCliente);
                comando.Parameters.AddWithValue("@datavenda", venda.DataVenda);
                int linhasModificadas = comando.ExecuteNonQuery();
                if (linhasModificadas == 0)//Se der erro, desfaz a transação
                {
                    transacao.Rollback();
                    conexao.Close();
                    return false;
                }
                int idVenda;
                //Recupera o id gerado
                comando.Parameters.Clear();
                comando.CommandText = "select @@identity";
                String temp = comando.ExecuteScalar().ToString();
                idVenda = Convert.ToInt32(temp);
                venda.IDVenda=idVenda;
                //Agora insere cada produto selecionado na tabela tbl_venda_produto

                foreach (VendaProduto item in venda.Produtos)
                {
                    comando.CommandText = "insert into tbl_venda_produto values (@idvenda,@idproduto,@quantidade)";
                    comando.Parameters.Clear();//Limpa os parâmetros existentes
                    comando.Parameters.AddWithValue("@idvenda", venda.IDVenda);
                    comando.Parameters.AddWithValue("@idproduto", item.Produto.IDProduto);
                    comando.Parameters.AddWithValue("@quantidade", item.Quantidade);
                    linhasModificadas = comando.ExecuteNonQuery();
                    if (linhasModificadas == 0)
                    {
                        transacao.Rollback();
                        conexao.Close();
                        return false;
                    }
                }
                transacao.Commit();
                conexao.Close();
                return true;

            }
            catch (Exception err)
            {
                transacao.Rollback();
                conexao.Close();
                Console.WriteLine(err.Message);
                return false;

            }

            
            
        }
    }
}
