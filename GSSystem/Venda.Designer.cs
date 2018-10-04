namespace GSSystem {
    partial class Venda {
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
            this.gSSystemDataSet_Cliente = new GSSystem.GSSystemDataSet_Cliente();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clienteTableAdapter = new GSSystem.GSSystemDataSet_ClienteTableAdapters.ClienteTableAdapter();
            this.gSSystemDataSet_Jogo = new GSSystem.GSSystemDataSet_Jogo();
            this.jogoEstoqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jogoEstoqueTableAdapter = new GSSystem.GSSystemDataSet_JogoTableAdapters.JogoEstoqueTableAdapter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.chbxAluguel = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgCarrinho = new System.Windows.Forms.DataGridView();
            this.jogoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgJogos = new System.Windows.Forms.DataGridView();
            this.jogoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Jogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogoEstoqueBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarrinho)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgJogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gSSystemDataSet_Cliente
            // 
            this.gSSystemDataSet_Cliente.DataSetName = "GSSystemDataSet_Cliente";
            this.gSSystemDataSet_Cliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "Cliente";
            this.clienteBindingSource.DataSource = this.gSSystemDataSet_Cliente;
            // 
            // clienteTableAdapter
            // 
            this.clienteTableAdapter.ClearBeforeFill = true;
            // 
            // gSSystemDataSet_Jogo
            // 
            this.gSSystemDataSet_Jogo.DataSetName = "GSSystemDataSet_Jogo";
            this.gSSystemDataSet_Jogo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jogoEstoqueBindingSource
            // 
            this.jogoEstoqueBindingSource.DataMember = "JogoEstoque";
            this.jogoEstoqueBindingSource.DataSource = this.gSSystemDataSet_Jogo;
            // 
            // jogoEstoqueTableAdapter
            // 
            this.jogoEstoqueTableAdapter.ClearBeforeFill = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblValor);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dtpData);
            this.panel4.Controls.Add(this.cbxCliente);
            this.panel4.Controls.Add(this.chbxAluguel);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1219, 171);
            this.panel4.TabIndex = 16;
            // 
            // dtpData
            // 
            this.dtpData.Enabled = false;
            this.dtpData.Location = new System.Drawing.Point(31, 104);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(264, 20);
            this.dtpData.TabIndex = 12;
            // 
            // cbxCliente
            // 
            this.cbxCliente.DataSource = this.clienteBindingSource;
            this.cbxCliente.DisplayMember = "nome";
            this.cbxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(31, 52);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(266, 21);
            this.cbxCliente.TabIndex = 11;
            this.cbxCliente.ValueMember = "cliente_ID";
            // 
            // chbxAluguel
            // 
            this.chbxAluguel.AutoSize = true;
            this.chbxAluguel.Location = new System.Drawing.Point(384, 107);
            this.chbxAluguel.Name = "chbxAluguel";
            this.chbxAluguel.Size = new System.Drawing.Size(68, 17);
            this.chbxAluguel.TabIndex = 10;
            this.chbxAluguel.Text = "Locação";
            this.chbxAluguel.UseVisualStyleBackColor = true;
            this.chbxAluguel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cliente";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnCancelar);
            this.panel5.Controls.Add(this.btnFinalizar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 771);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1219, 47);
            this.panel5.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(1051, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.Location = new System.Drawing.Point(1132, 12);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 12;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 171);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1219, 600);
            this.panel6.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.btnAlterar);
            this.panel3.Location = new System.Drawing.Point(587, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(75, 24);
            this.panel3.TabIndex = 18;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(0, 0);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 13;
            this.btnAlterar.Text = "Adicionar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.dtgCarrinho);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(668, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(551, 586);
            this.panel2.TabIndex = 17;
            // 
            // dtgCarrinho
            // 
            this.dtgCarrinho.AllowUserToAddRows = false;
            this.dtgCarrinho.AllowUserToDeleteRows = false;
            this.dtgCarrinho.AllowUserToOrderColumns = true;
            this.dtgCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgCarrinho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCarrinho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jogoID,
            this.titulo,
            this.quantidade});
            this.dtgCarrinho.Location = new System.Drawing.Point(16, 32);
            this.dtgCarrinho.Name = "dtgCarrinho";
            this.dtgCarrinho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCarrinho.Size = new System.Drawing.Size(523, 540);
            this.dtgCarrinho.TabIndex = 11;
            this.dtgCarrinho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCarrinho_CellClick);
            // 
            // jogoID
            // 
            this.jogoID.DataPropertyName = "jogoID";
            this.jogoID.HeaderText = "N° do Jogo";
            this.jogoID.Name = "jogoID";
            this.jogoID.ReadOnly = true;
            // 
            // titulo
            // 
            this.titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.titulo.DataPropertyName = "titulo";
            this.titulo.FillWeight = 200F;
            this.titulo.HeaderText = "Título";
            this.titulo.Name = "titulo";
            this.titulo.ReadOnly = true;
            this.titulo.Width = 200;
            // 
            // quantidade
            // 
            this.quantidade.DataPropertyName = "quantidade";
            this.quantidade.HeaderText = "Quantidade";
            this.quantidade.Name = "quantidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Carrinho";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.dtgJogos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 586);
            this.panel1.TabIndex = 16;
            // 
            // dtgJogos
            // 
            this.dtgJogos.AllowUserToAddRows = false;
            this.dtgJogos.AllowUserToDeleteRows = false;
            this.dtgJogos.AllowUserToOrderColumns = true;
            this.dtgJogos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgJogos.AutoGenerateColumns = false;
            this.dtgJogos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgJogos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jogoIDDataGridViewTextBoxColumn,
            this.tituloDataGridViewTextBoxColumn,
            this.precoDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn});
            this.dtgJogos.DataSource = this.jogoEstoqueBindingSource;
            this.dtgJogos.Location = new System.Drawing.Point(19, 32);
            this.dtgJogos.Name = "dtgJogos";
            this.dtgJogos.ReadOnly = true;
            this.dtgJogos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgJogos.Size = new System.Drawing.Size(547, 540);
            this.dtgJogos.TabIndex = 10;
            this.dtgJogos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgJogos_CellClick);
            // 
            // jogoIDDataGridViewTextBoxColumn
            // 
            this.jogoIDDataGridViewTextBoxColumn.DataPropertyName = "jogo_ID";
            this.jogoIDDataGridViewTextBoxColumn.HeaderText = "N° do Jogo";
            this.jogoIDDataGridViewTextBoxColumn.Name = "jogoIDDataGridViewTextBoxColumn";
            this.jogoIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            this.tituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tituloDataGridViewTextBoxColumn.DataPropertyName = "titulo";
            this.tituloDataGridViewTextBoxColumn.FillWeight = 200F;
            this.tituloDataGridViewTextBoxColumn.HeaderText = "Título";
            this.tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            this.tituloDataGridViewTextBoxColumn.ReadOnly = true;
            this.tituloDataGridViewTextBoxColumn.Width = 200;
            // 
            // precoDataGridViewTextBoxColumn
            // 
            this.precoDataGridViewTextBoxColumn.DataPropertyName = "preco";
            this.precoDataGridViewTextBoxColumn.HeaderText = "Preço";
            this.precoDataGridViewTextBoxColumn.Name = "precoDataGridViewTextBoxColumn";
            this.precoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Estoque";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Jogos";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1055, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 51);
            this.label3.TabIndex = 13;
            this.label3.Text = "Venda";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(810, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(252, 36);
            this.label6.TabIndex = 14;
            this.label6.Text = "Valor Total (R$):";
            // 
            // lblValor
            // 
            this.lblValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(1068, 117);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(74, 36);
            this.lblValor.TabIndex = 15;
            this.lblValor.Text = "0.00";
            // 
            // Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 818);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Venda";
            this.Text = "Venda";
            this.Load += new System.EventHandler(this.Venda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Jogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogoEstoqueBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarrinho)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgJogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private GSSystemDataSet_Cliente gSSystemDataSet_Cliente;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private GSSystemDataSet_ClienteTableAdapters.ClienteTableAdapter clienteTableAdapter;
        private GSSystemDataSet_Jogo gSSystemDataSet_Jogo;
        private System.Windows.Forms.BindingSource jogoEstoqueBindingSource;
        private GSSystemDataSet_JogoTableAdapters.JogoEstoqueTableAdapter jogoEstoqueTableAdapter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.CheckBox chbxAluguel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgJogos;
        private System.Windows.Forms.DataGridViewTextBoxColumn jogoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgCarrinho;
        private System.Windows.Forms.DataGridViewTextBoxColumn jogoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}