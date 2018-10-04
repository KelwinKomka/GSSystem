using GSSystem.Dialog;
using GSSystem.Entry;
using GSSystem.Print;
using GSSystem.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSSystem {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
            cadastroToolStripMenuItem.Enabled = 'A'.Equals(MainData.getUserAccessLevel());
        }

        private void closeChild() {
            pctLogo.Visible = false;
            Form formActivated = this.ActiveMdiChild;
            if (formActivated != null)
                formActivated.Close();
        }

        public void SetUserStatusBar(String user) {
            tssUser.Text = user;
            tssUser.Visible = true;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void smiCadastroCidade_Click(object sender, EventArgs e) {
            closeChild();
            CidadeEntry frmCidade = new CidadeEntry();
            frmCidade.MdiParent = this;
            frmCidade.Dock = DockStyle.Fill;
            frmCidade.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        private void smiCadastroCliente_Click(object sender, EventArgs e) {
            closeChild();
            ClienteEntry frmCliente = new ClienteEntry();
            frmCliente.MdiParent = this;
            frmCliente.Dock = DockStyle.Fill;
            frmCliente.Show();
        }

        private void smiCadastroFonecedor_Click(object sender, EventArgs e) {
            closeChild();
            FornecedorEntry frmFornecedor = new FornecedorEntry();
            frmFornecedor.MdiParent = this;
            frmFornecedor.Dock = DockStyle.Fill;
            frmFornecedor.Show();
        }

        private void smiCadastroFuncionario_Click(object sender, EventArgs e) {
            closeChild();
            FuncionarioEntry frmFuncionario = new FuncionarioEntry();
            frmFuncionario.MdiParent = this;
            frmFuncionario.Dock = DockStyle.Fill;
            frmFuncionario.Show();
        }

        private void smiCadastroJogo_Click(object sender, EventArgs e) {
            closeChild();
            JogoEntry frmJogo = new JogoEntry();
            frmJogo.MdiParent = this;
            frmJogo.Dock = DockStyle.Fill;
            frmJogo.Show();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e) {
            closeChild();
            Venda frmVenda = new Venda();
            frmVenda.MdiParent = this;
            frmVenda.Dock = DockStyle.Fill;
            frmVenda.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e) {
            closeChild();
            ClienteReport frmClienteReport = new ClienteReport();
            frmClienteReport.MdiParent = this;
            frmClienteReport.Dock = DockStyle.Fill;
            frmClienteReport.Show();
        }

        private void vendaToolStripMenuItem1_Click(object sender, EventArgs e) {
            closeChild();
            VendaReport frmVendaReport = new VendaReport();
            frmVendaReport.MdiParent = this;
            frmVendaReport.Dock = DockStyle.Fill;
            frmVendaReport.Show();
        }

        private void jogoToolStripMenuItem_Click(object sender, EventArgs e) {
            closeChild();
            JogoReport frmJogoReport = new JogoReport();
            frmJogoReport.MdiParent = this;
            frmJogoReport.Dock = DockStyle.Fill;
            frmJogoReport.Show();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e) {
            closeChild();
            EstoqueReport frmEstoqueReport = new EstoqueReport();
            frmEstoqueReport.MdiParent = this;
            frmEstoqueReport.Dock = DockStyle.Fill;
            frmEstoqueReport.Show();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e) {
            closeChild();
            FuncionarioReport frmFuncionarioReport = new FuncionarioReport();
            frmFuncionarioReport.MdiParent = this;
            frmFuncionarioReport.Dock = DockStyle.Fill;
            frmFuncionarioReport.Show();
        }

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e) {
            closeChild();
            pctLogo.Visible = true;
            EntradaDialog frmEntradaDialog = new EntradaDialog();
            frmEntradaDialog.ShowDialog();
        }
    }
}
