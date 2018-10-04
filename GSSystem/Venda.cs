using GSSystem.Dialog;
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

namespace GSSystem {
    public partial class Venda : Form {
        private List<Jogo> carrinho = new List<Jogo>();
        private Jogo jogoSelecionado;
        private SqlConnection conn = (SqlConnection)MainData.getNewConnection();
        private bool add;

        public Venda() {
            InitializeComponent();
        }

        private void Venda_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'gSSystemDataSet_Jogo.JogoEstoque' table. You can move, or remove it, as needed.
            this.jogoEstoqueTableAdapter.Fill(this.gSSystemDataSet_Jogo.JogoEstoque);
            // TODO: This line of code loads data into the 'gSSystemDataSet_Cliente.Cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.FillOrderByNome(this.gSSystemDataSet_Cliente.Cliente);
            add = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            cbxCliente.SelectedIndex = -1;
            lblValor.Text = "0.00";
            chbxAluguel.Checked = false;
            carrinho = new List<Jogo>();
            jogoSelecionado = null;

            var carrinhoView = carrinho.Select(jogo => new {
                jogoID = jogo.jogoID,
                titulo = jogo.titulo,
                quantidade = jogo.quantidade
            }).ToList();
            
            dtgCarrinho.DataSource = carrinhoView;
            dtgCarrinho.Refresh();
        }

        private void dtgJogos_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            jogoSelecionado = new Jogo();
            jogoSelecionado.jogoID = Convert.ToInt32(dtgJogos.Rows[e.RowIndex].Cells[0].Value);
            jogoSelecionado.titulo = dtgJogos.Rows[e.RowIndex].Cells[1].Value.ToString();
            jogoSelecionado.valor = Convert.ToDecimal(dtgJogos.Rows[e.RowIndex].Cells[2].Value);
            jogoSelecionado.maxEstoque = Convert.ToInt32(dtgJogos.Rows[e.RowIndex].Cells[3].Value);
            jogoSelecionado.quantidade = 0;
            btnAlterar.Text = "Adicionar";
            add = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            if (jogoSelecionado == null) return;

