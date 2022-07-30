using ProjectShauryaTech.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.DAL
{
    public class CartDAL
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CartDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public int Addtocart(Cart cart)
        {
            string qry = "insert into Cart values(@pid,@uid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", cart.Pid);
            cmd.Parameters.AddWithValue("@uid", cart.Uid);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result;

        }
        public List<Product> ViewProductsFromCart(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.Pid,p.Pname,p.Price, c.Cid,c.Uid from Product p " +
                        " inner join Cart c on c.Pid = p.Pid " +
                        " where c.Uid = @uid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Pid = Convert.ToInt32(dr["Pid"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    p.Cid = Convert.ToInt32(dr["Cid"]);
                    p.Uid = Convert.ToInt32(dr["Uid"]);
                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            else
            {
                return plist;
            }
        }
        public int RemoveFromCart(int id)
        {

            string qry = "delete from Cart where cid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
