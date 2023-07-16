using UnityEngine;
using UnityEngine.UI;

public class PlayerDataPrinter3 : MonoBehaviour
{
    public string playerName;
    public string adminNo;
    private PhoroCompletedData phorocompletehandler;
    public Button submitButton;

    private bool hasSubmitted;

    private void Start()
    {
        phorocompletehandler = FindObjectOfType<PhoroCompletedData>();
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
            if (phorocompletehandler != null)
            {
                phorocompletehandler.HandleCompletePhoropterCount(playerName, adminNo);
                hasSubmitted = true; // Set the flag to prevent further submission
            }
        }
    }
}
