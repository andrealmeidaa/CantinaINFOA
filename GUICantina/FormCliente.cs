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
    public partial class FormCliente : Form
    {
        private ControllerCliente controle;

        public FormCliente()
        {
            InitializeComponent();
            controle = new ControllerCliente();
        }

        private void novo()
        {
            textBoxNome.Text = "";
            maskedTextBoxTelefone.Text = "";
            textBoxIdCliente.Text = "0";
        }

        private void atualizaGrid()
        {
            dataGridViewClientes.DataSource = controle.ListarClientes();
            dataGridViewClientes.Columns[0].Visible = false;
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            atualizaGrid();
            novo();
        }

        private void dataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientes.CurrentRow != null)
            {
                List<Cliente> lista = (List<Cliente>)dataGridViewClientes.DataSource;
                Cliente cliente = lista[dataGridViewClientes.CurrentRow.Index];
                textBoxNome.Text = cliente.Nome;
                maskedTextBoxTelefone.Text = cliente.Telefone;
                textBoxIdCliente.Text = cliente.IDCliente.ToString();
            }
        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = textBoxNome.Text;
            cliente.Telefone = maskedTextBoxTelefone.Text;
            cliente.IDCliente = Convert.ToInt32(textBoxIdCliente.Text);

            if (controle.GravarCliente(cliente))
            {
                MessageBox.Show("Cliente salvo com sucesso");
                novo();
                atualizaGrid();
            }
            else
            {
                MessageBox.Show("Erro ao salvar cliente");
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(textBoxIdCliente.Text);
            if (idCliente != 0)
            {
                if (controle.ExcluirCliente(idCliente))
                {
                    MessageBox.Show("Cliente excluido com sucesso");
                    novo();
                    atualizaGrid();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir cliente");
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para exclusão");
            }
        }
    }
}
