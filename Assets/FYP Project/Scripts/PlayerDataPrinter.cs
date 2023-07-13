using UnityEngine;

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
            }
        }
        else
        {
            Debug.Log("Player data not found.");
        }
    }
}
