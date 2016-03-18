using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ModelCantina;
namespace Controller
{
    public class ControllerPagamento
    {
        public bool GravarPagamento(Pagamento pagamento)
        {
            SqlConnection conexao = ADODBConnection.Connection();//Cria a conexão
            SqlCommand comando = conexao.CreateCommand();//Cria o comando
            comando.CommandText="insert into tbl_pagamento (data_pagamento,valor_pagamento,id_conta) "+
                "values(@datapagamento,@valorpagamento,@idconta)";//Define o comando SQL a ser enviado para o banco
            //Passa a atribuir os parâmetros da consulta 
            comando.Parameters.AddWithValue("@datapagamento",pagamento.DataPagamento);
            comando.Parameters.AddWithValue("@valorpagamento",pagamento.Valor);
            comando.Parameters.AddWithValue("@idconta",pagamento.Conta.IDConta);//Recupera a referência do ID vinculado a conta
            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();
            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }
    }
}
