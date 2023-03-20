using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Customer_registratio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void btn_register_Click(object sender, EventArgs e)
        {
            //int tp;
            //int nic;

           // tp = Convert.ToInt32(txt_phoneNo.Text);
            //nic = Convert.ToInt32(txt_nicNumber.Text);

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-3T08844;Initial Catalog=MotorSpa;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Customer values ('" + txt_cid.Text + "','" + txt_fName.Text + "','" + txt_lname.Text + "','" + txt_Email.Text + "','" + txt_phoneNo.Text + "','" + txt_Address.Text + "','" + txt_nicNumber.Text + "')", con);


                if (txt_fName.Text.Any(char.IsDigit) || string.IsNullOrEmpty(txt_fName.Text))
                {
                    MessageBox.Show("First Name cannot have numbers or cannot be blank", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_lname.Text.Any(char.IsDigit) || string.IsNullOrEmpty(txt_lname.Text))
                {
                    MessageBox.Show("Last Name cannot have numbers or cannot be blank", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_phoneNo.Text.Any(char.IsLetter) || string.IsNullOrEmpty(txt_phoneNo.Text))
                {
                    MessageBox.Show("Telephone cannot be empty or cannot have letters", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txt_cid.Text))
                {
                    MessageBox.Show("Customer ID cannot be blank", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txt_Address.Text))
                {
                    MessageBox.Show("Address cannot be blank", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_nicNumber.Text.Length == 0)
                {
                    MessageBox.Show("NIC number cannot be blank", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   MessageBox.Show(this, "data saved succesfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter Numbers only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("somthing went wrong", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_cid.Clear();
            txt_fName.Clear();
            txt_lname.Clear();
            txt_Email.Clear();
            txt_Address.Clear();
            txt_nicNumber.Clear();
            txt_phoneNo.Clear();
        }
    }
}
