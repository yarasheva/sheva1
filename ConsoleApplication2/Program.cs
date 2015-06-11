using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {

        static void Main(string[] args)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=ЯРИК-ПК\MSSQLSERVER1;User ID=sa;Password=yaroslavshevchenko18;Initial Catalog=sys_zarpl;" +
                    "Integrated Security=SSPI;Pooling=False";
                //ЯРИК-ПК\MSSQLSERVER1;User ID=sa;Password=***********
                cn.Open();
                string sqlQuery = "SELECT * FROM dbo.employee WHERE position =@position";
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, cn);
                sqlCmd.Parameters.Add("@position", SqlDbType.VarChar).Value = Console.ReadLine();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine(reader.GetString(2));
                    Console.WriteLine(reader.GetString(3));
                    Console.WriteLine(reader.GetInt32(4));
                    Console.WriteLine(reader.GetInt32(6));
                    Console.WriteLine();
                }
                Console.ReadLine();
                cn.Close();
            }
        }
    }
}
