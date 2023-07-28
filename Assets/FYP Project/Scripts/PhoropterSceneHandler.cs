using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.IO;
public class PhoropterSceneHandler : MonoBehaviour
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
    private const string AttemptPhoropterCountKey = "AttemptPhoropterCount";

    public void HandleAttemptPhoropterCount(string playerName, string adminNo)
    {
        // Load attemptKeratometerCount from the database
        int attemptPhoropterCount = LoadAttemptPhoropterCount(playerName, adminNo);

        // Increment the attemptKeratometerCount
        attemptPhoropterCount++;

        // Update the attemptKeratometerCount in the database
        UpdateAttemptPhoropterCount(playerName, adminNo, attemptPhoropterCount);

        // Save the updated attemptKeratometerCount to PlayerPrefs
        SaveAttemptPhoropterCount(attemptPhoropterCount);
    }

    private int LoadAttemptPhoropterCount(string playerName, string adminNo)
    {
        int attemptPhoropterCount = 0;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT AttemptPhoropter FROM student WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        attemptPhoropterCount = reader.GetInt32("AttemptPhoropter");
                    }
                }
            }
        }

        return attemptPhoropterCount;
    }

  private void UpdateAttemptPhoropterCount(string playerName, string adminNo, int attemptPhoropterCount)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "UPDATE student SET AttemptPhoropter = AttemptPhoropter + 1 WHERE AdminNo = @adminNo AND StudentName = @studentName";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@adminNo", adminNo);
            command.Parameters.AddWithValue("@studentName", playerName);
            Debug.Log("Phoropter now is " + attemptPhoropterCount);
            command.ExecuteNonQuery();
        }
    }
}

public bool CheckDataExists(string playerName, string adminNo)
    {
        bool dataExists = false;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT FirstAttempt FROM student WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                object result = command.ExecuteScalar();

                // Check if the FirstAttempt is NULL or has a value
                dataExists = (result != null && result != DBNull.Value);

                // Add debug logs
                Debug.Log($"CheckDataExists - FirstAttempt exists: {dataExists}");
            }
        }

        return dataExists;
    }

    public void UpdateFirstAttemptData(string playerName, string adminNo, DateTime timestamp)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE student SET FirstAttempt = @timestamp WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@timestamp", timestamp);
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                command.ExecuteNonQuery();
            }
        }
    }


    private void SaveAttemptPhoropterCount(int attemptPhoropterCount)
    {
        PlayerPrefs.SetInt(AttemptPhoropterCountKey, attemptPhoropterCount);
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
