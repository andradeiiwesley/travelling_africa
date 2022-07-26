using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormViagens
{
    public partial class FormReserva : Form
    {
        public FormReserva()
        {
            InitializeComponent();
        }

        private void FormReserva_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm3Pacotes frm3 = new frm3Pacotes();
            frm3.Show();
            this.Hide();
        }

        private void FimCompra_Click(object sender, EventArgs e)
        {
            if (ValidarNovaCompra())
            {
                string message = "Deseja finalizar sua compra?";
                string title = "Salvar";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    string texto = SalvarCompra();

                    var textoCripto = Util.Criptografar(texto, UsuarioLogado.Instance().Senha);

                    if (!Directory.Exists(UsuarioLogado.GetCaminhoPastaUsuario()))
                        Directory.CreateDirectory(UsuarioLogado.GetCaminhoPastaUsuario());

                    File.WriteAllText(UsuarioLogado.GetCaminhoPastaUsuario() + @"\Compra-" + cmbPedido.Text + ".txt", textoCripto);
                    MessageBox.Show("Compra realizada com sucesso!!", "Concluido");
                    Limpar();
                    frmHome frh = new frmHome();
                    frh.Show();
                    this.Hide();

                }
                else
                {

                }

            }

        }

        private bool ValidarNovaCompra()
        {
            bool formValido;

            if(cmbPedido.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                cmbPedido.Focus();
                formValido = false;
            }
            else if (txtNome.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                txtNome.Focus();
                formValido = false;
            }
            else if (txtSobrenome.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                txtSobrenome.Focus();
                formValido = false;
            }
            else if (cmbSexo.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                cmbSexo.Focus();
                formValido = false;
            }
            else if (mskDataNasc.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                mskDataNasc.Focus();
                formValido = false;
            }
            else if (mskCPF.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                mskCPF.Focus();
                formValido = false;
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                txtEmail.Focus();
                formValido = false;
            }
            else if (!Util.validarEMAIL(txtEmail.Text))
            {
                MessageBox.Show("INFORME UM EMAIL VÁLIDO!");
                txtEmail.Focus();
                formValido = false;

            }
            else if (cmbQuartos.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                cmbQuartos.Focus();
                formValido = false;
            }
            else if (mskEntrada.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                mskEntrada.Focus();
                formValido = false;
            }
            else if (mskSaida.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                mskSaida.Focus();
                formValido = false;
            }
            else if (cmbPessoas.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                cmbPessoas.Focus();
                formValido = false;
            }
            else if (cmbPagamento.Text == "")
            {
                MessageBox.Show("CAMPO OBRIGATÓRIO!");
                cmbPagamento.Focus();
                formValido = false;
            }

            else
            {
                formValido = true;
            }

            return formValido;
        }

        public void Limpar()
        {
            txtNome.Clear();
            txtSobrenome.Clear();
            mskDataNasc.Clear();
            mskCPF.Clear();
            txtEmail.Clear();
            mskEntrada.Clear();
            mskSaida.Clear();
            cmbPagamento.Items.Clear();
            cmbPedido.Items.Clear();
            cmbPessoas.Items.Clear();
            cmbQuartos.Items.Clear();
            cmbSexo.Items.Clear();

        }

        private string SalvarCompra()
        {
            var linha =

           "Nome: " +
           txtNome.Text + "; " + "\n" +
           "Sobrenome: " +
           txtSobrenome.Text + "; " + "\n" +
           "Gênero: " +
           cmbSexo.Text + "; " + "\n" +
           "Data de nascimento: " +
           mskDataNasc.Text + "; " + "\n" +
           "CPF: " +
           mskCPF.Text + "; " + "\n" +
           "Email: " +
           txtEmail.Text + "; " + "\n" +
           "Qtd quartos: " +
           cmbQuartos.Text + "; " + "\n" +
           "Datas: " + "\n" +
           "DataE: " +
           mskEntrada.Text + "; " + "\n" +
           "DataS: " +
           mskSaida.Text + "; " + "\n" +
           "Pesssoas: " +
           cmbPessoas.Text + "; " + "\n" +
           "Pagamento: " +
           cmbPagamento.Text + ";";

            MessageBox.Show(linha);

            return linha;





        }

        private void FimCompra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (Util.validarEMAIL(txtEmail.Text))
            {
                txtEmail.BackColor = Color.Orange;
            }
            else
            {
                txtEmail.BackColor = Color.GhostWhite;
            }
        }
    }
}