            if (add) {
                foreach (Jogo jogo in carrinho) {
                    if (jogo.titulo == jogoSelecionado.titulo) {
                        MessageBox.Show("Jogo já está no carrinho!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                QuantidadeDialog quantidadeDiag = new QuantidadeDialog(jogoSelecionado.maxEstoque);
                if (quantidadeDiag.ShowDialog() == DialogResult.OK) {
                    jogoSelecionado.quantidade = quantidadeDiag.quantidade;
                    carrinho.Add(jogoSelecionado);
                }
            } else
                foreach (Jogo jogo in carrinho) {
                    if (jogo.titulo == jogoSelecionado.titulo) {
                        carrinho.Remove(jogo);
                        break;
                    }
                }

            decimal valorTotal = 0.00m;
            foreach (Jogo jogo in carrinho) 
                valorTotal += jogo.valor * jogo.quantidade; 

            lblValor.Text = valorTotal.ToString();

            var carrinhoView = carrinho.Select(jogo => new
            {
                jogoID = jogo.jogoID,
                titulo = jogo.titulo,
                quantidade = jogo.quantidade
            }).ToList();
            
            dtgCarrinho.DataSource = carrinhoView;
            dtgCarrinho.Refresh();

            jogoSelecionado = null;
        }

        private void dtgCarrinho_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            jogoSelecionado = new Jogo();
            jogoSelecionado.jogoID = Convert.ToInt32(dtgCarrinho.Rows[e.RowIndex].Cells[0].Value);
            jogoSelecionado.titulo = dtgCarrinho.Rows[e.RowIndex].Cells[1].Value.ToString();
            jogoSelecionado.quantidade = 0;
            btnAlterar.Text = "Remover";
            add = false;
        }

        class Jogo {
            public int jogoID;
            public String titulo;
            public int quantidade;
            public int maxEstoque;
            public decimal valor;
        }

        private void btnFinalizar_Click(object sender, EventArgs e) {
            bool isOperationOK = true;
            SqlCommand comm, comm2, comm4;
            char aluga;

            errorProvider1.Clear();
            if (cbxCliente.SelectedIndex == -1) {
                errorProvider1.SetError(cbxCliente, "Um cliente deve ser selecionado!");
                return;
            }

            if (carrinho.Count() == 0) {
                MessageBox.Show("Deve haver ao menos um item no carrinho", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            comm = new SqlCommand("INSERT INTO Venda (Funcionario_ID, Cliente_ID, DataVenda, Aluguel) " +
                                            "VALUES (@Funcionario_ID, @Cliente_ID, @DataVenda, @Aluguel)", conn);

            if (chbxAluguel.Checked) {
                comm2 = new SqlCommand("INSERT INTO ItemVenda (Jogo_ID, Venda_ID, Quantidade, valorJogo, retornoJogo) " +
                                            "VALUES (@Jogo_ID, @Venda_ID, @Quantidade, @valorJogo, @retornoJogo)", conn);
                aluga = 'T';
            } else {
                comm2 = new SqlCommand("INSERT INTO ItemVenda (Jogo_ID, Venda_ID, Quantidade, valorJogo) " +
                                            "VALUES (@Jogo_ID, @Venda_ID, @Quantidade, @valorJogo)", conn);
                aluga = 'F';
            }

            comm4 = new SqlCommand("UPDATE Estoque SET Quantidade = Quantidade - @Quantidade WHERE Jogo_ID = @Jogo_ID", conn);

            comm.Parameters.Add("@Funcionario_ID", System.Data.SqlDbType.Int);
            comm.Parameters["@Funcionario_ID"].Value = MainData.getUserFuncionarioID();

            comm.Parameters.Add("@Cliente_ID", System.Data.SqlDbType.Int);
            comm.Parameters["@Cliente_ID"].Value = cbxCliente.SelectedValue;

            comm.Parameters.Add("@DataVenda", System.Data.SqlDbType.Date);
            comm.Parameters["@DataVenda"].Value = dtpData.Text;

            comm.Parameters.Add("@Aluguel", System.Data.SqlDbType.Char);
            comm.Parameters["@Aluguel"].Value = aluga;

            try {
                try {
                    conn.Open();
                } catch (Exception error) {
                    isOperationOK = false;
                    MessageBox.Show(error.Message, "Erro ao abrir conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try {
                    comm.ExecuteNonQuery();

                    SqlCommand comm3 = new SqlCommand("SELECT Venda_ID FROM Venda WHERE Cliente_ID = @Cliente_ID AND Funcionario_ID = @Funcionario_ID " +
                                                         "AND Venda_ID NOT IN (SELECT Venda_ID FROM ItemVenda)", conn);
                    SqlDataReader reader;

                    comm3.Parameters.Add("@Cliente_ID", System.Data.SqlDbType.Int);
                    comm3.Parameters["@Cliente_ID"].Value = cbxCliente.SelectedValue;

                    comm3.Parameters.Add("@Funcionario_ID", System.Data.SqlDbType.Int);
                    comm3.Parameters["@Funcionario_ID"].Value = MainData.getUserFuncionarioID();

                    reader = comm3.ExecuteReader();

                    int vendaID = 0;
                    if (reader.Read()) {
                        vendaID = Convert.ToInt32(reader["Venda_ID"].ToString());
                    }
                    reader.Close();

                    if (vendaID > 0) {
                        comm2.Parameters.Add("@Venda_ID", SqlDbType.Int);
                        comm2.Parameters.Add("@Jogo_ID", System.Data.SqlDbType.Int);
                        comm2.Parameters.Add("@Quantidade", System.Data.SqlDbType.Int);
                        comm2.Parameters.Add("@valorJogo", System.Data.SqlDbType.Decimal);

                        comm4.Parameters.Add("@Jogo_ID", SqlDbType.Int);
                        comm4.Parameters.Add("@Quantidade", SqlDbType.Int);
                        if (chbxAluguel.Checked) 
                            comm.Parameters.Add("@retornoJogo", System.Data.SqlDbType.Date);
                        foreach (Jogo jogo in carrinho) {
                            comm2.Parameters["@Venda_ID"].Value = vendaID;
                            comm2.Parameters["@Jogo_ID"].Value = jogo.jogoID;
                            comm2.Parameters["@Quantidade"].Value = jogo.quantidade;
                            comm2.Parameters["@valorJogo"].Value = jogo.valor;
                            if (chbxAluguel.Checked) 
                                comm.Parameters["@retornoJogo"].Value = dtpData.Text;
                            comm2.ExecuteNonQuery();
                            
                            comm4.Parameters["@Jogo_ID"].Value = jogo.jogoID;
                            comm4.Parameters["@Quantidade"].Value = jogo.quantidade;
                            comm4.ExecuteNonQuery();
                        }
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
                    btnCancelar_Click(sender, e);
                    MessageBox.Show("Venda Finalizada!", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Venda_Load(sender, e);
                }
            }
        }
    }
}
