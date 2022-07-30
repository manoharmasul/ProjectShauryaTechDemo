using ProjectShauryaTech.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.DAL
{
    public class OrdersDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public OrdersDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        //public int  AddOrder(Orders orders)
        //{
        //    string qry = "insert into Orders values (@uid,@pid,@qty";
        //    cmd = new SqlCommand(qry, con);
        //    cmd.Parameters.AddWithValue("@uid", orders.Uid);
        //    cmd.Parameters.AddWithValue("@pid", orders.Pid);
        //    cmd.Parameters.AddWithValue("@qty", orders.Qty);
        //    con.Open();
        //    int result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return result;
        //}
        //public List<Orders> ViewOrder()
        //{
        //    List<Orders> Olist = new List<Orders>();
        //    string qry="select"
        //}
        
    }
}
