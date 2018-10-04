namespace GSSystem.Dialog {
    partial class EntradaDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxJogo = new System.Windows.Forms.ComboBox();
            this.gSSystemDataSet_Jogo = new GSSystem.GSSystemDataSet_Jogo();
            this.jogoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jogoTableAdapter = new GSSystem.GSSystemDataSet_JogoTableAdapters.JogoTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Jogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(12, 103);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(252, 20);
            this.txtQuantidade.TabIndex = 5;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quantidade";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(189, 158);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Produto";
            // 
            // cbxJogo
            // 
            this.cbxJogo.DataSource = this.jogoBindingSource;
            this.cbxJogo.DisplayMember = "titulo";
            this.cbxJogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJogo.FormattingEnabled = true;
            this.cbxJogo.Location = new System.Drawing.Point(12, 36);
            this.cbxJogo.Name = "cbxJogo";
            this.cbxJogo.Size = new System.Drawing.Size(252, 21);
            this.cbxJogo.TabIndex = 7;
            this.cbxJogo.ValueMember = "jogo_ID";
            // 
            // gSSystemDataSet_Jogo
            // 
            this.gSSystemDataSet_Jogo.DataSetName = "GSSystemDataSet_Jogo";
            this.gSSystemDataSet_Jogo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jogoBindingSource
            // 
            this.jogoBindingSource.DataMember = "Jogo";
            this.jogoBindingSource.DataSource = this.gSSystemDataSet_Jogo;
            // 
            // jogoTableAdapter
            // 
            this.jogoTableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EntradaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 193);
            this.Controls.Add(this.cbxJogo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EntradaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada de Estoque";
            this.Load += new System.EventHandler(this.EntradaDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Jogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxJogo;
        private GSSystemDataSet_Jogo gSSystemDataSet_Jogo;
        private System.Windows.Forms.BindingSource jogoBindingSource;
        private GSSystemDataSet_JogoTableAdapters.JogoTableAdapter jogoTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}