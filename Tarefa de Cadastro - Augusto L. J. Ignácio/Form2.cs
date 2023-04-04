using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppContatoForm
{
    public partial class Form2 : Form
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public Form2()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=pds_augusto;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void CarregarDados()
        {
            Conexao();
            string query = "SELECT * FROM contato";
            var comando = new MySqlCommand(query, conexao);
            var adapter = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvContato.DataSource = dt;
            dt.Columns["id_con"].ColumnName = "id";
            dt.Columns["nome_con"].ColumnName = "nome";
            dt.Columns["email_con"].ColumnName = "email";
            dt.Columns["telefone_con"].ColumnName = "telefone";
            dt.Columns["data_nasc_con"].ColumnName = "data de nascimento";
            dt.Columns["sexo_con"].ColumnName = "sexo";
        }
    }
}
