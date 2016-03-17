namespace GUICantina
{
    partial class FormVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFuncionario = new System.Windows.Forms.TextBox();
            this.textBoxCliente = new System.Windows.Forms.TextBox();
            this.dateTimePickerDataVenda = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxProduto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.buttonAdicionarProduto = new System.Windows.Forms.Button();
            this.buttonRemoverProduto = new System.Windows.Forms.Button();
            this.dataGridViewProdutos = new System.Windows.Forms.DataGridView();
            this.buttonFinalizarVenda = new System.Windows.Forms.Button();
            this.buttonCancelarVenda = new System.Windows.Forms.Button();
            this.buttonNovaVenda = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePickerDataVenda);
            this.groupBox1.Controls.Add(this.textBoxCliente);
            this.groupBox1.Controls.Add(this.textBoxFuncionario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Venda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data da Venda:";
            // 
            // textBoxFuncionario
            // 
            this.textBoxFuncionario.Location = new System.Drawing.Point(128, 32);
            this.textBoxFuncionario.Name = "textBoxFuncionario";
            this.textBoxFuncionario.Size = new System.Drawing.Size(541, 22);
            this.textBoxFuncionario.TabIndex = 3;
            this.textBoxFuncionario.TextChanged += new System.EventHandler(this.textBoxFuncionario_TextChanged);
            // 
            // textBoxCliente
            // 
            this.textBoxCliente.Location = new System.Drawing.Point(128, 77);
            this.textBoxCliente.Name = "textBoxCliente";
            this.textBoxCliente.Size = new System.Drawing.Size(541, 22);
            this.textBoxCliente.TabIndex = 4;
            this.textBoxCliente.TextChanged += new System.EventHandler(this.textBoxCliente_TextChanged);
            // 
            // dateTimePickerDataVenda
            // 
            this.dateTimePickerDataVenda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataVenda.Location = new System.Drawing.Point(128, 125);
            this.dateTimePickerDataVenda.Name = "dateTimePickerDataVenda";
            this.dateTimePickerDataVenda.Size = new System.Drawing.Size(132, 22);
            this.dateTimePickerDataVenda.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total:";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Location = new System.Drawing.Point(396, 125);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(193, 22);
            this.textBoxTotal.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonRemoverProduto);
            this.groupBox2.Controls.Add(this.buttonAdicionarProduto);
            this.groupBox2.Controls.Add(this.textBoxQuantidade);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxProduto);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Produto:";
            // 
            // textBoxProduto
            // 
            this.textBoxProduto.Location = new System.Drawing.Point(128, 30);
            this.textBoxProduto.Name = "textBoxProduto";
            this.textBoxProduto.Size = new System.Drawing.Size(541, 22);
            this.textBoxProduto.TabIndex = 8;
            this.textBoxProduto.TextChanged += new System.EventHandler(this.textBoxProduto_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Quantidade:";
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Location = new System.Drawing.Point(128, 60);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(144, 22);
            this.textBoxQuantidade.TabIndex = 8;
            // 
            // buttonAdicionarProduto
            // 
            this.buttonAdicionarProduto.Location = new System.Drawing.Point(298, 57);
            this.buttonAdicionarProduto.Name = "buttonAdicionarProduto";
            this.buttonAdicionarProduto.Size = new System.Drawing.Size(158, 37);
            this.buttonAdicionarProduto.TabIndex = 10;
            this.buttonAdicionarProduto.Text = "Adicionar Produto";
            this.buttonAdicionarProduto.UseVisualStyleBackColor = true;
            this.buttonAdicionarProduto.Click += new System.EventHandler(this.buttonAdicionarProduto_Click);
            // 
            // buttonRemoverProduto
            // 
            this.buttonRemoverProduto.Location = new System.Drawing.Point(479, 57);
            this.buttonRemoverProduto.Name = "buttonRemoverProduto";
            this.buttonRemoverProduto.Size = new System.Drawing.Size(158, 37);
            this.buttonRemoverProduto.TabIndex = 11;
            this.buttonRemoverProduto.Text = "Remover Produto";
            this.buttonRemoverProduto.UseVisualStyleBackColor = true;
            this.buttonRemoverProduto.Click += new System.EventHandler(this.buttonRemoverProduto_Click);
            // 
            // dataGridViewProdutos
            // 
            this.dataGridViewProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProdutos.Location = new System.Drawing.Point(12, 303);
            this.dataGridViewProdutos.Name = "dataGridViewProdutos";
            this.dataGridViewProdutos.RowTemplate.Height = 24;
            this.dataGridViewProdutos.Size = new System.Drawing.Size(725, 251);
            this.dataGridViewProdutos.TabIndex = 2;
            // 
            // buttonFinalizarVenda
            // 
            this.buttonFinalizarVenda.Location = new System.Drawing.Point(340, 560);
            this.buttonFinalizarVenda.Name = "buttonFinalizarVenda";
            this.buttonFinalizarVenda.Size = new System.Drawing.Size(158, 37);
            this.buttonFinalizarVenda.TabIndex = 12;
            this.buttonFinalizarVenda.Text = "Finalizar Venda";
            this.buttonFinalizarVenda.UseVisualStyleBackColor = true;
            this.buttonFinalizarVenda.Click += new System.EventHandler(this.buttonFinalizarVenda_Click);
            // 
            // buttonCancelarVenda
            // 
            this.buttonCancelarVenda.Location = new System.Drawing.Point(176, 560);
            this.buttonCancelarVenda.Name = "buttonCancelarVenda";
            this.buttonCancelarVenda.Size = new System.Drawing.Size(158, 37);
            this.buttonCancelarVenda.TabIndex = 13;
            this.buttonCancelarVenda.Text = "Cancelar Venda";
            this.buttonCancelarVenda.UseVisualStyleBackColor = true;
            this.buttonCancelarVenda.Click += new System.EventHandler(this.buttonCancelarVenda_Click);
            // 
            // buttonNovaVenda
            // 
            this.buttonNovaVenda.Location = new System.Drawing.Point(12, 560);
            this.buttonNovaVenda.Name = "buttonNovaVenda";
            this.buttonNovaVenda.Size = new System.Drawing.Size(158, 37);
            this.buttonNovaVenda.TabIndex = 14;
            this.buttonNovaVenda.Text = "Nova Venda";
            this.buttonNovaVenda.UseVisualStyleBackColor = true;
            this.buttonNovaVenda.Click += new System.EventHandler(this.buttonNovaVenda_Click);
            // 
            // FormVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(749, 607);
            this.Controls.Add(this.buttonNovaVenda);
            this.Controls.Add(this.buttonCancelarVenda);
            this.Controls.Add(this.buttonFinalizarVenda);
            this.Controls.Add(this.dataGridViewProdutos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de Vendas";
            this.Load += new System.EventHandler(this.FormVenda_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataVenda;
        private System.Windows.Forms.TextBox textBoxCliente;
        private System.Windows.Forms.TextBox textBoxFuncionario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRemoverProduto;
        private System.Windows.Forms.Button buttonAdicionarProduto;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxProduto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewProdutos;
        private System.Windows.Forms.Button buttonFinalizarVenda;
        private System.Windows.Forms.Button buttonCancelarVenda;
        private System.Windows.Forms.Button buttonNovaVenda;
    }
}