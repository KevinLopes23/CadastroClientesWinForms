
using CadastroClientesWinForms.Models;
using CadastroClientesWinForms.Services;
namespace CadastroClientesWinForms
{
    public partial class Form1 : Form
    {
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
    }



}
