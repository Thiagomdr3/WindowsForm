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
using ConexaoSQLite;

namespace ConexaoSQLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBoxEmail.Text == "" || textBoxSenha.Text == "")
            {
                MessageBox.Show("Por favor insira um loguin e senha","Formulário incompleto",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                textBoxSenha.Clear();
                textBoxEmail.Focus();
            }
            else
            {
                Conexao conexao = new ();

                try
                {
                    conexao.Conectar();
                    string sql = $"SELECT * FROM usuario WHERE email = '{textBoxEmail.Text}' AND senha = '{textBoxSenha.Text}'";
                    //string sql = "SELECT * FROM usuario WHERE email = '"+textBoxEmail.Text+"' AND senha = '"+textBoxSenha.Text+"'";

                    SQLiteDataAdapter dados = new (sql, conexao.conn); //Realizando a querry de consulta

                    DataTable usuario = new ();
                    dados.Fill(usuario); //passando os dados do meu DataAdapter para o meu DataTable

                    if (usuario.Rows.Count < 1)
                    {
                        MessageBox.Show("Usuário invalido", "Registro não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBoxSenha.Clear();
                        textBoxEmail.Focus();
                    }
                    else
                    {
                        string nome = usuario.Rows[0]["nome"].ToString();
                        string sobrenome = usuario.Rows[0]["sobrenome"].ToString();

                        MessageBox.Show($"Bem vindo {nome} {sobrenome}","Login",MessageBoxButtons.OK,MessageBoxIcon.None);
                    }

                    conexao.Desconectar();
                }
                catch(Exception E)
                {
                    MessageBox.Show(E.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLblCriarNovaConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm = new();
            frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Lista frmLista = new();
            frmLista.Show();
        }
    }
}
