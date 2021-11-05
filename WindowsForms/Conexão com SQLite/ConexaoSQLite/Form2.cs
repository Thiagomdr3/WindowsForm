using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ConexaoSQLite
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxNome.Text == "" || textBoxSobrenome.Text == "" || textBoxEmail.Text == "" || textBoxSenha.Text == "")
            {
                MessageBox.Show("Existem campos vazios", "Formulário incompleto!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxNome.Focus();
            }
            else
            {
                Conexao conexao = new();


                try
                {
                    conexao.Conectar();

                    string sql = $"INSERT INTO usuario (nome, sobrenome, email, senha) VALUES ('{textBoxNome.Text}','{textBoxSobrenome.Text}','{textBoxEmail.Text}','{textBoxSenha.Text}')";

                    SQLiteCommand comando = new(sql, conexao.conn);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Registro efetuado com sucesso", "Registro efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBoxNome.Clear();
                    textBoxSobrenome.Clear();
                    textBoxEmail.Clear();
                    textBoxSenha.Clear();
                    textBoxNome.Focus();

                    conexao.Desconectar();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                


                
            }
        }
    }
}
