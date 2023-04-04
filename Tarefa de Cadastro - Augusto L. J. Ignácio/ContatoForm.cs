using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppContatoForm
{
    public partial class ContatoForm : Form
    {

        private MySqlConnection conexao;

        private MySqlCommand comando;

        public ContatoForm()
        {
            InitializeComponent();

            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=pds_augusto;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();
                
            conexao.Open();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text == "" || txtNome.Text == "" || txtTelefone.Text == "" || rdSexo1.Checked == false && rdSexo2.Checked == false)
                {
                    MessageBox.Show("Preencha corretamente os campos");
                    txtEmail.Clear();
                    txtNome.Clear();
                    txtTelefone.Clear(); 
                    rdSexo1.Checked = false;
                    rdSexo2.Checked = false;
                }

                else
                {
                    var nome = txtNome.Text;
                    var email = txtEmail.Text;
                    var telefone = txtTelefone.Text;
                    var sexo = "";
                    if (rdSexo1.Checked == true)
                    {
                        sexo = "Masculino";
                    }
                    else if (rdSexo2.Checked == true)
                    {
                        sexo = "Feminino";
                    }
                    var dataNasc = dateDataNascimento.Text;

                    string query = "INSERT INTO contato (nome_con, telefone_con, email_con, data_nasc_con, sexo_con) VALUES (@_nome, @_telefone, @_email, @_data_nasc, @_sexo)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_telefone", telefone);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_data_nasc", dataNasc);
                    comando.Parameters.AddWithValue("@_sexo", sexo);

                    comando.ExecuteNonQuery();
                    conexao.Close();

                    MessageBox.Show("Salvo com sucesso!");
                    Close();
                }

            } catch(Exception ex) {
                MessageBox.Show($"Ocorreu um erro ao salvar os dados ({ex.GetHashCode()})");
            }
        }
    }
}
