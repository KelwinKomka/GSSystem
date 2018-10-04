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
    public partial class JogoEntry : Form {
        private long jogoID;
        private SqlConnection conn = (SqlConnection)MainData.getNewConnection();

        public JogoEntry() {
            InitializeComponent();
        }

        private void JogoEntry_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Genero.Genero' table. You can move, or remove it, as needed.
            this.generoTableAdapter.Fill(this.gSSystemDataSet_Genero.Genero);
            // TODO: This line of code loads data into the 'gSSystemDataSet_Jogo.Jogo' table. You can move, or remove it, as needed.
            this.jogoTableAdapter.Fill(this.gSSystemDataSet_Jogo.Jogo);
            jogoID = 0;
            btnFornecedor.Enabled = false;
            btnPlataforma.Enabled = false;
            btnExcluir.Enabled = false;
        }

        public void carregarData(object sender, EventArgs e) {
            JogoEntry_Load(sender, e);
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            errorProvider1.Clear();
            txtTitulo.Text = "";
            txtPreco.Text = "";
            dtpLancamento.Text = "";
            cbxGenero.SelectedIndex = -1;
            txtClassificacao.Text = "";
            txtProdutora.Text = "";
            txtDistribuidora.Text = "";
            rtxtEspecificacao.Text = "";
            txtEstoque.Text = "";
            btnFornecedor.Enabled = false;
            btnPlataforma.Enabled = false;
            jogoID = 0;
            btnExcluir.Enabled = false;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            int RecSelec = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);

            jogoID = RecSelec;

            SqlCommand comm = new SqlCommand("SELECT J.Titulo, J.Preco, J.DataLancamento, J.Classificacao, J.Especificacao, J.Distribuidora, J.Produtora, J.Genero_ID, " +
                                                    "E.Quantidade " +
                                               "FROM Jogo J, Estoque E " +
                                              "WHERE J.Jogo_ID = @Codigo " +
                                                "AND J.Jogo_ID = E.Jogo_ID", conn);
            SqlDataReader reader;

            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = jogoID;

            try {
                try {
                    conn.Open();
                } catch (Exception error) {
                    MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try {
                    reader = comm.ExecuteReader();
                    if (reader.Read()) {
                        txtTitulo.Text = reader["Titulo"].ToString();
                        txtPreco.Text = reader["Preco"].ToString();
                        dtpLancamento.Text = reader["DataLancamento"].ToString();
                        cbxGenero.SelectedValue = Convert.ToInt32(reader["Genero_ID"].ToString());
                        txtClassificacao.Text = reader["Classificacao"].ToString();
                        txtProdutora.Text = reader["Produtora"].ToString();
                        txtDistribuidora.Text = reader["Distribuidora"].ToString();
                        rtxtEspecificacao.Text = reader["Especificacao"].ToString();
                        txtEstoque.Text = reader["Quantidade"].ToString();
                        btnFornecedor.Enabled = true;
                        btnPlataforma.Enabled = true;
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

        private void btnExcluir_Click(object sender, EventArgs e) {
            bool isOperationOK = true;

            if ((jogoID == 0) ||
                (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.No))
                return;

            SqlDataReader reader;
            SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM ItemVenda WHERE Jogo_ID = @Codigo", conn);

            qrySearch.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            qrySearch.Parameters["@Codigo"].Value = jogoID;

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
                            MessageBox.Show("O registro de jogo não pode ser excluído!" +
                                "\nEste jogo está sendo usado por outros itens!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            SqlCommand comm = new SqlCommand("DELETE FROM JogoFornecedor WHERE Jogo_ID = @Codigo", conn);
            comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm.Parameters["@Codigo"].Value = jogoID;

            SqlCommand comm2 = new SqlCommand("DELETE FROM JogoPlataforma WHERE Jogo_ID = @Codigo", conn);
            comm2.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm2.Parameters["@Codigo"].Value = jogoID;

            SqlCommand comm3 = new SqlCommand("DELETE FROM Estoque WHERE Jogo_ID = @Codigo", conn);
            comm3.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm3.Parameters["@Codigo"].Value = jogoID;

            SqlCommand comm4 = new SqlCommand("DELETE FROM Jogo WHERE Jogo_ID = @Codigo", conn);
            comm4.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
            comm4.Parameters["@Codigo"].Value = jogoID;

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
                    comm3.ExecuteNonQuery();
                    comm4.ExecuteNonQuery();
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
                    JogoEntry_Load(sender, e);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            bool isOperationOK = true;
            SqlCommand comm, comm2;
            SqlDataReader reader;

            errorProvider1.Clear();
            if (txtTitulo.Text.Length == 0) {
                errorProvider1.SetError(txtTitulo, "O campo do título deve estar preenchido!");
                return;
            }
            decimal i;
            if (txtPreco.Text.Trim().Length == 0 || !Decimal.TryParse(txtPreco.Text, out i) || txtPreco.Text.Contains(".")) {
                errorProvider1.SetError(txtPreco, "O campo deve estar preenchido por dígitos e separado por vírgula!");
                return;
            }
            if (cbxGenero.SelectedIndex == -1) {
                errorProvider1.SetError(cbxGenero, "O gênero deve estar selecionado!");
                return;
            }
            if (txtEstoque.Text.Length == 0 || !Decimal.TryParse(txtEstoque.Text, out i)) {
                errorProvider1.SetError(txtEstoque, "O estoque deve estar preenchido e apenas por dígitos!");
                return;
            }

            if (jogoID == 0) {
                SqlCommand qrySearch = new SqlCommand("SELECT count(*) Cont FROM Jogo WHERE Titulo = @Titulo", conn);

                qrySearch.Parameters.Add("@Titulo", System.Data.SqlDbType.NVarChar);
                qrySearch.Parameters["@Titulo"].Value = txtTitulo.Text;

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
                                MessageBox.Show("Este jogo já existe!", "Erro ao executar comando SQL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                comm = new SqlCommand("INSERT INTO Jogo (Titulo, Preco, DataLancamento, Classificacao, Especificacao, Distribuidora, Produtora, Genero_ID) " +
                                                "VALUES (@Titulo, @Preco, @DataLancamento, @Classificacao, @Especificacao, @Distribuidora, @Produtora, @Genero_ID)", conn);

                comm2 = new SqlCommand("INSERT INTO Estoque (Jogo_ID, Quantidade) " +
                                                "VALUES (@Jogo_ID, @Quantidade)", conn);
            } else {
                comm = new SqlCommand("UPDATE Jogo SET Titulo = @Titulo, Preco = @Preco, DataLancamento = @DataLancamento, Classificacao =  @Classificacao, " +
                                                      "Especificacao = @Especificacao, Distribuidora = @Distribuidora, Produtora = @Produtora, Genero_ID = @Genero_ID " +
                                       "WHERE Jogo_ID = @Codigo", conn);

                comm.Parameters.Add("@Codigo", System.Data.SqlDbType.Int);
                comm.Parameters["@Codigo"].Value = jogoID;

                comm2 = new SqlCommand("UPDATE Estoque SET Quantidade = @Quantidade WHERE Jogo_ID = @Jogo_ID", conn);
            }

            comm.Parameters.Add("@Titulo", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Titulo"].Value = txtTitulo.Text;

            comm.Parameters.Add("@Preco", System.Data.SqlDbType.Decimal);
            comm.Parameters["@Preco"].Value = Convert.ToDecimal(txtPreco.Text);

            comm.Parameters.Add("@DataLancamento", System.Data.SqlDbType.Date);
            comm.Parameters["@DataLancamento"].Value = dtpLancamento.Text;

            comm.Parameters.Add("@Classificacao", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Classificacao"].Value = txtClassificacao.Text;

            comm.Parameters.Add("@Especificacao", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Especificacao"].Value = rtxtEspecificacao.Text;

            comm.Parameters.Add("@Distribuidora", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Distribuidora"].Value = txtDistribuidora.Text;

            comm.Parameters.Add("@Produtora", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@Produtora"].Value = txtProdutora.Text;

            comm.Parameters.Add("@Genero_ID", System.Data.SqlDbType.Int);
            comm.Parameters["@Genero_ID"].Value = cbxGenero.SelectedValue;

            comm2.Parameters.Add("@Quantidade", System.Data.SqlDbType.Int);
            if (Convert.ToInt32(txtEstoque.Text) >= 0)
                comm2.Parameters["@Quantidade"].Value = Convert.ToInt32(txtEstoque.Text);
            else
                comm2.Parameters["@Quantidade"].Value = 0;

            try {
                try {
                    conn.Open();
                } catch (Exception error) {
                    isOperationOK = false;
                    MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try {
                    comm.ExecuteNonQuery();

                    if (jogoID == 0) {
                        SqlCommand comm3 = new SqlCommand("SELECT Jogo_ID FROM Jogo WHERE Titulo = @Titulo", conn);

                        comm3.Parameters.Add("@Titulo", System.Data.SqlDbType.NVarChar);
                        comm3.Parameters["@Titulo"].Value = txtTitulo.Text;

                        reader = comm3.ExecuteReader();
                        if (reader.Read()) {
                            jogoID = Convert.ToInt32(reader["Jogo_ID"].ToString());
                        }
                        reader.Close();
                    }

                    if (jogoID > 0) {
                        comm2.Parameters.Add("@Jogo_ID", SqlDbType.Int);
                        comm2.Parameters["@Jogo_ID"].Value = jogoID;
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
                    if (jogoID == 0)
                        MessageBox.Show("Registro Criado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Registro Alterado com sucesso!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);

                    btnLimpar_Click(sender, e);
                    JogoEntry_Load(sender, e);
                }
            }
        }

        private void btnGenero_Click(object sender, EventArgs e) {
            GeneroEntry frmGenero = new GeneroEntry(this);
            frmGenero.ShowDialog();
        }

        private void btnFornecedor_Click(object sender, EventArgs e) {
            FornecedorJogoEntry frmJogoFornecedor = new FornecedorJogoEntry(jogoID);
            frmJogoFornecedor.ShowDialog();
        }

        private void btnPlataforma_Click(object sender, EventArgs e) {
            PlataformaEntry frmPlataforma = new PlataformaEntry(jogoID);
            frmPlataforma.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            if (txtFiltro.Text.Trim().Length > 0) {
                if (cbxFiltro.SelectedIndex == 0)
                    this.jogoTableAdapter.FillByTitulo(this.gSSystemDataSet_Jogo.Jogo, "%" + txtFiltro.Text + "%");
            } else
                this.jogoTableAdapter.Fill(this.gSSystemDataSet_Jogo.Jogo);
        }
    }
}
