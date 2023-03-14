using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BOOKSTORE
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }
        public void dovizgoster()
        {
            try
            {
                XmlDocument xmlveri = new XmlDocument();
                try
                {
                    xmlveri.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                }
                catch (Exception)
                {

                    MessageBox.Show("İNTERNET BAGLANTISI YOK");
                    timer1.Enabled = false;
                    goto bura;
                }
            
                decimal dolar = Convert.ToDecimal(xmlveri.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText);
                decimal euro = Convert.ToDecimal(xmlveri.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText);
                decimal sterlin = Convert.ToDecimal(xmlveri.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText);
                lbldolar.Text = dolar.ToString();
                lbleuro.Text = euro.ToString();
                lblsterlin.Text = sterlin.ToString();


            }
            catch (XmlException ex)
            {

                timer1.Stop();
                MessageBox.Show(ex.ToString());
            }
        bura:;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            dovizgoster();
        }

        private void home_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            kitap kt = new kitap();
            kt.Show();
            this.Hide();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            radyo rd = new radyo();
            rd.Show();
            this.Hide();
        }
    }
}
