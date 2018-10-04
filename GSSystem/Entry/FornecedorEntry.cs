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
    public partial class FornecedorEntry : Form {
        private long fornecedorID;
        private SqlConnection conn = (SqlConnection)MainData.getNewConnection();

        public FornecedorEntry() {
            InitializeComponent();
        }

        private void FornecedorEntry_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Cidade.Cidade' table. You can move, or remove it, as needed.
            this.cidadeTableAdapter.Fill(this.gSSystemDataSet_Cidade.Cidade);
            this.fornecedorTableAdapter.FillOrderByNome(this.gSSystemDataSet_Fornecedor.Fornecedor);
            fornecedorID = 0;
            btnExcluir.Enabled = false;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            int RecSelec = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);

            fornecedorID = RecSelec;

            SqlCommand comm = new SqlCommand("SELECT Nome, Endereco, Cidade_ID, Email, Telefone, Cnpj FROM Fornecedor WHERE fornecedor_ID = @Codigo", conn);
            SqlDataReader reader;

            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = fornecedorID;

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
                        txtEndereco.Text = reader["Endereco"].ToString();
                        cbxCidade.SelectedValue = Convert.ToInt32(reader["Cidade_ID"].ToString());
                        txtEmail.Text = reader["Email"].ToString();
                        msktxtTelefone.Text = reader["Telefone"].ToString();
                        msktxtCNPJ.Text = reader["Cnpj"].ToString();
                    }
                    reader.Close();
                } catch (Exception error) {
                    MessageBox.Show(error.Message, "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch { } finally {
                btnExcluir.Enabled = true;
                conn.Close();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            txtNome.Text = "";
            txtEndereco.Text = "";
            cbxCidade.SelectedIndex = -1;
            txtEmail.Text = "";
            msktxtTelefone.Text = "";
            msktxtCNPJ.Text = "";
            fornecedorID = 0;
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            bool isOperationOK = true;

            if ((fornecedorID == 0) ||
                (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.No))
                return;

            SqlDataReader reader;
            SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM JogoFornecedor WHERE Fornecedor_ID = @Codigo", conn);

            qrySearch.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            qrySearch.Parameters["@Codigo"].Value = fornecedorID;

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
                            MessageBox.Show("O registro de fornecedor não pode ser excluído!" +
                                "\nEste fornecedor está sendo usado por outros itens!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            SqlCommand comm = new SqlCommand("DELETE FROM Fornecedor WHERE Fornecedor_ID = @Codigo", conn);
            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = fornecedorID;

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
                    FornecedorEntry_Load(sender, e);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            bool isOperationOK = true;
            SqlCommand comm;

            errorProvider1.Clear();
            if (txtNome.Text.Length == 0) {
                errorProvider1.SetError(txtNome, "O campo deve estar preenchido!");
                return;
            }
            if (txtEndereco.Text.Length == 0) {
                errorProvider1.SetError(txtEndereco, "O campo deve estar preenchido!");
                return;
            }
            if (msktxtTelefone.Text.Length > 0 && !msktxtTelefone.MaskCompleted) {
                errorProvider1.SetError(msktxtTelefone, "O campo deve estar completamente preenchido!");
                return;
            }
            if (msktxtCNPJ.Text.Length > 0 && (!msktxtCNPJ.MaskCompleted || !MainData.isCNPJ(msktxtCNPJ.Text.Substring(0, 2) + "." + msktxtCNPJ.Text.Substring(2, 3) + "." + 
                                                                                             msktxtCNPJ.Text.Substring(5, 3) + "/" + msktxtCNPJ.Text.Substring(8, 4) + "-" + 
                                                                                             msktxtCNPJ.Text.Substring(12, 2)))) {
                errorProvider1.SetError(msktxtCNPJ, "O campo deve estar completamente preenchido e válido!");
                return;
            }

            if (fornecedorID == 0) {
                SqlDataReader reader;
                SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM Fornecedor WHERE Nome = @Nome", conn);

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
                                MessageBox.Show("Este fornecedor já existe!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                comm = new SqlCommand("INSERT INTO Fornecedor (Nome, Endereco, Cidade_ID, Email, Telefone, Cnpj) " +
                                                   "VALUES (@Nome, @Endereco, @Cidade_ID, @Email, @Telefone, @Cnpj)", conn);
            } else {
                comm = new SqlCommand("UPDATE Fornecedor SET Nome = @Nome, Endereco = @Endereco, Cidade_ID = @Cidade_ID, " +
                                                         "Email = @Email, Telefone = @Telefone, Cnpj = @Cnpj WHERE fornecedor_id = @Codigo", conn);

                comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
                comm.Parameters["@Codigo"].Value = fornecedorID;
            }

            comm.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Nome"].Value = txtNome.Text;

            comm.Parameters.Add("@Endereco", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Endereco"].Value = txtEndereco.Text;

            comm.Parameters.Add("@Cidade_ID", System.Data.SqlDbType.Int);
            comm.Parameters["@Cidade_ID"].Value = cbxCidade.SelectedValue;

            comm.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Email"].Value = txtEmail.Text;

            comm.Parameters.Add("@Telefone", System.Data.SqlDbType.NVarChar);
            if (msktxtTelefone.MaskCompleted)
                comm.Parameters["@Telefone"].Value = "(" + msktxtTelefone.Text.Substring(0, 3) + ")" + msktxtTelefone.Text.Substring(3, 4) + "-" + msktxtTelefone.Text.Substring(7, 4);
            else
                comm.Parameters["@Telefone"].Value = "";

            comm.Parameters.Add("@Cnpj", System.Data.SqlDbType.NVarChar);
            if (msktxtCNPJ.MaskCompleted)
                comm.Parameters["@Cnpj"].Value = msktxtCNPJ.Text.Substring(0, 2) + "." + msktxtCNPJ.Text.Substring(2, 3) + "." +
                                                                                         msktxtCNPJ.Text.Substring(5, 3) + "/" + msktxtCNPJ.Text.Substring(8, 4) + "-" +
                                                                                         msktxtCNPJ.Text.Substring(12, 2);
            else
                comm.Parameters["@Cnpj"].Value = "";
            
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
                    if (fornecedorID == 0)
                        MessageBox.Show("Registro Criado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Registro Alterado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    btnLimpar_Click(sender, e);
                    FornecedorEntry_Load(sender, e);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            if (txtFiltro.Text.Trim().Length > 0) {
                if (cbxFiltro.SelectedIndex == 0)
                    this.fornecedorTableAdapter.FillByNome(this.gSSystemDataSet_Fornecedor.Fornecedor, "%" + txtFiltro.Text + "%");
            } else
                this.fornecedorTableAdapter.FillOrderByNome(this.gSSystemDataSet_Fornecedor.Fornecedor);
        }
    }
}
