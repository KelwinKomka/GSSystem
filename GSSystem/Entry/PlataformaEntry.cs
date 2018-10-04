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
    public partial class PlataformaEntry : Form {
        private int jogoID;
        private long plataformaID;
        private bool add;
        private SqlConnection conn = (SqlConnection)MainData.getNewConnection();

        public PlataformaEntry(long jogoID) {
            InitializeComponent();
            this.jogoID = Convert.ToInt32(jogoID);
        }

        private void PlataformaEntry_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Plataforma.Plataforma' table. You can move, or remove it, as needed.
            this.plataformaTableAdapter.Fill(this.gSSystemDataSet_Plataforma.Plataforma);
            this.jogoPlataformaTableAdapter.FillJogoPlataforma(this.gSSystemDataSet_Plataforma.JogoPlataforma, jogoID);
            add = true;
            plataformaID = 0;
        }

        private void dtgPlataforma_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            int RecSelec = Convert.ToInt32(dtgPlataforma.Rows[e.RowIndex].Cells[0].Value);
            plataformaID = RecSelec;
            add = true;
            btnAlterar.Text = "Adicionar";
        }

        private void dtgJogoPlataforma_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            int RecSelec = Convert.ToInt32(dtgJogoPlataforma.Rows[e.RowIndex].Cells[0].Value);
            plataformaID = RecSelec;
            add = false;
            btnAlterar.Text = "Remover";
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            bool isOperationOK = true;
            SqlCommand comm;

            if (plataformaID == 0) return;

            if (add) {

                comm = new SqlCommand("SELECT count(*) Counter FROM JogoPlataforma WHERE Plataforma_ID = @Plataforma_ID AND Jogo_ID = @Jogo_ID", conn);
                SqlDataReader reader;

                comm.Parameters.Add("@Plataforma_ID", System.Data.SqlDbType.Int);
                comm.Parameters["@Plataforma_ID"].Value = plataformaID;

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
                                MessageBox.Show("O Jogo há possui esta plataforma!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                comm = new SqlCommand("INSERT INTO JogoPlataforma (Plataforma_ID, Jogo_ID) " +
                                                "VALUES (@Plataforma_ID, @Jogo_ID)", conn);
            } else {
                if ((plataformaID == 0) ||
                    (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.No))
                    return;

                comm = new SqlCommand("DELETE FROM JogoPlataforma WHERE Plataforma_ID = @Plataforma_ID AND Jogo_ID = @Jogo_ID", conn);

            }

            comm.Parameters.Add("@Plataforma_ID", System.Data.SqlDbType.Int);
            comm.Parameters["@Plataforma_ID"].Value = plataformaID;

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
                        MessageBox.Show("Plataforma Adicionada!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Plataforma Excluída!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    PlataformaEntry_Load(sender, e);
                }
            }
        }
    }
}
