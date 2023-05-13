using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public List<TextMeshProUGUI> timeTexts; // List of TextMeshProUGUI objects to display the best times
    private string filePath; // Path to the JSON file to load the times from
    private List<float> bestTimes; // List of the user's 5 best times

    public GameObject leaderboardPopup; // Reference to the leaderboard popup GameObject
    public bool leaderboardVisible = false; // Flag to track the visibility of the leaderboard popup

    private void Start()
    {
        filePath = Application.dataPath + "/SaveDataFile.json"; // Set the file path to the data directory and the file name to "SaveDataFile.json"
        bestTimes = new List<float>(); // Create a new empty list for the best times

        LoadBestTimes(); // Load the best times from the save file
        DisplayBestTimes(); // Display the loaded best times on the leaderboard
    }

    private void LoadBestTimes()
    {
        if (File.Exists(filePath))
        {
            // Load the JSON file and set the bestTimes list to the saved list
            string json = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestTimes = saveData.bestTimes;
        }
    }

    private void DisplayBestTimes()
    {
        // Sort the list of times in ascending order
        bestTimes.Sort();

        // Display the best times on the TextMeshProUGUI objects
        if (bestTimes.Count == 0)
        {
            timeTexts[0].text = "No Attempts Yet!"; // Display "No Attempts Yet!" if there are no saved best times
            for (int i = 1; i < timeTexts.Count; i++)
            {
                timeTexts[i].text = ""; // Hide the remaining TextMeshProUGUI objects
            }
        }
        else
        {
            for (int i = 0; i < timeTexts.Count; i++)
            {
                if (i < bestTimes.Count)
                {
                    int minutes = Mathf.FloorToInt(bestTimes[i] / 60f); // Calculate minutes
                    int seconds = Mathf.FloorToInt(bestTimes[i] % 60f); // Calculate seconds
                    timeTexts[i].text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format text in "mm:ss"
                }
                else
                {
                    timeTexts[i].text = "N/A"; // Display "N/A" if there are no more best times to display
                }
            }
        }
    }

    public void ToggleLeaderboard()
    {
        leaderboardVisible = !leaderboardVisible; // Toggle the visibility flag

        leaderboardPopup.SetActive(leaderboardVisible); // Set the visibility of the leaderboard popup based on the flag

        if (leaderboardVisible)
        {
            Time.timeScale = 0f; // Pause the game if the leaderboard is now visible
            LoadBestTimes(); // Load the best times when the leaderboard is shown
            DisplayBestTimes(); // Display the loaded best times on the leaderboard
        }
        else
        {
            Time.timeScale = 1f; // Resume the game if the leaderboard is now hidden
        }
    }
}