using UnityEngine;
using MySql.Data.MySqlClient;
using System;
public class MySQLHandler : MonoBehaviour
{
    private string connectionString = "Server=aws.connect.psdb.cloud;Database=spoc;Uid=ek5g4qg03uf2vzt45jza;Pwd=pscale_pw_okLlgZi2QrSCynilZyYm34zDM2BdlDY7hyusEPH6GDX";

   public void InsertStudentData(string studentName, string adminNo)
{
    // Check if the data already exists in the database
    if (DataExistsInDatabase(studentName, adminNo))
    {
        Debug.Log("Player data already exists in the database. No need to insert again.");
        return;
    }

    // Insert the data into the database
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "INSERT INTO student (StudentName, AdminNo) VALUES (@studentName, @adminNo)";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@studentName", studentName);
            command.Parameters.AddWithValue("@adminNo", adminNo);

            command.ExecuteNonQuery();
        }
    }
}

private bool DataExistsInDatabase(string studentName, string adminNo)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "SELECT COUNT(*) FROM student WHERE StudentName = @studentName AND AdminNo = @adminNo";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@studentName", studentName);
            command.Parameters.AddWithValue("@adminNo", adminNo);

            int count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }
    }
}
}
