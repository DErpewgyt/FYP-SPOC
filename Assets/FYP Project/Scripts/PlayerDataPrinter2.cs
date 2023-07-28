using UnityEngine;
using UnityEngine.UI;

public class PlayerDataPrinter2 : MonoBehaviour
{
    public string playerName;
    public string adminNo;
    private KeraCompletedData keracompletehandler;
    public Button submitButton;
    public Readings readingsScript;
    private bool hasSubmitted;

    private void Start()
    {
        keracompletehandler = FindObjectOfType<KeraCompletedData>();
        hasSubmitted = false;

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
        }
        else
        {
            Debug.Log("Player data not found.");
        }

        // Add click listener to the submit button
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(SubmitButtonClicked);
        }
    }

    private void SubmitButtonClicked()
    {
        if (!hasSubmitted)
        {
            // Check if the readingsScript is both correct
            if (readingsScript != null && readingsScript.IsBothCorrect)
            {
                // Increment the completed keratometer count and update the database
                keracompletehandler.HandleCompleteKeratometerCount(playerName, adminNo);
                keracompletehandler.UpdateLastAttemptTimestamp(playerName, adminNo);
            }

            // Update the LastAttemptTimestamp regardless of the correctness of the readings
            keracompletehandler.UpdateLastAttemptTimestamp(playerName, adminNo);

            hasSubmitted = true; // Set the flag to prevent further submission
        }
    }
}
