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
    public partial class JogoReport : Form {
        public JogoReport() {
            InitializeComponent();
        }

        private void JogoReport_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Jogo.JogoRelatorio' table. You can move, or remove it, as needed.
            this.jogoRelatorioTableAdapter.Fill(this.gSSystemDataSet_Jogo.JogoRelatorio);

            this.reportViewer1.RefreshReport();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) {
            if (txtFiltro.Text.Trim().Length > 0) {
                if (cbxFiltro.SelectedIndex == 0)
                    this.jogoRelatorioTableAdapter.FillByTitulo(this.gSSystemDataSet_Jogo.JogoRelatorio, "%" + txtFiltro.Text + "%");
                else if (cbxFiltro.SelectedIndex == 1) 
                    this.jogoRelatorioTableAdapter.FillByGenero(this.gSSystemDataSet_Jogo.JogoRelatorio, "%" + txtFiltro.Text + "%");
                else if (cbxFiltro.SelectedIndex == 2) 
                    this.jogoRelatorioTableAdapter.FillByFornecedor(this.gSSystemDataSet_Jogo.JogoRelatorio, "%" + txtFiltro.Text + "%");
                else 
                    this.jogoRelatorioTableAdapter.FillByPlataforma(this.gSSystemDataSet_Jogo.JogoRelatorio, "%" + txtFiltro.Text + "%");
            } else
                this.jogoRelatorioTableAdapter.Fill(this.gSSystemDataSet_Jogo.JogoRelatorio);
            this.reportViewer1.RefreshReport();
        }
    }
}
