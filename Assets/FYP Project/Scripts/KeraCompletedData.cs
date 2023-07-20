using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;
using System.IO;
public class KeraCompletedData : MonoBehaviour
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
            string configPath = Path.Combine(Application.dataPath, "./config.json");

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
    private const string CompletedKeratometerCountKey = "CompleteKeratometerCount";

    public Button submitButton; // Assign the submit button GameObject in the Unity Editor

    private string playerName;
    private string adminNo;
    private bool hasSubmitted;

    private void Start()
    {
        // Add click listener to the submit button
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(HandleSubmitButtonClick);
        }

        // Reset the hasSubmitted flag when the scene is loaded
        hasSubmitted = false;
    }

    public void SetPlayerData(string playerName, string adminNo)
    {
        this.playerName = playerName;
        this.adminNo = adminNo;
    }

    private void HandleSubmitButtonClick()
    {
        if (!hasSubmitted)
        {
            // Execute the method to handle complete keratometer count
            HandleCompleteKeratometerCount(playerName, adminNo);

            // Set the hasSubmitted flag to true to prevent further updates
            hasSubmitted = true;
        }
    }

    public void HandleCompleteKeratometerCount(string playerName, string adminNo)
    {
        // Load CompletedKeratometerCount from the database
        int completedKeratometerCount = LoadCompletedKeratometerCount(playerName, adminNo);

        // Increment the CompletedKeratometerCount
        completedKeratometerCount++;

        // Update the CompletedKeratometerCount in the database
        UpdateCompletedKeratometerCount(playerName, adminNo, completedKeratometerCount);

        // Save the updated CompletedKeratometerCount to PlayerPrefs
        SaveCompletedKeratometerCount(completedKeratometerCount);
    }

    private int LoadCompletedKeratometerCount(string playerName, string adminNo)
    {
        int completedKeratometerCount = 0;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT CompletedKeratometer FROM student WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        completedKeratometerCount = reader.GetInt32("CompletedKeratometer");
                    }
                }
            }
        }

        return completedKeratometerCount;
    }

    private void UpdateCompletedKeratometerCount(string playerName, string adminNo, int completedKeratometerCount)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE student SET CompletedKeratometer = @completedKeratometer WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@completedKeratometer", completedKeratometerCount);
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                command.ExecuteNonQuery();
            }
        }
    }

    private void SaveCompletedKeratometerCount(int completedKeratometerCount)
    {
        PlayerPrefs.SetInt(CompletedKeratometerCountKey, completedKeratometerCount);
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
