using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Datagrid
{
    public partial class FormControleDeGastos : Form
    {
        public FormControleDeGastos()
        {
            InitializeComponent();
        }

        private MySqlConnectionStringBuilder conexaoBanco()
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "controlefinanceiro";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            conexaoBD.SslMode = 0;
            return conexaoBD;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            tbDescricao.Clear();
            tbValor.Clear();
            tbTipo.Clear();
            tbCategoria.Clear();
            dtpData.Value = DateTime.Now;
        }

        private void FormControleDeGastos_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM financas";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgControleDeGastos.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dgControleDeGastos.Rows[0].Clone();
                    row.Cells[0].Value = reader.GetInt32(0);
                    row.Cells[1].Value = reader.GetString(1);
                    row.Cells[2].Value = reader.GetString(2);
                    row.Cells[3].Value = reader.GetString(3);
                    row.Cells[4].Value = reader.GetString(4);
                    row.Cells[5].Value = reader.GetString(5);
                    dgControleDeGastos.Rows.Add(row);
                }

                realizaConexacoBD.Close();

            } catch (Exception ex)
            {
                MessageBox.Show("Can not open connection!");
                Console.WriteLine(ex.Message);
            }
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "INSERT INTO financas (descricaoFinanca, valorFinanca, tipoFinanca, categoriaFinanca, dataFinanca)" +
                    "VALUES ('" + tbDescricao.Text + "'," + tbValor.Text + ",'" + tbTipo.Text + "','" + tbCategoria.Text + "','" + dtpData.Value.ToString("yyyy-MM-dd") + "')";

                
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();
                MessageBox.Show("Inserido com sucesso");
                limparCampos();
                atualizarGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
