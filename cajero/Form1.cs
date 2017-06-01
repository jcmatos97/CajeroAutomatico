using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cajero
{
    public partial class cajeroAutomatico : Form
    {
        public Double saldo = 5000;
        public String pin = "1234";
        public int num = 0;
        public cajeroAutomatico()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            teclado("1");
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            teclado("2");
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            teclado("3");
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            teclado("4");
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            teclado("5");
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            teclado("6");
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            teclado("7");
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            teclado("8");
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            teclado("9");
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            teclado("0");
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage1"])
            {
                if(textBox1.Text == pin)
                {
                    textBox1.Clear();
                    tabControl1.SelectTab(1);
                }
                else
                {
                    textBox1.Clear();
                    MessageBox.Show("Contraseña Incorrecta, intente de nuevo");
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage4"])
            {
                Double money = Convert.ToDouble(textBox2.Text);
                DialogResult dialogResult = MessageBox.Show("¿Esta Seguro?", "Confirmar Transacción", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    if(saldo-money < 0)
                    {
                        textBox2.Clear();
                        MessageBox.Show("El Retiro sobrepasa su saldo, intente de nuevo");
                    }
                    else
                    {
                        Double cash = money;
                        while (cash >= 100)
                        {
                            cash = cash - 100;
                            if(cash > 0 && cash < 100)
                            {
                                break;
                            }
                            else
                            {
                                cash = cash + 0;
                            }
                        }
                        saldo = saldo - (money - cash);
                        MessageBox.Show("Retiro de "+(money-cash)+" RD$ efectuado exitosamente"+Environment.NewLine+"Su saldo es: " +saldo+" RD$", "Recibo");
                        textBox2.Clear();
                        tabControl1.SelectTab(1);
                    }
                }
                if (dialogResult == DialogResult.No)
                {
                    textBox2.Clear();
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage7"])
            {
                if (textBox4.Text.Length < 1)
                {
                    MessageBox.Show("Debe digitar el PIN", "Alerta");
                    textBox4.Clear();
                }
                if (textBox4.Text.Length > 6)
                {
                    MessageBox.Show("El PIN es muy largo, no debe sobrepasar los 6 digitos", "Alerta");
                    textBox4.Clear();
                }
                if (textBox4.Text != pin)
                {
                    MessageBox.Show("El PIN es incorrecto", "Alerta");
                    textBox4.Clear();
                }
                if (textBox4.Text == pin)
                {
                    textBox4.Clear();
                    tabControl1.SelectTab(7);
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage8"])
            {
                num = num + 1;
                if(num == 2) { 
                    if (textBox5.Text.Length < 1)
                    {
                        MessageBox.Show("Debe digitar el PIN", "Alerta");
                        num = 1;
                        textBox5.Clear();
                    }
                    if (textBox5.Text.Length > 6)
                    {
                        MessageBox.Show("El PIN es muy largo, no debe sobrepasar los 6 digitos", "Alerta");
                        num = 1;
                        textBox5.Clear();
                    }
                    else
                    {
                        pin = textBox5.Text;
                        num = 0;
                        textBox5.Clear();
                        tabControl1.SelectTab(0);

                    }
                }
            }
        }

        private void borrar_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabControl1.TabPages["TabPage1"]) { 
                if(textBox1.Text.Length > 0){
                    String pin = textBox1.Text.Substring(0, textBox1.Text.Count() - 1);
                    textBox1.Text = pin;
                }
            }
            if(tabControl1.SelectedTab == tabControl1.TabPages["TabPage4"]) {
                if (textBox2.Text.Length > 0)
                {
                    String money = textBox2.Text.Substring(0, textBox2.Text.Count() - 1);
                    textBox2.Text = money;
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage7"])
            {
                if (textBox4.Text.Length > 0)
                {
                    String pin = textBox4.Text.Substring(0, textBox4.Text.Count() - 1);
                    textBox4.Text = pin;
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage8"])
            {
                if (textBox5.Text.Length > 0)
                {
                    String pin = textBox5.Text.Substring(0, textBox5.Text.Count() - 1);
                    textBox5.Text = pin;
                }
            }
        }
        private void cancelar_Click(object sender, EventArgs e)
        {
            if (!(tabControl1.SelectedTab == tabControl1.TabPages["TabPage1"]))
            {
                tabControl1.SelectTab(1);
                num = 0;
            }
        }

        private void option1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage3"])
            {
                retirarDinero("1000");
                tabControl1.SelectTab(1);
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage6"])
            {
                if (textBox3.Text.Length < 0)
                {
                    tarjetaLlamada("Claro", 0);
                }
                if (textBox3.Text.Length > 0)
                {
                    tarjetaLlamada("Claro", double.Parse(textBox3.Text));
                } 
            }
        }

        private void option2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage2"])
            {
                tabControl1.SelectTab(2);
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage3"])
            {
                num = num + 1;
                if (num == 2)
                {
                    retirarDinero("2000");
                    num = 0;
                    tabControl1.SelectTab(1);
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage6"])
            {
                if (textBox3.Text.Length < 0)
                {
                    tarjetaLlamada("Orange", 0);
                }
                if(textBox3.Text.Length > 0) {
                    tarjetaLlamada("Orange", double.Parse(textBox3.Text));
                }
            }
            
        }

        private void option3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage2"])
            {
                tabControl1.SelectTab(6);
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage3"])
            {
                tabControl1.SelectTab(3);
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage6"])
            {
                if (textBox3.Text.Length < 0)
                {
                    tarjetaLlamada("VIVA", 0);
                }
                if (textBox3.Text.Length > 0)
                {
                    tarjetaLlamada("VIVA", double.Parse(textBox3.Text));
                }
            }
        }

        private void option4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage3"])
            {
                retirarDinero("100");
                tabControl1.SelectTab(1);
            }
        }

        private void option5_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabControl1.TabPages["TabPage2"])
            {
                tabControl1.SelectTab("TabPage6");
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage3"])
            {
                retirarDinero("200");
                tabControl1.SelectTab("TabPage2");
            }
            else
            {

            }
        }

        private void option6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage2"])
            {
                label19.Text = Convert.ToString(saldo)+" RD$";
                tabControl1.SelectTab(4);
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage3"])
            {
                retirarDinero("500");
                tabControl1.SelectTab(1);
            }

        }
        private void retirarDinero(String cash)
        {
            textBox2.Text = cash;
            Double money = Convert.ToDouble(textBox2.Text);
            DialogResult dialogResult = MessageBox.Show("¿Esta Seguro?", "Confirmar Transacción", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (saldo - money < 0)
                {
                    textBox2.Clear();
                    MessageBox.Show("El Retiro sobrepasa su saldo, intente de nuevo");
                }
                else
                {
                    saldo = saldo - money;
                    MessageBox.Show("Retiro de " + money + " RD$ efectuado exitosamente" + Environment.NewLine + "Su saldo es: " + saldo + " RD$", "Recibo");
                    textBox2.Clear();
                    tabControl1.SelectTab(1);
                }
            }
            if (dialogResult == DialogResult.No)
            {
                textBox2.Clear();
            }
        }
        private void tarjetaLlamada(String telefonica, double tarjeta)
        {
            if (tarjeta<50)
            {
                MessageBox.Show("El monto debe ser mayor a 50 RD$", "Alerta");
                textBox3.Clear();
            }
            if (tarjeta > saldo)
            {
                MessageBox.Show("El monto supera su saldo Disponible", "Alerta");
                textBox3.Clear();
            }
            if((tarjeta > 49) &&(tarjeta < saldo+1))
            {
                DialogResult dialogResult = MessageBox.Show("¿Esta Seguro?", "Confirmar Transacción", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saldo = saldo - tarjeta;
                    MessageBox.Show("Tarjeta "+telefonica+" de " + tarjeta + " RD$ obtenida exitosamente" + Environment.NewLine + "Su saldo es: " + saldo + " RD$", "Recibo");
                    textBox3.Clear();
                    tabControl1.SelectTab(1);
                }
                if (dialogResult == DialogResult.No)
                {
                    textBox3.Clear();
                    tabControl1.SelectTab(1);
                }
            }
        }
        private void teclado(String numero)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage1"])
            {
                textBox1.Text += numero;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage4"])
            {
                textBox2.Text += numero;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage6"])
            {
                textBox3.Text += numero;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage7"])
            {
                textBox4.Text += numero;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["TabPage8"])
            {
                textBox5.Text += numero;
            }
        }
    }
}
