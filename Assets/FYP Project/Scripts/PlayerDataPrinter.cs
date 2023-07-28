using UnityEngine;
using System;

public class PlayerDataPrinter : MonoBehaviour
{
    public string playerName;
    public string adminNo;
    private FINALSceneHandler finalSceneHandler;

    private void Start()
    {
        finalSceneHandler = FindObjectOfType<FINALSceneHandler>();

        // Retrieve player data from PlayerPrefs
        string jsonData = PlayerPrefs.GetString("PlayerData");
        if (!string.IsNullOrEmpty(jsonData))
        {
            // Deserialize the JSON data to PlayerData object
            PlayerDataHandler.PlayerData playerData = JsonUtility.FromJson<PlayerDataHandler.PlayerData>(jsonData);

            // Assign the player name and admin number
            playerName = playerData.playerName;
            adminNo = playerData.playerAdminNo;

            // Print the name and admin number
            Debug.Log("Player Name: " + playerName);
            Debug.Log("Admin Number: " + adminNo);

            // Call the HandleAttemptKeratometerCount method in FINALSceneHandler
            if (finalSceneHandler != null)
            {
                finalSceneHandler.HandleAttemptKeratometerCount(playerName, adminNo);

                // Check if data exists in the database before updating FirstAttempt
                bool dataExists = finalSceneHandler.CheckDataExists(playerName, adminNo);
                if (!dataExists)
                {
                    // Get the current timestamp
                    DateTime currentTimestamp = DateTime.Now;

                    // Call the UpdateFirstAttemptData method with the current timestamp
                    finalSceneHandler.UpdateFirstAttemptData(playerName, adminNo, currentTimestamp);
                }
            }
        }
    }
}
