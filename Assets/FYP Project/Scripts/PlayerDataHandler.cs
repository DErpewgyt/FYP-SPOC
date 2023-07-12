using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        playerData.playerName = playerNameInput.text;
        playerData.playerAdminNo = playerAdminNoInput.text;

        // Convert player data to JSON string
        string jsonData = JsonUtility.ToJson(playerData);

        // Save player data to storage
        PlayerPrefs.SetString("PlayerData", jsonData);

        // Update player data in the MySQL table
        MySQLHandler mySQLHandler = FindObjectOfType<MySQLHandler>();
        if (mySQLHandler != null)
        {
            mySQLHandler.InsertStudentData(playerData.playerName, playerData.playerAdminNo);
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public string playerAdminNo;
    }
}
