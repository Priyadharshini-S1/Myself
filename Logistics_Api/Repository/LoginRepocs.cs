using Logistics_Api.Models;
using Microsoft.Data.SqlClient;

namespace Logistics_Api.Repository
{
    public class LoginRepocs
    {
        public LoginDet Authenticate(string username, string password)
        {
            string connectionString = "Data Source=10.1.193.167;Initial Catalog=log;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
            using (var con = new SqlConnection(connectionString))
            {


                using (var cmd = new SqlCommand("select dbo.user_logincheck(@username,@pwd)", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", password);


                    con.Open();

                    int c = Convert.ToInt32(cmd.ExecuteScalar());

                    if (c == 1)
                    {

                        Console.WriteLine("Welcome User");

                        con.Close();
                        return new LoginDet { Username = username };

                    }
                    else
                    {


                        Console.WriteLine("Account No or Password is wrong!!!");
                        return null;

                    }

                }

            }
        }
    }
}
