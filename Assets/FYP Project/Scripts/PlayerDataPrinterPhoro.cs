using UnityEngine;
using System;
public class PlayerDataPrinterPhoro : MonoBehaviour
{
    public string playerName;
    public string adminNo;
    private PhoropterSceneHandler PhoropterSceneHandler;

    private void Start()
    {
        PhoropterSceneHandler = FindObjectOfType<PhoropterSceneHandler>();

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
            if (PhoropterSceneHandler != null)
            {
                PhoropterSceneHandler.HandleAttemptPhoropterCount(playerName, adminNo);

                // Check if data exists in the database before updating FirstAttempt
                bool dataExists = PhoropterSceneHandler.CheckDataExists(playerName, adminNo);
                if (!dataExists)
                {
                    // Get the current timestamp
                    DateTime currentTimestamp = DateTime.Now;

                    // Call the UpdateFirstAttemptData method with the current timestamp
                    PhoropterSceneHandler.UpdateFirstAttemptData(playerName, adminNo, currentTimestamp);
                }
            }
        }
    }
}
