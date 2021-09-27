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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                comandoMySql.CommandText = "UPDATE financas SET descricaoFinanca = '" + tbDescricao.Text + "', " +
                    "valorFinanca = " + tbValor.Text + ", " +
                    "tipoFinanca = '" + tbTipo.Text + "', " +
                    "categoriaFinanca = '" + tbCategoria.Text + "', " +
                    "dataFinanca = '" + dtpData.Value.ToString("yyyy-MM-dd") + "' " +
                    " WHERE idFinanca = " + tbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Atualizado com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                comandoMySql.CommandText = "DELETE FROM financas WHERE idFinanca = " + tbID.Text + "";

                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Deletado com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }
        }

        private void dgControleDeGastos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgControleDeGastos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgControleDeGastos.CurrentRow.Selected = true;
                //preenche os textbox com as células da linha selecionada
                tbID.Text = dgControleDeGastos.Rows[e.RowIndex].Cells["colID"].FormattedValue.ToString();
                tbDescricao.Text = dgControleDeGastos.Rows[e.RowIndex].Cells["colDescricao"].FormattedValue.ToString();
                tbValor.Text = dgControleDeGastos.Rows[e.RowIndex].Cells["colValor"].FormattedValue.ToString();
                tbTipo.Text = dgControleDeGastos.Rows[e.RowIndex].Cells["colTipo"].FormattedValue.ToString();
                tbCategoria.Text = dgControleDeGastos.Rows[e.RowIndex].Cells["colCategoria"].FormattedValue.ToString();
                dtpData.Text = dgControleDeGastos.Rows[e.RowIndex].Cells["colData"].FormattedValue.ToString();
            }
        }
    }
}
