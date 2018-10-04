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
    public partial class frmLogin : Form {

        public frmLogin() {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            SqlConnection conn = (SqlConnection) MainData.getNewConnection();
            SqlCommand comm;
            SqlDataReader reader;

            String user = tbxUser.Text;
            String passowrd = tbxPassword.Text;
            String userName = "";
            char accessLevel;
            int userID = 0;
            int funcionario_ID = 0;

            errorProvider1.Clear();

            if ("".Equals(user)) {
                errorProvider1.SetError(tbxUser, "O campo do usuário deve estar preenchido!");
                return;
            }
            if ("".Equals(passowrd)) {
                errorProvider1.SetError(tbxPassword, "O campo da senha deve estar preenchido!");
                return;
            }

            comm = new SqlCommand("SELECT u.usuario_ID, f.nome, u.nivelAcesso, f.funcionario_ID "+
                                    "FROM usuario u, funcionario f "+
                                   "WHERE u.funcionario_ID = f.funcionario_ID "+
                                     "AND u.nome = @nome "+
                                     "AND u.senha = @senha", conn);
            comm.Parameters.Add("@nome", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@nome"].Value = user;

            comm.Parameters.Add("@senha", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@senha"].Value = passowrd;

            try {
                conn.Open();
                reader = comm.ExecuteReader();

                if (reader.Read()) {
                    userID = Convert.ToInt32(reader["usuario_ID"].ToString());
                    userName = reader["nome"].ToString();
                    accessLevel = Convert.ToChar(reader["nivelAcesso"].ToString());
                    funcionario_ID = Convert.ToInt32(reader["funcionario_ID"].ToString());

                    MainData.setLoggedUser(userID, accessLevel, funcionario_ID);
                    frmMain main = new frmMain();
                    main.SetUserStatusBar(userName);
                    main.Show();
                    //this.Close();
                    this.Visible = false;
                } else {
                    MessageBox.Show("Usuário inexistente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } catch (Exception error) {
                MessageBox.Show(error.Message, "Erro ao tentar conectar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                conn.Close();
            }
        }
    }
}
