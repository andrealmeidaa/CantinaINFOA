namespace GUICantina
{
    partial class FormFuncionario
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.dataGridViewFuncionario = new System.Windows.Forms.DataGridView();
            this.buttonNovo = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.textBoxIDFuncionario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuncionario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(77, 13);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(218, 20);
            this.textBoxNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Matrícula:";
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Location = new System.Drawing.Point(77, 47);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(100, 20);
            this.textBoxMatricula.TabIndex = 4;
            // 
            // dataGridViewFuncionario
            // 
            this.dataGridViewFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFuncionario.Location = new System.Drawing.Point(16, 107);
            this.dataGridViewFuncionario.Name = "dataGridViewFuncionario";
            this.dataGridViewFuncionario.Size = new System.Drawing.Size(382, 150);
            this.dataGridViewFuncionario.TabIndex = 5;
            this.dataGridViewFuncionario.SelectionChanged += new System.EventHandler(this.dataGridViewFuncionario_SelectionChanged);
            // 
            // buttonNovo
            // 
            this.buttonNovo.Location = new System.Drawing.Point(53, 78);
            this.buttonNovo.Name = "buttonNovo";
            this.buttonNovo.Size = new System.Drawing.Size(75, 23);
            this.buttonNovo.TabIndex = 6;
            this.buttonNovo.Text = "Novo";
            this.buttonNovo.UseVisualStyleBackColor = true;
            this.buttonNovo.Click += new System.EventHandler(this.buttonNovo_Click);
            // 
            // buttonGravar
            // 
            this.buttonGravar.Location = new System.Drawing.Point(170, 78);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 7;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(290, 78);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(75, 23);
            this.buttonExcluir.TabIndex = 8;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // textBoxIDFuncionario
            // 
            this.textBoxIDFuncionario.Location = new System.Drawing.Point(184, 46);
            this.textBoxIDFuncionario.Name = "textBoxIDFuncionario";
            this.textBoxIDFuncionario.Size = new System.Drawing.Size(100, 20);
            this.textBoxIDFuncionario.TabIndex = 9;
            this.textBoxIDFuncionario.Visible = false;
            // 
            // FormFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 269);
            this.Controls.Add(this.textBoxIDFuncionario);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.buttonNovo);
            this.Controls.Add(this.dataGridViewFuncionario);
            this.Controls.Add(this.textBoxMatricula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label1);
            this.Name = "FormFuncionario";
            this.Text = "Cadastro de Funcionários";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuncionario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.DataGridView dataGridViewFuncionario;
        private System.Windows.Forms.Button buttonNovo;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.TextBox textBoxIDFuncionario;
    }
}