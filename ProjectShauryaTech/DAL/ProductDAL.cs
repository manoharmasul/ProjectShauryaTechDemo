using ProjectShauryaTech.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.DAL
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Product> GetAllProducts()
        {
            List<Product> plist = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Pid = Convert.ToInt32(dr["Pid"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Company = dr["Company"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    plist.Add(p);

                }
            }
            con.Close();
            return plist;

        }
        public Product GetProductById(int pid)
        {
            Product p = new Product();
            string qry = "select * from Product where Pid=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.Pid = Convert.ToInt32(dr["Pid"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Company = dr["Company"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);

                }
            }
            con.Close();

            return p;

        }
        public int AddProduct(Product Prod)
        {
            string qry = "insert into Product values(@pname,@company,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pname", Prod.Pname);
            cmd.Parameters.AddWithValue("@company", Prod.Company);
            cmd.Parameters.AddWithValue("@price", Prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateProduct(Product Prod)
        {
            string qry = "update Product set Pname=@pname ,Company=@company, Price=@price where Pid=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", Prod.Pid);
            cmd.Parameters.AddWithValue("@pname", Prod.Pname);
            cmd.Parameters.AddWithValue("@company", Prod.Company);
            cmd.Parameters.AddWithValue("@price", Prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int pid)
        {
            string qry = "delete from Product where Pid=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", pid);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
       
    }
}

