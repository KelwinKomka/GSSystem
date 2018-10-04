namespace GSSystem.Entry {
    partial class PlataformaEntry {
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
            this.btnAlterar = new System.Windows.Forms.Button();
            this.dtgJogoPlataforma = new System.Windows.Forms.DataGridView();
            this.dtgPlataforma = new System.Windows.Forms.DataGridView();
            this.plataformaIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jogoPlataformaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gSSystemDataSet_Plataforma = new GSSystem.GSSystemDataSet_Plataforma();
            this.plataformaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plataformaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.plataformaTableAdapter = new GSSystem.GSSystemDataSet_PlataformaTableAdapters.PlataformaTableAdapter();
            this.jogoPlataformaTableAdapter = new GSSystem.GSSystemDataSet_PlataformaTableAdapters.JogoPlataformaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtgJogoPlataforma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlataforma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogoPlataformaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Plataforma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plataformaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(411, 251);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 7;
            this.btnAlterar.Text = "Adicionar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // dtgJogoPlataforma
            // 
            this.dtgJogoPlataforma.AllowUserToAddRows = false;
            this.dtgJogoPlataforma.AllowUserToDeleteRows = false;
            this.dtgJogoPlataforma.AllowUserToOrderColumns = true;
            this.dtgJogoPlataforma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgJogoPlataforma.AutoGenerateColumns = false;
            this.dtgJogoPlataforma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgJogoPlataforma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.plataformaIDDataGridViewTextBoxColumn1,
            this.nomeDataGridViewTextBoxColumn1});
            this.dtgJogoPlataforma.DataSource = this.jogoPlataformaBindingSource;
            this.dtgJogoPlataforma.Location = new System.Drawing.Point(492, 12);
            this.dtgJogoPlataforma.Name = "dtgJogoPlataforma";
            this.dtgJogoPlataforma.ReadOnly = true;
            this.dtgJogoPlataforma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgJogoPlataforma.Size = new System.Drawing.Size(374, 511);
            this.dtgJogoPlataforma.TabIndex = 6;
            this.dtgJogoPlataforma.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgJogoPlataforma_CellClick);
            // 
            // dtgPlataforma
            // 
            this.dtgPlataforma.AllowUserToAddRows = false;
            this.dtgPlataforma.AllowUserToDeleteRows = false;
            this.dtgPlataforma.AllowUserToOrderColumns = true;
            this.dtgPlataforma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgPlataforma.AutoGenerateColumns = false;
            this.dtgPlataforma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlataforma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.plataformaIDDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn});
            this.dtgPlataforma.DataSource = this.plataformaBindingSource;
            this.dtgPlataforma.Location = new System.Drawing.Point(12, 12);
            this.dtgPlataforma.Name = "dtgPlataforma";
            this.dtgPlataforma.ReadOnly = true;
            this.dtgPlataforma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlataforma.Size = new System.Drawing.Size(393, 511);
            this.dtgPlataforma.TabIndex = 5;
            this.dtgPlataforma.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPlataforma_CellClick);
            // 
            // plataformaIDDataGridViewTextBoxColumn1
            // 
            this.plataformaIDDataGridViewTextBoxColumn1.DataPropertyName = "plataforma_ID";
            this.plataformaIDDataGridViewTextBoxColumn1.HeaderText = "N° da Plataforma";
            this.plataformaIDDataGridViewTextBoxColumn1.Name = "plataformaIDDataGridViewTextBoxColumn1";
            this.plataformaIDDataGridViewTextBoxColumn1.ReadOnly = true;
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
            // jogoPlataformaBindingSource
            // 
            this.jogoPlataformaBindingSource.DataMember = "JogoPlataforma";
            this.jogoPlataformaBindingSource.DataSource = this.gSSystemDataSet_Plataforma;
            // 
            // gSSystemDataSet_Plataforma
            // 
            this.gSSystemDataSet_Plataforma.DataSetName = "GSSystemDataSet_Plataforma";
            this.gSSystemDataSet_Plataforma.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // plataformaIDDataGridViewTextBoxColumn
            // 
            this.plataformaIDDataGridViewTextBoxColumn.DataPropertyName = "plataforma_ID";
            this.plataformaIDDataGridViewTextBoxColumn.HeaderText = "N° da Plataforma";
            this.plataformaIDDataGridViewTextBoxColumn.Name = "plataformaIDDataGridViewTextBoxColumn";
            this.plataformaIDDataGridViewTextBoxColumn.ReadOnly = true;
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
            // plataformaBindingSource
            // 
            this.plataformaBindingSource.DataMember = "Plataforma";
            this.plataformaBindingSource.DataSource = this.gSSystemDataSet_Plataforma;
            // 
            // plataformaTableAdapter
            // 
            this.plataformaTableAdapter.ClearBeforeFill = true;
            // 
            // jogoPlataformaTableAdapter
            // 
            this.jogoPlataformaTableAdapter.ClearBeforeFill = true;
            // 
            // PlataformaEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 535);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.dtgJogoPlataforma);
            this.Controls.Add(this.dtgPlataforma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlataformaEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Plataforma para Jogo";
            this.Load += new System.EventHandler(this.PlataformaEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgJogoPlataforma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlataforma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jogoPlataformaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSSystemDataSet_Plataforma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plataformaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.DataGridView dtgJogoPlataforma;
        private System.Windows.Forms.DataGridView dtgPlataforma;
        private GSSystemDataSet_Plataforma gSSystemDataSet_Plataforma;
        private System.Windows.Forms.BindingSource plataformaBindingSource;
        private GSSystemDataSet_PlataformaTableAdapters.PlataformaTableAdapter plataformaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn plataformaIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource jogoPlataformaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn plataformaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private GSSystemDataSet_PlataformaTableAdapters.JogoPlataformaTableAdapter jogoPlataformaTableAdapter;
    }
}