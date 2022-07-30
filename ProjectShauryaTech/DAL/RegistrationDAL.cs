using ProjectShauryaTech.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.DAL
{
    public class RegistrationDAL
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public RegistrationDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public int Registration(Registration registration)
        {
            string qry="Insert into Users values(@uname,@email,@password,@rid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@uname", registration.Uname);
            cmd.Parameters.AddWithValue("email", registration.Email);
            cmd.Parameters.AddWithValue("@password", registration.Password);
            cmd.Parameters.AddWithValue("@rid",102);
          
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;

        }
        public Registration LogIn(Registration registration)
        {
            Registration re = new Registration();
            string qry = "select * from Users where Email=@email";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", registration.Email);
           
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    re.Uid = Convert.ToInt32(dr["Uid"]);
                    re.Uname = dr["Uname"].ToString();
                    re.Email = dr["Email"].ToString();
                    re.Password = dr["Password"].ToString();
                    re.RId = Convert.ToInt32(dr["RId"]);

                }
            }
            con.Close();
            return re;

        }
    }
}

