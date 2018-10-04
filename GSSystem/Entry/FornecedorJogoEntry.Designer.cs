namespace GSSystem.Entry {
    partial class FornecedorJogoEntry {
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
            this.dtgfornecedor = new System.Windows.Forms.DataGridView();
            this.dtgJogoFornecedor = new System.Windows.Forms.DataGridView();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.fornecedorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gSSystemDataSet_Fornecedor = new GSSystem.GSSystemDataSet_Fornecedor();
            this.fornecedorTableAdapter = new GSSystem.GSSystemDataSet_FornecedorTableAdapters.FornecedorTableAdapter();
            this.gSSystemDataSet_JogoFornecedor = new GSSystem.GSSystemDataSet_JogoFornecedor();
            this.fornecedorBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fornecedorTableAdapter1 = new GSSystem.GSSystemDataSet_JogoFornecedorTableAdapters.FornecedorTableAdapter();
            this.fornecedorIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgfornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgJogoFornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Fornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_JogoFornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgfornecedor
            // 
            this.dtgfornecedor.AllowUserToAddRows = false;
            this.dtgfornecedor.AllowUserToDeleteRows = false;
            this.dtgfornecedor.AllowUserToOrderColumns = true;
            this.dtgfornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgfornecedor.AutoGenerateColumns = false;
            this.dtgfornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgfornecedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fornecedorIDDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn});
            this.dtgfornecedor.DataSource = this.fornecedorBindingSource;
            this.dtgfornecedor.Location = new System.Drawing.Point(12, 12);
            this.dtgfornecedor.Name = "dtgfornecedor";
            this.dtgfornecedor.ReadOnly = true;
            this.dtgfornecedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgfornecedor.Size = new System.Drawing.Size(465, 529);
            this.dtgfornecedor.TabIndex = 1;
            this.dtgfornecedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgfornecedor_CellClick);
            // 
            // dtgJogoFornecedor
            // 
            this.dtgJogoFornecedor.AllowUserToAddRows = false;
            this.dtgJogoFornecedor.AllowUserToDeleteRows = false;
            this.dtgJogoFornecedor.AllowUserToOrderColumns = true;
            this.dtgJogoFornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgJogoFornecedor.AutoGenerateColumns = false;
            this.dtgJogoFornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgJogoFornecedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fornecedorIDDataGridViewTextBoxColumn1,
            this.nomeDataGridViewTextBoxColumn1});
            this.dtgJogoFornecedor.DataSource = this.fornecedorBindingSource1;
            this.dtgJogoFornecedor.Location = new System.Drawing.Point(564, 12);
            this.dtgJogoFornecedor.Name = "dtgJogoFornecedor";
            this.dtgJogoFornecedor.ReadOnly = true;
            this.dtgJogoFornecedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgJogoFornecedor.Size = new System.Drawing.Size(449, 529);
            this.dtgJogoFornecedor.TabIndex = 2;
            this.dtgJogoFornecedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgJogoFornecedor_CellClick);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(483, 246);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 4;
            this.btnAlterar.Text = "Adicionar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // fornecedorIDDataGridViewTextBoxColumn
            // 
            this.fornecedorIDDataGridViewTextBoxColumn.DataPropertyName = "fornecedor_ID";
            this.fornecedorIDDataGridViewTextBoxColumn.HeaderText = "N° do Fornecedor";
            this.fornecedorIDDataGridViewTextBoxColumn.Name = "fornecedorIDDataGridViewTextBoxColumn";
            this.fornecedorIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn.FillWeight = 200F;
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn.Width = 200;
            // 
            // fornecedorBindingSource
            // 
            this.fornecedorBindingSource.DataMember = "Fornecedor";
            this.fornecedorBindingSource.DataSource = this.gSSystemDataSet_Fornecedor;
            // 
            // gSSystemDataSet_Fornecedor
            // 
            this.gSSystemDataSet_Fornecedor.DataSetName = "GSSystemDataSet_Fornecedor";
            this.gSSystemDataSet_Fornecedor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fornecedorTableAdapter
            // 
            this.fornecedorTableAdapter.ClearBeforeFill = true;
            // 
            // gSSystemDataSet_JogoFornecedor
            // 
            this.gSSystemDataSet_JogoFornecedor.DataSetName = "GSSystemDataSet_JogoFornecedor";
            this.gSSystemDataSet_JogoFornecedor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fornecedorBindingSource1
            // 
            this.fornecedorBindingSource1.DataMember = "Fornecedor";
            this.fornecedorBindingSource1.DataSource = this.gSSystemDataSet_JogoFornecedor;
            // 
            // fornecedorTableAdapter1
            // 
            this.fornecedorTableAdapter1.ClearBeforeFill = true;
            // 
            // fornecedorIDDataGridViewTextBoxColumn1
            // 
            this.fornecedorIDDataGridViewTextBoxColumn1.DataPropertyName = "fornecedor_ID";
            this.fornecedorIDDataGridViewTextBoxColumn1.HeaderText = "N° do Fornecedor";
            this.fornecedorIDDataGridViewTextBoxColumn1.Name = "fornecedorIDDataGridViewTextBoxColumn1";
            this.fornecedorIDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn1
            // 
            this.nomeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nomeDataGridViewTextBoxColumn1.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn1.FillWeight = 200F;
            this.nomeDataGridViewTextBoxColumn1.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn1.Name = "nomeDataGridViewTextBoxColumn1";
            this.nomeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn1.Width = 200;
            // 
            // FornecedorJogoEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 553);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.dtgJogoFornecedor);
            this.Controls.Add(this.dtgfornecedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FornecedorJogoEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Fornecedor para Jogo";
            this.Load += new System.EventHandler(this.FornecedorJogoEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgfornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgJogoFornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Fornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_JogoFornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgfornecedor;
        private System.Windows.Forms.DataGridView dtgJogoFornecedor;
        private System.Windows.Forms.Button btnAlterar;
        private GSSystemDataSet_Fornecedor gSSystemDataSet_Fornecedor;
        private System.Windows.Forms.BindingSource fornecedorBindingSource;
        private GSSystemDataSet_FornecedorTableAdapters.FornecedorTableAdapter fornecedorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedorIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource fornecedorBindingSource1;
        private GSSystemDataSet_JogoFornecedor gSSystemDataSet_JogoFornecedor;
        private GSSystemDataSet_JogoFornecedorTableAdapters.FornecedorTableAdapter fornecedorTableAdapter1;
    }
}