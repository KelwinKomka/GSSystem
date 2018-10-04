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
    public partial class FuncionarioReport : Form {
        public FuncionarioReport() {
            InitializeComponent();
        }

        private void FuncionarioReport_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Funcionario.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.FillOrderByNome(this.gSSystemDataSet_Funcionario.Funcionario);

            this.reportViewer1.RefreshReport();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) {
            if (txtFiltro.Text.Trim().Length > 0) {
                if (cbxFiltro.SelectedIndex == 0)
                    this.funcionarioTableAdapter.FillByNome(this.gSSystemDataSet_Funcionario.Funcionario, "%" + txtFiltro.Text + "%");
                else if (cbxFiltro.SelectedIndex == 1) {
                    DateTime resultado = DateTime.MinValue;
                    if (DateTime.TryParse(this.txtFiltro.Text.Trim(), out resultado))
                        this.funcionarioTableAdapter.FillByData(this.gSSystemDataSet_Funcionario.Funcionario, txtFiltro.Text);
                } else if (cbxFiltro.SelectedIndex == 2) {
                    Decimal resultado = 0.0m;
                    if (Decimal.TryParse(this.txtFiltro.Text.Trim(), out resultado))
                        this.funcionarioTableAdapter.FillBySalarioMaior(this.gSSystemDataSet_Funcionario.Funcionario, Convert.ToDecimal(txtFiltro.Text));
                } else {
                    Decimal resultado = 0.0m;
                    if (Decimal.TryParse(this.txtFiltro.Text.Trim(), out resultado))
                        this.funcionarioTableAdapter.FillBySalarioMenor(this.gSSystemDataSet_Funcionario.Funcionario, Convert.ToDecimal(txtFiltro.Text));
                }
            } else
                this.funcionarioTableAdapter.FillOrderByNome(this.gSSystemDataSet_Funcionario.Funcionario);
            this.reportViewer1.RefreshReport();
        }
    }
}
