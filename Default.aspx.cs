using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CusPortal
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["CustomerPortalConnString"].ToString();
            var sqlConn = new SqlConnection(connString);
            var sql = "Select * from Customers";
            var myCommand = new SqlCommand(sql, sqlConn);
            var data = new DataSet();
            sqlConn.Open();
            var adapter = new SqlDataAdapter(myCommand);
            adapter.Fill(data); //dataset filled with data at this time

            dataTable.DataSource = data; //populate table
            dataTable.DataBind();
            var dataReader = myCommand.ExecuteReader();
            sqlConn.Close();
            
        }

        protected void btsave_Click(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["CustomerPortalConnString"].ToString();
            var sqlConn = new SqlConnection(connString);
            var sql = "insert into Customers (customerid,name, accnumber, address, datecreated) values(@i,@n, @ac, @a, @d)";
            try
            {
                var myCommand = new SqlCommand(sql, sqlConn);
                sqlConn.Open();
                myCommand.Parameters.AddWithValue("@i", tbId.Text);
                myCommand.Parameters.AddWithValue("@n", tbName.Text);
                myCommand.Parameters.AddWithValue("@ac", tbAcc.Text);
                myCommand.Parameters.AddWithValue("@a", tbAddress.Text);
                myCommand.Parameters.AddWithValue("@d", DateTime.Now);
                int numOfRowsAffected = myCommand.ExecuteNonQuery();
                if (numOfRowsAffected > 0)
                {
                    lbResult.Text = numOfRowsAffected.ToString() + "row(s) affected successfully ";
                }
                else
                    {
                    lbResult.Text = "No value inserted";
                }
            }
            catch(Exception)
            {
                lbResult.Text = "Error in handling your request";
            }
            finally
            {
               sqlConn.Close();
            }
           
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["CustomerPortalConnString"].ToString();
            var sqlConn = new SqlConnection(connString);
            var sql = ("update customers set name = @name, address = @address");
            try
            {
                var myCommand = new SqlCommand(sql, sqlConn);
                myCommand.Parameters.Add(new SqlParameter("@name", tbName.Text));
                myCommand.Parameters.Add(new SqlParameter("@address", tbAddress.Text));
                sqlConn.Open();
                myCommand.ExecuteNonQuery();
                lbResult.Text = "row(s) updated successfully ";
                //tbName.Text = " ";
                //tbAcc.Text = " ";
            }
            catch(Exception)
            {
                lbResult.Text = " unsuccessful ";
            }
            finally
            {
                sqlConn.Close();
            }
          

           

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["CustomerPortalConnString"].ToString();
            var sqlConn = new SqlConnection(connString);
            var sql = ("delete from customers where accnumber = @accnumber");
            //var sql = ("delete from customers where accnumber =  '" + tbAcc.Text + "' ");
            try
            {
                var myCommand = new SqlCommand(sql, sqlConn);
                myCommand.Parameters.Add(new SqlParameter("@accnumber", tbAcc.Text));
                sqlConn.Open();
                myCommand.ExecuteNonQuery();
                lbResult.Text = "row(s) deleted successfully ";
                //tbId.Text = " ";
                //tbName.Text = " ";
                //tbAcc.Text = " ";
                //tbAddress.Text = " ";
            }
            catch(Exception)
            {
                lbResult.Text =  "deleted unsuccessful ";
            }
            finally
            {
                sqlConn.Close();
            }


           
                
           
              }

   
        protected void Button4_Click(object sender, EventArgs e)
        {
            tbId.Text = "";
            tbName.Text = " ";
            tbAcc.Text = " ";
            tbAddress.Text = " ";
            lbResult.Text = "cleared successfully ";

        }
    }
}