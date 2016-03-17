using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using ModelCantina;
namespace GUICantina
{
    public partial class FormVenda : Form
    {
        private ControllerFuncionario controleFuncionario;
        private ControllerCliente controleCliente;
        private ControllerProduto controleProduto;
        private ControllerVenda controleVenda;
        private AutoCompleteStringCollection listaNomeFuncionarios;
        private List<Funcionario> listaFuncionarios;
        private List<Cliente> listaClientes;
        private List<Produto> listaProdutos;
        private AutoCompleteStringCollection listaNomeClientes;
        private AutoCompleteStringCollection listaDescricaoProdutos;

        //Variáveis para controlar os dados de funcionário, cliente e produto que são selecionados pelo usuário

        private Funcionario funcionarioAtual;
        private Cliente clienteAtual;
        private Produto produtoAtual;
        private Venda vendaAtual;

        public FormVenda()
        {
            InitializeComponent();
            controleCliente = new ControllerCliente();
            controleFuncionario = new ControllerFuncionario();
            controleProduto = new ControllerProduto();
            controleVenda = new ControllerVenda();
        }

        private void novo()
        {
            vendaAtual = new Venda();
            textBoxCliente.Text = "";
            textBoxFuncionario.Text = "";
            dateTimePickerDataVenda.Value = DateTime.Now;
            textBoxProduto.Text = "";
            textBoxQuantidade.Text = "";
            atualizaGrid();
        }

        private void autocomplete()
        {
            //Autocomplete da caixa de texto referente aos funcionários
            textBoxCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            listaClientes = controleCliente.ListarClientes();
            listaNomeClientes = new AutoCompleteStringCollection();
            foreach (Cliente cliente in listaClientes)
            {
                listaNomeClientes.Add(cliente.Nome);
            }
            textBoxCliente.AutoCompleteCustomSource= listaNomeClientes;

            //Autocomplete da caixa de texto referente aos clientes

            textBoxFuncionario.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxFuncionario.AutoCompleteSource = AutoCompleteSource.CustomSource;
            listaFuncionarios = controleFuncionario.ListarFuncionarios();
            listaNomeFuncionarios= new AutoCompleteStringCollection();
            foreach (Funcionario funcionario in listaFuncionarios)
            {
                listaNomeFuncionarios.Add(funcionario.Nome);
            }
            textBoxFuncionario.AutoCompleteCustomSource = listaNomeFuncionarios;

            //Autocomplete da caixa de texto referente aos produtos

            textBoxProduto.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxProduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            listaProdutos = controleProduto.ListarProdutos();
            listaDescricaoProdutos = new AutoCompleteStringCollection();
            foreach (Produto produto in listaProdutos)
            {
                listaDescricaoProdutos.Add(produto.Descricao);
            }
            textBoxProduto.AutoCompleteCustomSource = listaDescricaoProdutos;


        }

        private void textBoxFuncionario_TextChanged(object sender, EventArgs e)
        {
            int index = listaNomeFuncionarios.IndexOf(textBoxFuncionario.Text);
            if (index == -1)
            {
                funcionarioAtual = null;
                return;
            }
            funcionarioAtual = listaFuncionarios[index];
            vendaAtual.Funcionario = funcionarioAtual;
        }

        private void textBoxCliente_TextChanged(object sender, EventArgs e)
        {
            int index = listaNomeClientes.IndexOf(textBoxCliente.Text);
            if (index == -1)
            {
                clienteAtual = null;
                return;
            }
            clienteAtual = listaClientes[index];
            vendaAtual.Cliente = clienteAtual;
        }

        private void textBoxProduto_TextChanged(object sender, EventArgs e)
        {
            int index = listaDescricaoProdutos.IndexOf(textBoxProduto.Text);
            if (index == -1)
            {
                produtoAtual = null;
                return;
            }
            produtoAtual = listaProdutos[index];
           
        }

        private void FormVenda_Load(object sender, EventArgs e)
        {
            novo();
            autocomplete();
        }

        private void buttonNovaVenda_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void buttonAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (produtoAtual == null)
            {
                MessageBox.Show("Selecione um Produto");
                return;
            }

            //Verifica se o produto já está na lista

            foreach (VendaProduto vp in vendaAtual.Produtos)
            {
                if (vp.Produto.IDProduto == produtoAtual.IDProduto)
                {
                    MessageBox.Show("Produto Já Inserido");
                    return;
                }
            }

            int quantidade;
            if (!Int32.TryParse(textBoxQuantidade.Text, out quantidade))
            {
                MessageBox.Show("Quantidade Inválida");
                return;
            }
            VendaProduto item = new VendaProduto();
            item.Venda = vendaAtual;
            item.Produto = produtoAtual;
            item.Quantidade = quantidade;
            vendaAtual.Produtos.Add(item);
            atualizaGrid();
        }

        private void atualizaGrid()
        {
            dataGridViewProdutos.DataSource = null;//Como a lista não é gerada todas as vezes, precisamos romper o vínculo
            dataGridViewProdutos.DataSource = vendaAtual.Produtos;
            textBoxTotal.Text = vendaAtual.Total.ToString();//Atualiza o valor total;
            dataGridViewProdutos.Update();
            dataGridViewProdutos.Refresh();
        }

        private void buttonRemoverProduto_Click(object sender, EventArgs e)
        {
            if (dataGridViewProdutos.CurrentRow != null)
            {
                vendaAtual.Produtos.RemoveAt(dataGridViewProdutos.CurrentRow.Index);
                atualizaGrid();
            }
        }

        private void buttonFinalizarVenda_Click(object sender, EventArgs e)
        {
            //Captura os dados para venda
            vendaAtual.DataVenda = dateTimePickerDataVenda.Value;

            if(controleVenda.GravarVenda(vendaAtual))
            {
                MessageBox.Show("Venda Registrada com Sucesso");
                novo();
            }
            else
            {
                MessageBox.Show("Erro Registrando a Venda");
            }
            
        }

        private void buttonCancelarVenda_Click(object sender, EventArgs e)
        {
            novo();
        }


    }
}
