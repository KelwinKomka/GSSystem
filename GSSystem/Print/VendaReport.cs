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
    public partial class VendaReport : Form {
        public VendaReport() {
            InitializeComponent();
        }

        private void VendaReport_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Venda.VendaRelatorio' table. You can move, or remove it, as needed.
            this.vendaRelatorioTableAdapter.Fill(this.gSSystemDataSet_Venda.VendaRelatorio);

            this.reportViewer1.RefreshReport();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) {
            if (txtFiltro.Text.Trim().Length > 0) {
                if (cbxFiltro.SelectedIndex == 0)
                    this.vendaRelatorioTableAdapter.FillByCliente(this.gSSystemDataSet_Venda.VendaRelatorio, "%" + txtFiltro.Text + "%");
                else if (cbxFiltro.SelectedIndex == 1)
                    this.vendaRelatorioTableAdapter.FillByFuncionario(this.gSSystemDataSet_Venda.VendaRelatorio, "%" + txtFiltro.Text + "%");
            } else
                this.vendaRelatorioTableAdapter.Fill(this.gSSystemDataSet_Venda.VendaRelatorio);
            this.reportViewer1.RefreshReport();
        }
    }
}
