using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_registratio_1
{
    internal class cid
    {
        SqlConnection con;
        SqlCommand cmd;

        public cid()
        {
             con = new SqlConnection("Data Source=DESKTOP-3T08844;Initial Catalog=mtester;Integrated Security=True");
        }
        public int Autocid()
        {
            con.Open();
            cmd = new SqlCommand("select Count(customer_ID) from Customer",con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            count += 1;
            con.Close();
            return count;

        }

    }
}
