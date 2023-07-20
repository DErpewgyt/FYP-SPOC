using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;
using System.IO;
public class PhoroCompletedData : MonoBehaviour
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
    private const string CompletedPhoropterCountKey = "CompletePhoropterCount";

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
            HandleCompletePhoropterCount(playerName, adminNo);

            // Set the hasSubmitted flag to true to prevent further updates
            hasSubmitted = true;
        }
    }

    public void HandleCompletePhoropterCount(string playerName, string adminNo)
    {
        // Load CompletedKeratometerCount from the database
        int completedPhoropterCount = LoadCompletedPhoropterCount(playerName, adminNo);

        // Increment the CompletedKeratometerCount
        completedPhoropterCount++;

        // Update the CompletedKeratometerCount in the database
        UpdateCompletedPhoropterCount(playerName, adminNo, completedPhoropterCount);

        // Save the updated CompletedKeratometerCount to PlayerPrefs
        SaveCompletedPhoropterCount(completedPhoropterCount);
    }

    private int LoadCompletedPhoropterCount(string playerName, string adminNo)
    {
        int completedPhoropterCount = 0;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT CompletedPhoropter FROM student WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        completedPhoropterCount = reader.GetInt32("CompletedPhoropter");
                    }
                }
            }
        }

        return completedPhoropterCount;
    }

    private void UpdateCompletedPhoropterCount(string playerName, string adminNo, int completedPhoropterCount)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE student SET CompletedPhoropter = @completedPhoropter WHERE AdminNo = @adminNo AND StudentName = @studentName";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@completedPhoropter", completedPhoropterCount);
                command.Parameters.AddWithValue("@adminNo", adminNo);
                command.Parameters.AddWithValue("@studentName", playerName);

                command.ExecuteNonQuery();
            }
        }
    }

    private void SaveCompletedPhoropterCount(int completedPhoropterCount)
    {
        PlayerPrefs.SetInt(CompletedPhoropterCountKey, completedPhoropterCount);
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
