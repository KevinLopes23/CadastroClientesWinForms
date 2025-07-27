
using CadastroClientesWinForms.Models;
using CadastroClientesWinForms.Services;
namespace CadastroClientesWinForms
{
    public partial class Form1 : Form
    {
        private int? clienteSelecionadoId = null;
        public Form1()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            dgvClientes.DataSource = ClienteService.ListarTodos();

        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            dtNascimento.Value = DateTime.Today;
            clienteSelecionadoId = null;
        }


        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                var row = dgvClientes.Rows[e.RowIndex];

                clienteSelecionadoId = Convert.ToInt32(row.Cells["id"].Value);
                txtNome.Text = row.Cells["nome"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtTelefone.Text = row.Cells["telefone"].Value.ToString();
                dtNascimento.Value = Convert.ToDateTime(row.Cells["data_nascimento"].Value);

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                DataNascimento = dtNascimento.Value
            };


            if (clienteSelecionadoId.HasValue)
            {
                cliente.Id = clienteSelecionadoId.Value;
                ClienteService.Atualizar(cliente);
                MessageBox.Show("Cliente atualizado com sucesso!");
            }
            else
            {
                ClienteService.Inserir(cliente);
                MessageBox.Show("Cliente cadastrado com sucesso!");
            }

            LimparCampos();
            CarregarClientes();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (clienteSelecionadoId.HasValue)
            {
                var confirm = MessageBox.Show("Tem certeza que deseja excluir o cliente?",
                                              "Confirmar Exclusão",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    ClienteService.Excluir(clienteSelecionadoId.Value);
                    MessageBox.Show("Cliente excluído com sucesso!");
                    LimparCampos();
                    CarregarClientes();
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para excluir.");
            }
        }
    }



}
