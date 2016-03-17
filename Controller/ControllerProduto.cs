using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ModelCantina;
namespace Controller
{
    public class ControllerProduto
    {
        public bool GravarProduto(Produto produto)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();

            if (produto.IDProduto == 0)
            {
                comando.CommandText = "insert into tbl_produto (descricao_produto,preco_unitario) values(@descricao,@precounitario)";
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@precounitario", produto.PrecoUnitario);
            }
            else
            {
                comando.CommandText = "update tbl_produto set descricao_produto=@descricao, preco_unitario=@preco_unitario where id_produto=@idproduto";
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@precounitario", produto.PrecoUnitario);
                comando.Parameters.AddWithValue("@idproduto", produto.IDProduto);
            }
            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }
        public bool ExcluirProduto(int idProduto)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "delete from tbl_produto where id_produto=@idproduto";
            comando.Parameters.AddWithValue("@idproduto", idProduto);
            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }

        public List<Produto> ListarProdutos()
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tbl_produto";
            List<Produto> listaProdutos = new List<Produto>();
            Produto produto;
            conexao.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    produto = new Produto();
                    produto.IDProduto = reader.GetInt32(0);
                    produto.Descricao = reader.GetString(1);
                    produto.PrecoUnitario = reader.GetSqlMoney(2).ToDouble();
                    listaProdutos.Add(produto);
                }
                conexao.Close();
                return listaProdutos;
            }
        }
        public Produto LocalizarProdutoPorID(int idProduto)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tbl_produto where id_produto=@idproduto";
            comando.Parameters.AddWithValue("@idproduto", idProduto);
            List<Produto> listaProdutos = new List<Produto>();
            Produto produto=null;
            conexao.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                if (reader.Read())
                {
                    produto = new Produto();
                    produto.IDProduto = reader.GetInt32(0);
                    produto.Descricao = reader.GetString(1);
                    produto.PrecoUnitario = reader.GetSqlMoney(2).ToDouble();
                }
                conexao.Close();
                return produto;
            }
        }
    }
}
