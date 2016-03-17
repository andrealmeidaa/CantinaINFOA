using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICantina
{
    public partial class FormPrincipal : Form
    {
        private FormFuncionario formFuncionario;
        private FormCliente formCliente;
        private FormConta formConta;
        private FormVenda formVenda;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formFuncionario == null)
            {
                formFuncionario = new FormFuncionario();
            }
            formFuncionario.ShowDialog(this);
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formCliente == null)
            {
                formCliente = new FormCliente();
            }
            formCliente.ShowDialog(this);
        }

        private void atualizaçãoLimiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formConta == null)
            {
                formConta = new FormConta();
            }
            formConta.ShowDialog(this);
        }

        private void registroDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formVenda == null)
            {
                formVenda = new FormVenda();
            }
            formVenda.ShowDialog(this);
        }
    }
}
