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
    public partial class FuncionarioEntry : Form {
        private long funcionarioID;
        private SqlConnection conn = (SqlConnection) MainData.getNewConnection();

        public FuncionarioEntry() {
            InitializeComponent();
        }

        private void FuncionarioEntry_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Cidade.Cidade' table. You can move, or remove it, as needed.
            this.cidadeTableAdapter.Fill(this.gSSystemDataSet_Cidade.Cidade);
            this.funcionarioTableAdapter.FillOrderByNome(this.gSSystemDataSet_Funcionario.Funcionario);
            funcionarioID = 0;
            btnExcluir.Enabled = false;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            int RecSelec = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);

            funcionarioID = RecSelec;

            SqlCommand comm = new SqlCommand("SELECT F.Nome, F.Endereco, F.Cidade_ID, F.DataNascimento, F.Email, F.Telefone, F.Cpf, F.Salario, F.Cargo, "+
                                                    "U.Nome as Conta, U.NivelAcesso "+
                                               "FROM Funcionario F, Usuario U "+
                                              "WHERE F.funcionario_ID = U.funcionario_ID "+
                                                "AND F.funcionario_ID = @Codigo", conn);
            SqlDataReader reader;

            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = funcionarioID;

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
                        txtSalario.Text = reader["Salario"].ToString();
                        cbxCargo.SelectedIndex = cbxCargo.Items.IndexOf(reader["Cargo"].ToString());
                        txtConta.Text = reader["Conta"].ToString();
                        String nivelAcesso = reader["NivelAcesso"].ToString();
                        switch (nivelAcesso) {
                            case "A":
                                cbxNivelAcesso.SelectedIndex = 0;
                                break;
                            case "F":
                                cbxNivelAcesso.SelectedIndex = 1;
                                break;                              
                        }
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
            txtSalario.Text = "";
            cbxCargo.SelectedIndex = -1;
            txtConta.Text = "";
            txtSenha.Text = "";
            cbxNivelAcesso.SelectedIndex = -1;
            funcionarioID = 0;
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            bool isOperationOK = true;

            if ((funcionarioID == 0) ||
                (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.No))
                return;

            SqlDataReader reader;
            SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM Venda WHERE Funcionario_ID = @Codigo", conn);

            qrySearch.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            qrySearch.Parameters["@Codigo"].Value = funcionarioID;

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
                            MessageBox.Show("O registro de funcionário não pode ser excluído!" +
                                "\nEste funcionário está sendo usado por outros itens!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            SqlCommand comm = new SqlCommand("DELETE FROM Usuario WHERE funcionario_ID = @Codigo", conn);
            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = funcionarioID;

            SqlCommand comm2 = new SqlCommand("DELETE FROM Funcionario WHERE funcionario_ID = @Codigo", conn);
            comm2.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm2.Parameters["@Codigo"].Value = funcionarioID;

            try {
                try {
                    conn.Open();
                } catch (Exception error) {
                    isOperationOK = false;
                    MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try {
                    comm.ExecuteNonQuery();
                    comm2.ExecuteNonQuery();
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
                    FuncionarioEntry_Load(sender, e);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            bool isOperationOK = true;
            SqlCommand comm, comm2;
            SqlDataReader reader;

            errorProvider1.Clear();
            if (txtNome.Text.Length == 0) {
                errorProvider1.SetError(txtNome, "O campo deve estar preenchido!");
                return;
            }
            if (txtEndereco.Text.Length == 0) {
                errorProvider1.SetError(txtEndereco, "O campo deve estar preenchido!");
                return;
            }
            if (msktxtTelefone.Text.Length > 0 && !msktxtTelefone.MaskFull) {
                errorProvider1.SetError(msktxtTelefone, "O campo deve estar completamente preenchido!");
                return;
            }
            if (msktxtCPF.Text.Length > 0 && (!msktxtCPF.MaskFull || !MainData.isCPF(msktxtCPF.Text.Substring(0, 3) + "." + msktxtCPF.Text.Substring(3, 3) + "." + msktxtCPF.Text.Substring(6, 3) + "-" + msktxtCPF.Text.Substring(9, 2)))) {
                errorProvider1.SetError(msktxtCPF, "O campo deve estar completamente preenchido e válido!");
                return;
            }
            decimal i;
            if (txtSalario.Text.Trim().Length == 0 || !Decimal.TryParse(txtSalario.Text, out i) || txtSalario.Text.Contains(".")) {
                errorProvider1.SetError(txtSalario, "O campo deve estar preenchido por dígitos e separado por vírgula!");
                return;
            }
            if (cbxCargo.SelectedIndex == -1) {
                errorProvider1.SetError(cbxCargo, "Um cargo deve ser selecionado!");
                return;
            }
            if (txtConta.Text.Length == 0) {
                errorProvider1.SetError(txtConta, "O campo deve estar preenchido!");
                return;
            }
            if (cbxNivelAcesso.SelectedIndex == -1) {
                errorProvider1.SetError(cbxNivelAcesso, "Um nível de acesso deve ser selecionado!");
                return;
            }
            if (funcionarioID == 0 && txtSenha.Text.Trim().Length == 0) {
                errorProvider1.SetError(txtSenha, "O campo deve estar preenchido!");
                return;
            }

            if (funcionarioID == 0) {
                SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM Funcionario WHERE Nome = @Nome", conn);

                qrySearch.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
                qrySearch.Parameters["@Nome"].Value = txtNome.Text;

                SqlCommand qrySearch2 = new SqlCommand("SELECT count(*) Cont FROM Usuario WHERE Nome = @Nome", conn);

                qrySearch2.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
                qrySearch2.Parameters["@Nome"].Value = txtConta.Text;

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
                                MessageBox.Show("Este funcionário já existe!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        reader.Close();

                        reader = qrySearch2.ExecuteReader();
                        if (reader.Read()) {
                            if (Convert.ToInt32(reader["Cont"].ToString()) > 0) {
                                MessageBox.Show("Esta conta já existe!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                comm = new SqlCommand("INSERT INTO Funcionario (Nome, Endereco, Cidade_ID, DataNascimento, Email, Telefone, Cpf, Salario, Cargo) " +
                                                   "VALUES (@Nome, @Endereco, @Cidade_ID, @DataNascimento, @Email, @Telefone, @Cpf, @Salario, @Cargo)", conn);

                comm2 = new SqlCommand("INSERT INTO Usuario (Nome, Senha, Funcionario_ID, NivelAcesso) " +
                                                   "VALUES (@Nome, @Senha, @Funcionario_ID, @NivelAcesso)", conn);

                comm2.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
                comm2.Parameters["@Nome"].Value = txtConta.Text;

                comm2.Parameters.Add("@Senha", System.Data.SqlDbType.NVarChar);
                comm2.Parameters["@Senha"].Value = txtSenha.Text;

                String nivel = "";
                switch (cbxNivelAcesso.SelectedIndex) {
                    case 0:
                        nivel = "A";
                        break;
                    case 1:
                        nivel = "F";
                        break;
                }

                comm2.Parameters.Add("@NivelAcesso", System.Data.SqlDbType.NVarChar);
                comm2.Parameters["@NivelAcesso"].Value = nivel;

            } else {
                comm = new SqlCommand("UPDATE Funcionario SET Nome = @Nome, Endereco = @Endereco, Cidade_ID = @Cidade_ID, DataNascimento = @DataNascimento, " +
                                                         "Email = @Email, Telefone = @Telefone, Cpf = @Cpf, Salario = @Salario, Cargo = @Cargo WHERE funcionario_ID = @Codigo", conn);

                comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
                comm.Parameters["@Codigo"].Value = funcionarioID;

                if (txtSenha.Text.Trim().Length > 0) {
                    comm2 = new SqlCommand("UPDATE Usuario SET Nome = @Nome, Senha = @Senha, NivelAcesso = @NivelAcesso WHERE Funcionario_ID = @Funcionario_ID", conn);

                    comm2.Parameters.Add("@Senha", System.Data.SqlDbType.NVarChar);
                    comm2.Parameters["@Senha"].Value = txtSenha.Text;
                } else {
                    comm2 = new SqlCommand("UPDATE Usuario SET Nome = @Nome, NivelAcesso = @NivelAcesso WHERE Funcionario_ID = @Funcionario_ID", conn);
                }

                comm2.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
                comm2.Parameters["@Nome"].Value = txtConta.Text;

                String nivel = "";
                switch (cbxNivelAcesso.SelectedIndex) {
                    case 0:
                        nivel = "A";
                        break;
                    case 1:
                        nivel = "F";
                        break;
                }

                comm2.Parameters.Add("@NivelAcesso", System.Data.SqlDbType.NVarChar);
                comm2.Parameters["@NivelAcesso"].Value = nivel;
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

            comm.Parameters.Add("@Salario", System.Data.SqlDbType.Decimal);
            comm.Parameters["@Salario"].Value = Convert.ToDecimal(txtSalario.Text);

            comm.Parameters.Add("@Cargo", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Cargo"].Value = cbxCargo.Text;

            try {
                try {
                    conn.Open();
                } catch (Exception error) {
                    isOperationOK = false;
                    MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try {
                    comm.ExecuteNonQuery();

                    if (funcionarioID == 0) {
                        SqlCommand comm3 = new SqlCommand("SELECT Funcionario_ID FROM Funcionario WHERE Nome = @Nome", conn);

                        comm3.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar);
                        comm3.Parameters["@Nome"].Value = txtNome.Text;

                        reader = comm3.ExecuteReader();
                        if (reader.Read()) {
                            funcionarioID = Convert.ToInt32(reader["Funcionario_ID"].ToString());
                        }
                        reader.Close();
                    }

                    if (funcionarioID > 0) {
                        comm2.Parameters.Add("@Funcionario_ID", SqlDbType.Int);
                        comm2.Parameters["@Funcionario_ID"].Value = funcionarioID;
                        comm2.ExecuteNonQuery();
                    } else {
                        isOperationOK = false;
                        MessageBox.Show("Não foi possível inserir o usuário!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } catch (Exception error) {
                    isOperationOK = false;
                    MessageBox.Show(error.Message, "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch {
            } finally {
                conn.Close();

                if (isOperationOK) {
                    if (funcionarioID == 0)
                        MessageBox.Show("Registro Criado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Registro Alterado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    btnLimpar_Click(sender, e);
                    FuncionarioEntry_Load(sender, e);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
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
        }
    }
}
