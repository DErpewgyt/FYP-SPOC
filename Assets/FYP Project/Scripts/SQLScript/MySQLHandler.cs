using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.IO;
public class MySQLHandler : MonoBehaviour
{
    private string connectionString;

    private void Awake()
    {
        LoadConnectionString();
    }

    private void LoadConnectionString()
    {
        string server = Environment.GetEnvironmentVariable("MYSQL_SERVER");
        string database = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
        string uid = Environment.GetEnvironmentVariable("MYSQL_UID");
        string pwd = Environment.GetEnvironmentVariable("MYSQL_PWD");

        if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pwd))
        {
            // Load credentials from config.json if environment variables are not set
            string configPath = Path.Combine(Application.dataPath, "./StreamingAssets/config.json");

            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                MySQLConfig config = JsonUtility.FromJson<MySQLConfig>(json);

                if (config != null)
                {
                    server = config.Server;
                    database = config.Database;
                    uid = config.Uid;
                    pwd = config.Pwd;
                }
            }
            else
            {
                Debug.LogError("Config file not found! Make sure to create a config.json file.");
            }
        }

        // Build the connection string
        connectionString = $"Server={server};Database={database};Uid={uid};Pwd={pwd};";
    }
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

[Serializable]
public class MySQLConfig
{
    public string Server;
    public string Database;
    public string Uid;
    public string Pwd;
}
}
