using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSSystem.Print {
    public partial class EstoqueReport : Form {
        public EstoqueReport() {
            InitializeComponent();
        }

        private void EstoqueReport_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Estoque.Estoque' table. You can move, or remove it, as needed.
            this.estoqueTableAdapter.Fill(this.gSSystemDataSet_Estoque.Estoque);

            this.reportViewer1.RefreshReport();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) {
            if (txtFiltro.Text.Trim().Length > 0) {
                if (cbxFiltro.SelectedIndex == 0)
                    this.estoqueTableAdapter.FillByTitulo(this.gSSystemDataSet_Estoque.Estoque, "%" + txtFiltro.Text+ "%");
                else if (cbxFiltro.SelectedIndex == 1) 
                    this.estoqueTableAdapter.FillByFornecedor(this.gSSystemDataSet_Estoque.Estoque, "%" + txtFiltro.Text + "%");
                else
                    this.estoqueTableAdapter.FillByPlataforma(this.gSSystemDataSet_Estoque.Estoque, "%" + txtFiltro.Text + "%");
            } else
                this.estoqueTableAdapter.Fill(this.gSSystemDataSet_Estoque.Estoque);
            this.reportViewer1.RefreshReport();
        }
    }
}
