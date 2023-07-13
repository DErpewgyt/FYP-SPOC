using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MySql.Data.MySqlClient;
using System;
public class PlayerDataHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_InputField playerAdminNoInput;
    public GameObject submitButton; // Assign the submit button GameObject in the Unity Editor

    private PlayerData playerData;

    private void Start()
    {
        // Load player data
        LoadPlayerData();

        // Add event listener to the input fields
        playerNameInput.onValueChanged.AddListener(UpdatePlayerName);
        playerAdminNoInput.onValueChanged.AddListener(UpdatePlayerAdminNo);

        // Add click listener to the submit button
        Button buttonComponent = submitButton.GetComponent<Button>();
        if (buttonComponent != null)
        {
            buttonComponent.onClick.AddListener(SavePlayerData);
        }
    }
private string connectionString = "Server=aws.connect.psdb.cloud;Database=spoc;Uid=ek5g4qg03uf2vzt45jza;Pwd=pscale_pw_okLlgZi2QrSCynilZyYm34zDM2BdlDY7hyusEPH6GDX";


    private void LoadPlayerData()
    {
        // Retrieve player data from storage
        string jsonData = PlayerPrefs.GetString("PlayerData");
        if (!string.IsNullOrEmpty(jsonData))
        {
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
            playerNameInput.text = playerData.playerName;
            playerAdminNoInput.text = playerData.playerAdminNo;
        }
        else
        {
            // Create a new player data object
            playerData = new PlayerData();
        }
    }

    private void UpdatePlayerName(string newName)
    {
        // Update player name
        playerData.playerName = newName;
    }

    private void UpdatePlayerAdminNo(string newNo)
    {
        // Update player admin number
        playerData.playerAdminNo = newNo;
    }

   public void SavePlayerData()
{
    // Update player name and admin number from input fields
    string newPlayerName = playerNameInput.text;
    string newAdminNo = playerAdminNoInput.text;

    // Convert player data to JSON string
    string jsonData = JsonUtility.ToJson(playerData);

    // Save player data to storage
    PlayerPrefs.SetString("PlayerData", jsonData);

    // Update player data in the MySQL table
    MySQLHandler mySQLHandler = FindObjectOfType<MySQLHandler>();
    if (mySQLHandler != null)
    {
        mySQLHandler.InsertStudentData(newPlayerName, newAdminNo);
    }
}


private bool DataExistsInDatabase(string playerName, string adminNo)
{
    // Query the database to check if the player data already exists
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "SELECT COUNT(*) FROM student WHERE StudentName = @playerName AND AdminNo = @adminNo";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@playerName", playerName);
            command.Parameters.AddWithValue("@adminNo", adminNo);

            int count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }
    }
}


    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public string playerAdminNo;
    }
}
