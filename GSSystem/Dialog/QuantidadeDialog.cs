using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSSystem.Dialog {
    public partial class QuantidadeDialog : Form {
        public int quantidade;
        private int maxquantidade;

        public QuantidadeDialog(int max) {
            InitializeComponent();
            maxquantidade = max;
        }

        private void txtQuantidade_Leave(object sender, EventArgs e) {
            if (int.TryParse(txtQuantidade.Text, out quantidade)) {
                quantidade = Convert.ToInt32(txtQuantidade.Text);
                if (quantidade > maxquantidade) {
                    MessageBox.Show("A quantidade não pode ultrapassar o máximo do estoque!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    quantidade = 0;
                    txtQuantidade.Focus();
                }
            } else {
                MessageBox.Show("O campo quantidade deve ser preenchido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQuantidade.Focus();
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e) {
            btnOK.Enabled = txtQuantidade.Text.Trim().Length > 0;
        }
    }
}
