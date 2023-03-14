using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
           
          
            
        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            dbclass db = new dbclass();
           bool sonuc= db.giris(txtad.Text,txtsifre.Text);
            if (!sonuc)
            {
                txtsifre.Text = "";
                txtad.Text = "";
            }
            else
                this.Hide();
        }
    }
}
