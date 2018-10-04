using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSSystem.Dialog {
    public partial class EntradaDialog : Form {
        private SqlConnection conn = (SqlConnection) MainData.getNewConnection();

        public EntradaDialog() {
            InitializeComponent();
        }

        private void EntradaDialog_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Jogo.Jogo' table. You can move, or remove it, as needed.
            this.jogoTableAdapter.Fill(this.gSSystemDataSet_Jogo.Jogo);

        }

        private void btnOK_Click(object sender, EventArgs e) {
            int quantidade;

            if (cbxJogo.SelectedIndex < 0) {
                errorProvider1.SetError(cbxJogo, "O jogo deve estar selecionado!");
                return;
            }

            if (int.TryParse(txtQuantidade.Text, out quantidade)) {
                bool isOperationOK = true;
                SqlCommand comm;

                quantidade = Convert.ToInt32(txtQuantidade.Text);

                comm = new SqlCommand("UPDATE Estoque SET Quantidade = Quantidade + @Quantidade WHERE Jogo_ID = @Codigo", conn);

                comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
                comm.Parameters["@Codigo"].Value = cbxJogo.SelectedValue;

                comm.Parameters.Add("@Quantidade", System.Data.SqlDbType.Int);
                comm.Parameters["@Quantidade"].Value = quantidade;

                try {
                    try {
                        conn.Open();
                    } catch (Exception error) {
                        isOperationOK = false;
                        MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try {
                        comm.ExecuteNonQuery();
                    } catch (Exception error) {
                        isOperationOK = false;
                        MessageBox.Show(error.Message, "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch {
                } finally {
                    conn.Close();

                    if (isOperationOK) {
                        MessageBox.Show("Estoque alterado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                        txtQuantidade.Text = "";
                    }
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
