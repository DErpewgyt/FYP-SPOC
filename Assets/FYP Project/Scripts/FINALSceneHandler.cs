using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.IO;
public class FINALSceneHandler : MonoBehaviour
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
    private const string AttemptKeratometerCountKey = "AttemptKeratometerCount";

    public void HandleAttemptKeratometerCount(string playerName, string adminNo)
    {
        // Load attemptKeratometerCount from the database
        int attemptKeratometerCount = LoadAttemptKeratometerCount(playerName, adminNo);

        // Increment the attemptKeratometerCount
        attemptKeratometerCount++;

        // Update the attemptKeratometerCount in the database
        UpdateAttemptKeratometerCount(playerName, adminNo, attemptKeratometerCount);

        // Save the updated attemptKeratometerCount to PlayerPrefs
        SaveAttemptKeratometerCount(attemptKeratometerCount);
    }

    private int LoadAttemptKeratometerCount(string playerName, string adminNo)
    {
        int attemptKeratometerCount = 0;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT AttemptKeratometer FROM student WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        attemptKeratometerCount = reader.GetInt32("AttemptKeratometer");
                    }
                }
            }
        }

        return attemptKeratometerCount;
    }

  private void UpdateAttemptKeratometerCount(string playerName, string adminNo, int attemptKeratometerCount)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "UPDATE student SET AttemptKeratometer = AttemptKeratometer + 1 WHERE AdminNo = @adminNo AND StudentName = @studentName";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@adminNo", adminNo);
            command.Parameters.AddWithValue("@studentName", playerName);
            Debug.Log("Keratometer now is " + attemptKeratometerCount);
            command.ExecuteNonQuery();
        }
    }
}


    private void SaveAttemptKeratometerCount(int attemptKeratometerCount)
    {
        PlayerPrefs.SetInt(AttemptKeratometerCountKey, attemptKeratometerCount);
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
