using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormViagens
{
    public partial class FormPedidos : Form
    {
        public FormPedidos()
        {
            InitializeComponent();
        }

        private void FormPedidos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmHome frm = new frmHome();
            frm.Show();
            this.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(UsuarioLogado.GetCaminhoPastaUsuario());
                FileInfo[] Files = d.GetFiles("*.txt");
                string arquivo = null;
                bool AchouArquivo = false;

                foreach (FileInfo file in Files)
                {
                    if (file.Name.ToUpper().Contains(txtNomePedido.Text.ToUpper()))
                    {
                        arquivo = d.FullName + @"\" + file.Name;
                        AchouArquivo = true;
                    }

                }

                if (AchouArquivo)
                {
                    string texto = File.ReadAllText(arquivo);
                    string TextoMostrarNaTela = "";


                    TextoMostrarNaTela += Util.Descriptografar(texto, UsuarioLogado.Instance().Senha);


                    MessageBox.Show(TextoMostrarNaTela);

                }
                else
                {
                    MessageBox.Show("Nenhum arquivo encontrado com esse nome.");

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
