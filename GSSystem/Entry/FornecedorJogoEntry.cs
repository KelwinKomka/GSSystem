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

namespace GSSystem.Entry {
    public partial class FornecedorJogoEntry : Form {
        private int jogoID;
        private long fornecedorID;
        private bool add;
        private SqlConnection conn = (SqlConnection)MainData.getNewConnection();

        public FornecedorJogoEntry(long jogoID) {
            InitializeComponent();
            this.jogoID = Convert.ToInt32(jogoID);
        }

        private void FornecedorJogoEntry_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Fornecedor.Fornecedor' table. You can move, or remove it, as needed.
            this.fornecedorTableAdapter.FillOrderByNome(this.gSSystemDataSet_Fornecedor.Fornecedor);
            this.fornecedorTableAdapter1.Fill(this.gSSystemDataSet_JogoFornecedor.Fornecedor, jogoID);
            add = true;
            fornecedorID = 0;
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            bool isOperationOK = true;
            SqlCommand comm;

            if (fornecedorID == 0) return;

            if (add) {

                comm = new SqlCommand("SELECT count(*) Counter FROM JogoFornecedor WHERE Fornecedor_ID = @Fornecedor_ID AND Jogo_ID = @Jogo_ID", conn);
                SqlDataReader reader;

                comm.Parameters.Add("@Fornecedor_ID", System.Data.SqlDbType.Int);
                comm.Parameters["@Fornecedor_ID"].Value = fornecedorID;

                comm.Parameters.Add("@Jogo_ID", System.Data.SqlDbType.Int);
                comm.Parameters["@Jogo_ID"].Value = jogoID;

                try {
                    try {
                        conn.Open();
                    } catch (Exception error) {
                        MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try {
                        reader = comm.ExecuteReader();
                        if (reader.Read()) {
                            int count = Convert.ToInt32(reader["Counter"].ToString());
                            if (count > 0) {
                                MessageBox.Show("O Jogo há possui este fornecedor!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        reader.Close();
                    } catch (Exception error) {
                        MessageBox.Show(error.Message, "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch { } finally {
                    conn.Close();
                }

                comm = new SqlCommand("INSERT INTO JogoFornecedor (Fornecedor_ID, Jogo_ID) " +
                                                "VALUES (@Fornecedor_ID, @Jogo_ID)", conn);
            } else {
                if ((fornecedorID == 0) ||
                    (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.No))
                    return;

                comm = new SqlCommand("DELETE FROM JogoFornecedor WHERE Fornecedor_ID = @Fornecedor_ID AND Jogo_ID = @Jogo_ID", conn);
                
            }

            comm.Parameters.Add("@Fornecedor_ID", System.Data.SqlDbType.Int);
            comm.Parameters["@Fornecedor_ID"].Value = fornecedorID;

            comm.Parameters.Add("@Jogo_ID", System.Data.SqlDbType.Int);
            comm.Parameters["@Jogo_ID"].Value = jogoID;

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
                    if (add)
                        MessageBox.Show("Fornecedor Adicionado!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Fornecedor Excluído!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    FornecedorJogoEntry_Load(sender, e);
                }
            }
        }

        private void dtgfornecedor_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            int RecSelec = Convert.ToInt32(dtgfornecedor.Rows[e.RowIndex].Cells[0].Value);
            fornecedorID = RecSelec;
            add = true;
            btnAlterar.Text = "Adicionar";
        }

        private void dtgJogoFornecedor_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            int RecSelec = Convert.ToInt32(dtgJogoFornecedor.Rows[e.RowIndex].Cells[0].Value);
            fornecedorID = RecSelec;
            add = false;
            btnAlterar.Text = "Remover";
        }
    }
}
