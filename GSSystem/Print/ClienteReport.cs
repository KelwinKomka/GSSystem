using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSSystem.Report {
    public partial class ClienteReport : Form {
        public ClienteReport() {
            InitializeComponent();
        }

        private void ClienteReport_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Cliente.Cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.FillOrderByNome(this.gSSystemDataSet_Cliente.Cliente);

            this.reportViewer1.RefreshReport();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) {
            if (txtFiltro.Text.Trim().Length > 0) {
                if (cbxFiltro.SelectedIndex == 0)
                    this.clienteTableAdapter.FillByNome(this.gSSystemDataSet_Cliente.Cliente, "%" + txtFiltro.Text + "%");
                else {
                    DateTime resultado = DateTime.MinValue;
                    if (DateTime.TryParse(this.txtFiltro.Text.Trim(), out resultado))
                        this.clienteTableAdapter.FillByData(this.gSSystemDataSet_Cliente.Cliente, txtFiltro.Text);
                }
            } else
                this.clienteTableAdapter.FillOrderByNome(this.gSSystemDataSet_Cliente.Cliente);
            this.reportViewer1.RefreshReport();
        }
    }
}
