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
    public partial class ClienteEntry : Form {
        private long clienteID;
        private SqlConnection conn = (SqlConnection)MainData.getNewConnection();

        public ClienteEntry() {
            InitializeComponent();
        }

        private void ClienteEntry_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Cidade.Cidade' table. You can move, or remove it, as needed.
            this.cidadeTableAdapter.Fill(this.gSSystemDataSet_Cidade.Cidade);
            this.clienteTableAdapter.FillOrderByNome(this.gSSystemDataSet_Cliente.Cliente);
            clienteID = 0;
            btnExcluir.Enabled = false;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            int RecSelec = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);

            clienteID = RecSelec;

            SqlCommand comm = new SqlCommand("SELECT Nome, Endereco, Cidade_ID, DataNascimento, Email, Telefone, Cpf FROM Cliente WHERE cliente_ID = @Codigo", conn);
            SqlDataReader reader;

            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = clienteID;

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
                        dtpNascimento.Text = reader["DataNascimento"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        msktxtTelefone.Text = reader["Telefone"].ToString(); 
                        msktxtCPF.Text = reader["Cpf"].ToString();
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
            dtpNascimento.Text = "";
            cbxCidade.SelectedIndex = -1;
            txtEmail.Text = "";
            msktxtTelefone.Text = "";
            msktxtCPF.Text = "";
            clienteID = 0;
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            bool isOperationOK = true;

            if ((clienteID == 0) || 
                (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.No))
                return;

            SqlDataReader reader;
            SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM Venda WHERE Cliente_ID = @Codigo", conn);

            qrySearch.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            qrySearch.Parameters["@Codigo"].Value = clienteID;

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
                            MessageBox.Show("O registro de cliente não pode ser excluído!\nEste cliente está sendo usado por outros itens!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            SqlCommand comm = new SqlCommand("DELETE FROM Cliente WHERE cliente_ID = @Codigo", conn);
            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = clienteID;

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
                    ClienteEntry_Load(sender, e);
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
            if (msktxtCPF.Text.Length > 0 && (!msktxtCPF.MaskFull || !MainData.isCPF(msktxtCPF.Text.Substring(0, 3) + "." + msktxtCPF.Text.Substring(3, 3) + "." + msktxtCPF.Text.Substring(6, 3) + "-" + msktxtCPF.Text.Substring(9, 2)))) {
                errorProvider1.SetError(msktxtCPF, "O campo deve estar completamente preenchido e válido!");
                return;
            }

            if (clienteID == 0) {
                SqlDataReader reader;
                SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM Cliente WHERE Nome = @Nome", conn);

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
                                MessageBox.Show("Este cliente já existe!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                comm = new SqlCommand("INSERT INTO Cliente (Nome, Endereco, Cidade_ID, DataNascimento, Email, Telefone, Cpf) " +
                                                   "VALUES (@Nome, @Endereco, @Cidade_ID, @DataNascimento, @Email, @Telefone, @Cpf)", conn);
            } else {
                comm = new SqlCommand("UPDATE Cliente SET Nome = @Nome, Endereco = @Endereco, Cidade_ID = @Cidade_ID, DataNascimento = @DataNascimento, " +
                                                         "Email = @Email, Telefone = @Telefone, Cpf = @Cpf WHERE cliente_id = @Codigo", conn);

                comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
                comm.Parameters["@Codigo"].Value = clienteID;
            }

            comm.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Nome"].Value = txtNome.Text;

            comm.Parameters.Add("@Endereco", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Endereco"].Value = txtEndereco.Text;

            comm.Parameters.Add("@Cidade_ID", System.Data.SqlDbType.Int);
            comm.Parameters["@Cidade_ID"].Value = cbxCidade.SelectedValue;

            comm.Parameters.Add("@DataNascimento", System.Data.SqlDbType.Date);
            comm.Parameters["@DataNascimento"].Value = dtpNascimento.Text;

            comm.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Email"].Value = txtEmail.Text;

            comm.Parameters.Add("@Telefone", System.Data.SqlDbType.NVarChar);
            if (msktxtTelefone.MaskCompleted)
                comm.Parameters["@Telefone"].Value = "(" + msktxtTelefone.Text.Substring(0, 3) + ")" + msktxtTelefone.Text.Substring(3, 4) + "-" + msktxtTelefone.Text.Substring(7, 4);
            else
                comm.Parameters["@Telefone"].Value = "";

            comm.Parameters.Add("@Cpf", System.Data.SqlDbType.NVarChar);
            if (msktxtCPF.MaskCompleted)
                comm.Parameters["@Cpf"].Value = msktxtCPF.Text.Substring(0, 3) + "." + msktxtCPF.Text.Substring(3, 3) + "." + msktxtCPF.Text.Substring(6, 3) + "-" + msktxtCPF.Text.Substring(9, 2);
            else
                comm.Parameters["@Cpf"].Value = "";

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
                    if (clienteID == 0)
                        MessageBox.Show("Registro Criado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Registro Alterado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    btnLimpar_Click(sender, e);
                    ClienteEntry_Load(sender, e);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
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
        }
    }
}
