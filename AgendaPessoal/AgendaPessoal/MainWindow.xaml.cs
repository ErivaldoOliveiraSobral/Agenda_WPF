using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgendaPessoal
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        string conexao = @"Server=.\sqlexpress;Database=bdcadastro;Trusted_Connection=True";
        bool novo;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCriar_Click(object sender, RoutedEventArgs e)
        {
            string sql = "insert into pessoa(nome,telefone,endereco)values(@nome,@telefone,@endereco)";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@nome", this.txtNome.Text));
            cmd.Parameters.Add(new SqlParameter("@telefone", this.txtTelefone.Text));
            cmd.Parameters.Add(new SqlParameter("@endereco", this.txtEndereco.Text));
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Cadastado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            this.txtNome.Clear();
            this.txtTelefone.Clear();
            this.txtEndereco.Clear();
            this.txtId.Clear();
     
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            string sql = "delete from pessoa where id=@id";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@id", this.txtId.Text));
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Deletado com sucesso!");
                else
                    MessageBox.Show("ID Não Encontrado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            this.txtNome.Clear();
            this.txtTelefone.Clear();
            this.txtEndereco.Clear();
            this.txtId.Clear();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            string sql = "update pessoa set nome=@nome,telefone=@telefone,endereco=@endereco where id=@id";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@id", this.txtId.Text));
            cmd.Parameters.Add(new SqlParameter("@nome", this.txtNome.Text));
            cmd.Parameters.Add(new SqlParameter("@telefone", this.txtTelefone.Text));
            cmd.Parameters.Add(new SqlParameter("@endereco", this.txtEndereco.Text));
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Alterado com sucesso!");
                else
                    MessageBox.Show("ID Não Encontrado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            this.txtNome.Clear();
            this.txtTelefone.Clear();
            this.txtEndereco.Clear();
            this.txtId.Clear();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            this.txtNome.Clear();
            this.txtTelefone.Clear();
            this.txtEndereco.Clear();
            this.txtId.Clear();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string sql = "select id,nome, telefone, endereco from pessoa where nome = @nome";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@nome", this.txtBoxBuscar.Text));
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader saida;
            con.Open();

            try
            {
                saida = cmd.ExecuteReader();
                if (saida.Read())
                {
                    txtId.Text = saida[0].ToString();
                    txtNome.Text = saida[1].ToString();
                    txtTelefone.Text = saida[2].ToString();
                    txtEndereco.Text = saida[3].ToString();
                }
                else
                {
                    MessageBox.Show("Nenhum Registro Encontado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            txtBoxBuscar.Clear();
        }

        private void txtNome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEndereco_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
