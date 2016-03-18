using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelCantina;
using Controller;
namespace GUICantina
{
    public partial class FormPagamento : Form
    {
        private ControllerCliente controleCliente;
        private ControllerConta controleConta;
        private ControllerPagamento controlePagamento;
        private List<Cliente> listaClientes;
        private AutoCompleteStringCollection listaNomeClientes;
        private Conta contaAtual;
        public FormPagamento()
        {
            InitializeComponent();
            controleCliente = new ControllerCliente();
            controleConta = new ControllerConta();
            controlePagamento = new ControllerPagamento();
        }

        private void autocomplete()
        {
            
            textBoxCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;//Define o tipo de autocomplete
            textBoxCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;//Define qual será o tipo da origem
            listaClientes = controleCliente.ListarClientes();//Lista de objetos da classe Cliente
            listaNomeClientes = new AutoCompleteStringCollection();//Lista com o nome dos clientes
            foreach (Cliente cliente in listaClientes)//Para cada cliente existente na lista faça
            {
                listaNomeClientes.Add(cliente.Nome);//Adicione na lista de nomes dos clientes que serão usados no autocomplete
            }
            textBoxCliente.AutoCompleteCustomSource = listaNomeClientes;//Associa a lista de nomes a caixa de texto cliente
        }
        //Evento que captura qualquer alteração na caixa de texto
        //Para adicionar um evento, clique no controle e no botão semelhante a um raio, escolha o evento dentro da lista
        private void textBoxCliente_TextChanged(object sender, EventArgs e)
        {
            //Verifique qual a posição na lista o nome do cliente está vinculado
            int index = listaNomeClientes.IndexOf(textBoxCliente.Text);
            if (index == -1)//Se ele não achar o cliente, não podemos consultar qual a conta está associada
            {
                contaAtual = null;//Limpa a conta
                return;
            }
            /*
             
             * listaClientes[index].IDCliente -> Pega o objeto da classe cliente associada a posição da lista
             * Com o id recuperado, usamos o método LocalizarPorCliente da classe controle cliente
             */
            contaAtual = controleConta.LocalizarContaPorCliente( listaClientes[index].IDCliente);

        }

        private void novo()//Limpa os controles do formulário
        {
            textBoxCliente.Text = "";
            dateTimePickerDataPagamento.Value = DateTime.Now;
            textBoxValor.Text = "";
            contaAtual = null;
            errorProvider.Clear();
        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {

            if(!validar())//Aplica o processo de validação
            {
                MessageBox.Show("Corrija os erros indicados");
                return;
            }

            double valor = Double.Parse(textBoxValor.Text);

            Pagamento pagamento = new Pagamento();//Instância um objeto da classe pagamento
            pagamento.Conta = contaAtual;//Associa a conta que foi localizada no evento text changed
            pagamento.DataPagamento = dateTimePickerDataPagamento.Value;
            pagamento.Valor = valor;

            if (controlePagamento.GravarPagamento(pagamento))
            {
                MessageBox.Show("Pagamento Salvo com Sucesso");
                novo();
            }
            else
            {
                MessageBox.Show("Erro ao salvar pagamento");
            }
        }

        private void FormPagamento_Load(object sender, EventArgs e)
        {
            autocomplete();//Aciona o método no momento em que o formulário é carregado
        }

        private void textBoxCliente_Validated(object sender, EventArgs e)
        {
            if (contaAtual == null)
            {
                errorProvider.SetError(textBoxCliente, "Informe o Cliente");
                return;
            }
            errorProvider.SetError(textBoxCliente, "");
            buttonGravar.Enabled = true;
        }

        private void textBoxValor_Validated(object sender, EventArgs e)
        {
            double valor;
            if (!Double.TryParse(textBoxValor.Text, out valor))
            {
                errorProvider.SetError(textBoxValor, "Informe o valor do pagamento");
                return;
            }
            errorProvider.SetError(textBoxValor, "");
        }

        private bool validar()
        {
            double valor;
            if (!Double.TryParse(textBoxValor.Text, out valor))
            {
                errorProvider.SetError(textBoxValor, "Informe o valor do pagamento");
                return false; ;
            }
            errorProvider.SetError(textBoxValor, "");
            if (contaAtual == null)
            {
                errorProvider.SetError(textBoxCliente, "Informe o Cliente");
                buttonGravar.Enabled = false;
                return false;
            }
            errorProvider.SetError(textBoxCliente, "");
            return true;
        }
    }
}
