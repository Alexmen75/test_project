using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCustInfo("981243123523");
        }

        static void GetCustInfo(string UIN)
        {
            string ConectString = "data source=DESKTOP-HBLM4T9\\SQLEXPRESS;initial catalog=KaspiLab;integrated security=True;";
            string GetInfo =
                "SELECT DateOfIssue, AGR.EndDate," +
                "(CASE WHEN (AGR.EndDate < CAST (GETDATE() AS DATE))" +
                "THEN 'НЕ ГОДЕН'" +
                "ELSE 'ГОДЕН' END) AS Profit," +
                "Product, ACC.Balance " +
                "FROM Agreement AGR " +
                "JOIN Accaunt ACC on AGR.AccauntID  = ACC.ID " +
                "JOIN Customer CUST on AGR.CustomerID = CUST.ID " +
                "where CUST.UIN = @UIN ";
        //"join Accaunt on Accaunt.ID = Agreement.AccauntID"+
        //"join Customer on Customer.ID = Agreement.CustomerID " +
            using (SqlConnection connect = new SqlConnection(ConectString))
            {
                SqlCommand command = new SqlCommand(GetInfo, connect);
                try
                {
                    connect.Open();
                    command.Parameters.AddWithValue("@UIN" , UIN);
                    SqlDataReader read = command.ExecuteReader();
                   while(read.Read())
                    {
                       for(int i = 0; i<read.FieldCount;  i++)
                        {
                            Console.Write(read[i] + "\t");
                        }
                        Console.WriteLine();
                    }
                    read.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
