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
    public partial class CidadeEntry : Form {
        private long cidadeID;
        private SqlConnection conn = (SqlConnection) MainData.getNewConnection();

        public CidadeEntry() {
            InitializeComponent();
        }

        private void CidadeEntry_Load(object sender, EventArgs e) {
            this.cidadeTableAdapter.Fill(this.gSSystemDataSet_Cidade.Cidade);
            cidadeID = 0;
            btnExcluir.Enabled = false;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            int RecSelec = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);

            cidadeID = RecSelec;

            SqlDataReader reader;
            SqlCommand comm = new SqlCommand("SELECT Nome, Uf, Cep FROM Cidade WHERE cidade_ID = @Codigo", conn);

            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = cidadeID;
            
            try {
                try {
                    conn.Open();
                } catch (Exception error) {
                    MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try {
                    reader = comm.ExecuteReader();

                    if (reader.Read()) {
                        txtNome.Text = reader["Nome"].ToString();
                        cbxUF.SelectedIndex = cbxUF.Items.IndexOf(reader["Uf"].ToString());
                        msktxtCEP.Text = reader["Cep"].ToString();
                    }
                    reader.Close();
                } catch (Exception error) {
                    MessageBox.Show(error.Message, "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch { } finally {
                conn.Close();
                btnExcluir.Enabled = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            txtNome.Text = "";
            cbxUF.SelectedIndex = -1;
            msktxtCEP.Text = "";
            cidadeID = 0;
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            bool isOperationOK = true;

            if ((cidadeID == 0) ||
                (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.No))
                return;

            SqlDataReader reader;
            SqlCommand qrySearch = new SqlCommand("SELECT sum(cont) Cont "+
                                                    "FROM (SELECT count(*) Cont FROM Cliente WHERE Cidade_ID = @Codigo "+
                                                        "union all "+
                                                          "SELECT count(*) Cont FROM Fornecedor WHERE Cidade_ID = @Codigo " +
                                                        "union all "+
                                                          "SELECt count(*) Cont FROM Funcionario WHERE Cidade_ID = @Codigo) table1", conn);

            qrySearch.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            qrySearch.Parameters["@Codigo"].Value = cidadeID;

            try {
                try {
                    conn.Open();
                } catch (Exception error) {
                    MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try {
                    reader = qrySearch.ExecuteReader();

                    if (reader.Read()) {
                        if (Convert.ToInt32(reader["Cont"].ToString()) > 0) {
                            MessageBox.Show("O registro de cidade não pode ser excluído!\nEsta cidade está sendo usada por outros itens!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            SqlCommand comm = new SqlCommand("DELETE FROM Cidade WHERE cidade_ID = @Codigo", conn);
            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = cidadeID;

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
                    MessageBox.Show("Registro Excluído!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);

                    btnLimpar_Click(sender, e);
                    CidadeEntry_Load(sender, e);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            bool isOperationOK = true;
            SqlCommand comm;

            errorProvider1.Clear();
            if (txtNome.Text.Length == 0) {
                errorProvider1.SetError(txtNome, "O campo do nome deve estar preenchido!");
                return;
            }
            if (cbxUF.SelectedIndex == -1) {
                errorProvider1.SetError(cbxUF, "O UF deve estar selecionado!");
                return;
            }
            if (!msktxtCEP.MaskCompleted) {
                errorProvider1.SetError(msktxtCEP, "O CEP deve estar completamente preenchido!");
                return;
            }

            if (cidadeID == 0) {
                SqlDataReader reader;
                SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM Cidade WHERE Nome = @Nome", conn);

                qrySearch.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
                qrySearch.Parameters["@Nome"].Value = txtNome.Text;

                try {
                    try {
                        conn.Open();
                    } catch (Exception error) {
                        MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try {
                        reader = qrySearch.ExecuteReader();

                        if (reader.Read()) {
                            if (Convert.ToInt32(reader["Cont"].ToString()) > 0) {
                                MessageBox.Show("Esta cidade já existe!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                comm = new SqlCommand("INSERT INTO Cidade (Nome, Uf, Cep) VALUES (@Nome, @Uf, @Cep)", conn);
            } else {
                comm = new SqlCommand("UPDATE Cidade SET Nome = @Nome, Uf = @Uf, Cep = @Cep WHERE cidade_id = @Codigo", conn);

                comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
                comm.Parameters["@Codigo"].Value = cidadeID;
            }

            comm.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Nome"].Value = txtNome.Text;

            comm.Parameters.Add("@Uf", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Uf"].Value = cbxUF.Text;

            comm.Parameters.Add("@Cep", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Cep"].Value = msktxtCEP.Text;
            
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
                    if (cidadeID == 0)
                        MessageBox.Show("Registro Criado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Registro Alterado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);

                    btnLimpar_Click(sender, e);
                    CidadeEntry_Load(sender, e);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            if (txtFiltro.Text.Trim().Length > 0) {
                if (cbxFiltro.SelectedIndex == 0)
                    this.cidadeTableAdapter.FillByGetNome(this.gSSystemDataSet_Cidade.Cidade, "%" + txtFiltro.Text + "%"); 
            } else
                this.cidadeTableAdapter.Fill(this.gSSystemDataSet_Cidade.Cidade);
        }
    }
}
