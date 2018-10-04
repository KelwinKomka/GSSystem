namespace GSSystem.Entry {
    partial class JogoEntry {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JogoEntry));
            this.pnSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cbxFiltro = new System.Windows.Forms.ComboBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.jogoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataLancamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classificacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distribuidoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produtoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jogoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gSSystemDataSet_Jogo = new GSSystem.GSSystemDataSet_Jogo();
            this.pnInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPlataforma = new System.Windows.Forms.Button();
            this.btnGenero = new System.Windows.Forms.Button();
            this.rtxtEspecificacao = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.txtProdutora = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDistribuidora = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassificacao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxGenero = new System.Windows.Forms.ComboBox();
            this.generoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gSSystemDataSet_Genero = new GSSystem.GSSystemDataSet_Genero();
            this.dtpLancamento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.jogoTableAdapter = new GSSystem.GSSystemDataSet_JogoTableAdapters.JogoTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.generoTableAdapter = new GSSystem.GSSystemDataSet_GeneroTableAdapters.GeneroTableAdapter();
            this.pnSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Jogo)).BeginInit();
            this.pnInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Genero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnSearch
            // 
            this.pnSearch.Controls.Add(this.btnSearch);
            this.pnSearch.Controls.Add(this.txtFiltro);
            this.pnSearch.Controls.Add(this.cbxFiltro);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSearch.Location = new System.Drawing.Point(0, 0);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(926, 38);
            this.pnSearch.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(835, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(138, 10);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(691, 20);
            this.txtFiltro.TabIndex = 1;
            // 
            // cbxFiltro
            // 
            this.cbxFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltro.FormattingEnabled = true;
            this.cbxFiltro.Items.AddRange(new object[] {
            "Título"});
            this.cbxFiltro.Location = new System.Drawing.Point(12, 10);
            this.cbxFiltro.Name = "cbxFiltro";
            this.cbxFiltro.Size = new System.Drawing.Size(120, 21);
            this.cbxFiltro.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jogoIDDataGridViewTextBoxColumn,
            this.tituloDataGridViewTextBoxColumn,
            this.precoDataGridViewTextBoxColumn,
            this.dataLancamentoDataGridViewTextBoxColumn,
            this.generoDataGridViewTextBoxColumn,
            this.classificacaoDataGridViewTextBoxColumn,
            this.distribuidoraDataGridViewTextBoxColumn,
            this.produtoraDataGridViewTextBoxColumn});
            this.dgvList.DataSource = this.jogoBindingSource;
            this.dgvList.Location = new System.Drawing.Point(0, 37);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(926, 744);
            this.dgvList.TabIndex = 13;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // jogoIDDataGridViewTextBoxColumn
            // 
            this.jogoIDDataGridViewTextBoxColumn.DataPropertyName = "jogo_ID";
            this.jogoIDDataGridViewTextBoxColumn.HeaderText = "N° do Jogo";
            this.jogoIDDataGridViewTextBoxColumn.Name = "jogoIDDataGridViewTextBoxColumn";
            this.jogoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.jogoIDDataGridViewTextBoxColumn.Width = 78;
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
            this.precoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.precoDataGridViewTextBoxColumn.DataPropertyName = "preco";
            this.precoDataGridViewTextBoxColumn.HeaderText = "Preço";
            this.precoDataGridViewTextBoxColumn.Name = "precoDataGridViewTextBoxColumn";
            this.precoDataGridViewTextBoxColumn.ReadOnly = true;
            this.precoDataGridViewTextBoxColumn.Width = 80;
            // 
            // dataLancamentoDataGridViewTextBoxColumn
            // 
            this.dataLancamentoDataGridViewTextBoxColumn.DataPropertyName = "dataLancamento";
            this.dataLancamentoDataGridViewTextBoxColumn.HeaderText = "Data de Lançamento";
            this.dataLancamentoDataGridViewTextBoxColumn.Name = "dataLancamentoDataGridViewTextBoxColumn";
            this.dataLancamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataLancamentoDataGridViewTextBoxColumn.Width = 121;
            // 
            // generoDataGridViewTextBoxColumn
            // 
            this.generoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.generoDataGridViewTextBoxColumn.DataPropertyName = "genero";
            this.generoDataGridViewTextBoxColumn.HeaderText = "Gênero";
            this.generoDataGridViewTextBoxColumn.Name = "generoDataGridViewTextBoxColumn";
            this.generoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // classificacaoDataGridViewTextBoxColumn
            // 
            this.classificacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.classificacaoDataGridViewTextBoxColumn.DataPropertyName = "classificacao";
            this.classificacaoDataGridViewTextBoxColumn.HeaderText = "Classificação";
            this.classificacaoDataGridViewTextBoxColumn.Name = "classificacaoDataGridViewTextBoxColumn";
            this.classificacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // distribuidoraDataGridViewTextBoxColumn
            // 
            this.distribuidoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.distribuidoraDataGridViewTextBoxColumn.DataPropertyName = "distribuidora";
            this.distribuidoraDataGridViewTextBoxColumn.HeaderText = "Distribuidora";
            this.distribuidoraDataGridViewTextBoxColumn.Name = "distribuidoraDataGridViewTextBoxColumn";
            this.distribuidoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // produtoraDataGridViewTextBoxColumn
            // 
            this.produtoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.produtoraDataGridViewTextBoxColumn.DataPropertyName = "produtora";
            this.produtoraDataGridViewTextBoxColumn.HeaderText = "Produtora";
            this.produtoraDataGridViewTextBoxColumn.Name = "produtoraDataGridViewTextBoxColumn";
            this.produtoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jogoBindingSource
            // 
            this.jogoBindingSource.DataMember = "Jogo";
            this.jogoBindingSource.DataSource = this.gSSystemDataSet_Jogo;
            // 
            // gSSystemDataSet_Jogo
            // 
            this.gSSystemDataSet_Jogo.DataSetName = "GSSystemDataSet_Jogo";
            this.gSSystemDataSet_Jogo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnInfo
            // 
            this.pnInfo.Controls.Add(this.panel1);
            this.pnInfo.Controls.Add(this.txtEstoque);
            this.pnInfo.Controls.Add(this.label8);
            this.pnInfo.Controls.Add(this.btnPlataforma);
            this.pnInfo.Controls.Add(this.btnGenero);
            this.pnInfo.Controls.Add(this.rtxtEspecificacao);
            this.pnInfo.Controls.Add(this.label7);
            this.pnInfo.Controls.Add(this.btnFornecedor);
            this.pnInfo.Controls.Add(this.txtProdutora);
            this.pnInfo.Controls.Add(this.label6);
            this.pnInfo.Controls.Add(this.txtDistribuidora);
            this.pnInfo.Controls.Add(this.label1);
            this.pnInfo.Controls.Add(this.txtClassificacao);
            this.pnInfo.Controls.Add(this.label3);
            this.pnInfo.Controls.Add(this.cbxGenero);
            this.pnInfo.Controls.Add(this.dtpLancamento);
            this.pnInfo.Controls.Add(this.label4);
            this.pnInfo.Controls.Add(this.txtPreco);
            this.pnInfo.Controls.Add(this.txtTitulo);
            this.pnInfo.Controls.Add(this.label5);
            this.pnInfo.Controls.Add(this.label2);
            this.pnInfo.Controls.Add(this.lblNome);
            this.pnInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnInfo.Location = new System.Drawing.Point(926, 0);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(311, 781);
            this.pnInfo.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Location = new System.Drawing.Point(0, 732);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 49);
            this.panel1.TabIndex = 41;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(141, 14);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 19;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Location = new System.Drawing.Point(60, 14);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 18;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(224, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 17;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(166, 311);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(120, 20);
            this.txtEstoque.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Estoque";
            // 
            // btnPlataforma
            // 
            this.btnPlataforma.Location = new System.Drawing.Point(166, 358);
            this.btnPlataforma.Name = "btnPlataforma";
            this.btnPlataforma.Size = new System.Drawing.Size(120, 23);
            this.btnPlataforma.TabIndex = 38;
            this.btnPlataforma.Text = "Plataforma";
            this.btnPlataforma.UseVisualStyleBackColor = true;
            this.btnPlataforma.Click += new System.EventHandler(this.btnPlataforma_Click);
            // 
            // btnGenero
            // 
            this.btnGenero.Image = ((System.Drawing.Image)(resources.GetObject("btnGenero.Image")));
            this.btnGenero.Location = new System.Drawing.Point(260, 195);
            this.btnGenero.Name = "btnGenero";
            this.btnGenero.Size = new System.Drawing.Size(26, 23);
            this.btnGenero.TabIndex = 37;
            this.btnGenero.UseVisualStyleBackColor = true;
            this.btnGenero.Click += new System.EventHandler(this.btnGenero_Click);
            // 
            // rtxtEspecificacao
            // 
            this.rtxtEspecificacao.Location = new System.Drawing.Point(23, 415);
            this.rtxtEspecificacao.Name = "rtxtEspecificacao";
            this.rtxtEspecificacao.Size = new System.Drawing.Size(263, 234);
            this.rtxtEspecificacao.TabIndex = 36;
            this.rtxtEspecificacao.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Especificações";
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Location = new System.Drawing.Point(23, 358);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(125, 23);
            this.btnFornecedor.TabIndex = 34;
            this.btnFornecedor.Text = "Fornecedor";
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // txtProdutora
            // 
            this.txtProdutora.Location = new System.Drawing.Point(23, 311);
            this.txtProdutora.Name = "txtProdutora";
            this.txtProdutora.Size = new System.Drawing.Size(125, 20);
            this.txtProdutora.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Produtora";
            // 
            // txtDistribuidora
            // 
            this.txtDistribuidora.Location = new System.Drawing.Point(166, 254);
            this.txtDistribuidora.Name = "txtDistribuidora";
            this.txtDistribuidora.Size = new System.Drawing.Size(120, 20);
            this.txtDistribuidora.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Distribuidora";
            // 
            // txtClassificacao
            // 
            this.txtClassificacao.Location = new System.Drawing.Point(23, 254);
            this.txtClassificacao.Name = "txtClassificacao";
            this.txtClassificacao.Size = new System.Drawing.Size(125, 20);
            this.txtClassificacao.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Classificação";
            // 
            // cbxGenero
            // 
            this.cbxGenero.DataSource = this.generoBindingSource;
            this.cbxGenero.DisplayMember = "nome";
            this.cbxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGenero.FormattingEnabled = true;
            this.cbxGenero.Location = new System.Drawing.Point(23, 197);
            this.cbxGenero.Name = "cbxGenero";
            this.cbxGenero.Size = new System.Drawing.Size(213, 21);
            this.cbxGenero.TabIndex = 27;
            this.cbxGenero.ValueMember = "genero_ID";
            // 
            // generoBindingSource
            // 
            this.generoBindingSource.DataMember = "Genero";
            this.generoBindingSource.DataSource = this.gSSystemDataSet_Genero;
            // 
            // gSSystemDataSet_Genero
            // 
            this.gSSystemDataSet_Genero.DataSetName = "GSSystemDataSet_Genero";
            this.gSSystemDataSet_Genero.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpLancamento
            // 
            this.dtpLancamento.Location = new System.Drawing.Point(23, 143);
            this.dtpLancamento.Name = "dtpLancamento";
            this.dtpLancamento.Size = new System.Drawing.Size(263, 20);
            this.dtpLancamento.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Data de Lançamento";
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(23, 85);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(263, 20);
            this.txtPreco.TabIndex = 8;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(23, 29);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(263, 20);
            this.txtTitulo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gênero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Preço (R$)";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 13);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Título";
            // 
            // jogoTableAdapter
            // 
            this.jogoTableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // generoTableAdapter
            // 
            this.generoTableAdapter.ClearBeforeFill = true;
            // 
            // JogoEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 781);
            this.Controls.Add(this.pnSearch);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.pnInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JogoEntry";
            this.Text = "JogoEntry";
            this.Load += new System.EventHandler(this.JogoEntry_Load);
            this.pnSearch.ResumeLayout(false);
            this.pnSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Jogo)).EndInit();
            this.pnInfo.ResumeLayout(false);
            this.pnInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.generoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Genero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cbxFiltro;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.DateTimePicker dtpLancamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.RichTextBox rtxtEspecificacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.TextBox txtProdutora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDistribuidora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassificacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxGenero;
        private GSSystemDataSet_Jogo gSSystemDataSet_Jogo;
        private System.Windows.Forms.BindingSource jogoBindingSource;
        private GSSystemDataSet_JogoTableAdapters.JogoTableAdapter jogoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn jogoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataLancamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classificacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distribuidoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produtoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnGenero;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private GSSystemDataSet_Genero gSSystemDataSet_Genero;
        private System.Windows.Forms.BindingSource generoBindingSource;
        private GSSystemDataSet_GeneroTableAdapters.GeneroTableAdapter generoTableAdapter;
        private System.Windows.Forms.Button btnPlataforma;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
    }
}