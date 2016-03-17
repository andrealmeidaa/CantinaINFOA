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
    public partial class FormConta : Form
    {
        private ControllerCliente controleCliente;
        private ControllerConta controleConta;
        private AutoCompleteStringCollection listaNomesClientes;
        private List<Cliente> listaClientes;
        private Conta contaAtual;
        public FormConta()
        {
            InitializeComponent();
            controleCliente = new ControllerCliente();
            controleConta = new ControllerConta();
        }

        private void autocomplete()
        {
            listaClientes = controleCliente.ListarClientes();
            listaNomesClientes = new AutoCompleteStringCollection();

            foreach (Cliente cliente in listaClientes)
            {
                listaNomesClientes.Add(cliente.Nome);
            }
            textBoxCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxCliente.AutoCompleteCustomSource = listaNomesClientes;

        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            if (listaNomesClientes.IndexOf(textBoxCliente.Text) == -1)
            {
                MessageBox.Show("Selecione um cliente");
                return;
            }
            contaAtual.Limite = Convert.ToDouble(textBoxLimite.Text);
            if (controleConta.GravarConta(contaAtual))
            {
                MessageBox.Show("Conta Atualizada com Sucesso");
                textBoxCliente.Text = "";
                textBoxLimite.Text = "0";
            }
               
           

        }

        private void FormConta_Load(object sender, EventArgs e)
        {
            autocomplete();
        }

        private void textBoxCliente_TextChanged(object sender, EventArgs e)
        {
            int index = listaNomesClientes.IndexOf(textBoxCliente.Text);
            if (index == -1)
            {
                contaAtual = null;
                textBoxLimite.Text = "";
                return;
            }
                
            Cliente cliente=listaClientes[index];
            contaAtual = controleConta.LocalizarContaPorCliente(cliente.IDCliente);
            textBoxLimite.Text = contaAtual.Limite.ToString();
        }
    }
}
