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
    public partial class FormFuncionario : Form
    {
        private ControllerFuncionario controle;
        public FormFuncionario()
        {
            InitializeComponent();
            controle = new ControllerFuncionario();
            atualizarDataGrid();

        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void novo()
        {
            textBoxNome.Text = "";
            textBoxMatricula.Text = "";
            textBoxIDFuncionario.Text = "0";
        }

        private void atualizarDataGrid()
        {
            dataGridViewFuncionario.DataSource = 
                controle.ListarFuncionarios();
            dataGridViewFuncionario.Columns[0].Visible = false;


        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Funcionario func = new Funcionario();
            func.IDFuncionario = Convert.ToInt32(textBoxIDFuncionario.Text);
            func.Nome = textBoxNome.Text;
            func.Matricula = textBoxMatricula.Text;

            if (controle.GravarFuncionario(func))
            {
                MessageBox.Show("Funcionário Salvo com Sucesso");
                novo();
                atualizarDataGrid();
            }
            else
            {
                MessageBox.Show("Erro ao Salvar Funcionário");
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            int idFuncionario = Convert.ToInt32(textBoxIDFuncionario.Text);

            if (controle.ExcluirFuncionario(idFuncionario))
            {
                MessageBox.Show("Funcionário Excluido com Sucesso");
                novo();
                atualizarDataGrid();
            }
            else
            {
                MessageBox.Show("Erro Excluindo Funcionário");
            }
        }

        private void dataGridViewFuncionario_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFuncionario.CurrentRow != null)
            {
                List<Funcionario> lista = (List<Funcionario>)dataGridViewFuncionario.DataSource;
                Funcionario func = lista[dataGridViewFuncionario.CurrentRow.Index];
                textBoxNome.Text = func.Nome;
                textBoxMatricula.Text = func.Matricula;
                textBoxIDFuncionario.Text = func.IDFuncionario.ToString();
            }
        }

        
    }
}
