using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWindowsForms
{
    public partial class Frm_ValidaCPF2 : Form
    {
        public Frm_ValidaCPF2()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Msk_CPF.Text = "";
        }

        private void Btn_Valida_Click(object sender, EventArgs e)
        {
            string vConteudo; //variable to verify if the content of the Msk_CPF is valid
            vConteudo = Msk_CPF.Text;
            vConteudo = vConteudo.Replace(",", "").Replace("-", ""); // we need to replace "." and "-" of the CPF number to blank spaces 
            vConteudo = vConteudo.Trim(); // trim is filling up the blank spaces

            if(vConteudo == "") //if the content of the Msk_CPF is empty 
            {
                MessageBox.Show("Você deve digitar um CPF", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(vConteudo.Length != 11) 
                {
                    MessageBox.Show("CPF deve ter 11 dígitos", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Você deseja realmente validar o CPF?", "Mensagem de Validação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //If the user click on "Yes" the logic to validate CPF is triggered
                    {
                        bool validaCPF = false;
                        validaCPF = Cls_Uteis.Valida(Msk_CPF.Text);
                        if (validaCPF == true)
                        {
                            MessageBox.Show("CPF Válido", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Information); // first string is the message, second string caption              
                        }
                        else
                        {
                            MessageBox.Show("CPF Inválido", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
               
            }                       
        }
    }
}
