using Microsoft.Data.SqlClient;
using System.Data;

string connectionString =
    "Server=DESKTOP-U81DRNA\\SQLEXPRESS;Database=db1;Integrated Security=True;TrustServerCertificate=True;";

using (SqlConnection con = new SqlConnection(connectionString))
{
    using (SqlCommand cmd = new SqlCommand("DepartmentData", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;

  
        cmd.Parameters.AddWithValue("@DepartmentName", "Product");

   
        SqlParameter totalSalaryParam = new SqlParameter("@TotalSalary", SqlDbType.Int);
        totalSalaryParam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(totalSalaryParam);

        con.Open();

      
        SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("Employees in Department:");

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["Id"]} - {reader["Name"]} - {reader["Department"]} - {(int)reader["Salary"]}"
            );
        }

        reader.Close();

   
        int totalSalary = Convert.ToInt32(cmd.Parameters["@TotalSalary"].Value);
        Console.WriteLine("Total Salary = " + totalSalary);
    }
}
