using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI timeText; // Reference to the Text component to display the time
    private float timeElapsed; // Amount of time that has elapsed since the stopwatch started
    public bool timerRunning; // Flag to indicate whether the stopwatch is running or not
    public bool conditionsCompleted = false; // Flag to indicate whether all conditions have been completed
    private string filePath; // Path to the JSON file to save the times to
    private List<float> bestTimes; // List of the user's 5 best times
    public bool resetData; // Bool to check to trgigger the reset of saved data
    public GameObject LevelCompleteScreen;
    public GameObject EndBtn;

    private void Start()
    {
        timeElapsed = 0f;
        timerRunning = false; // Start the stopwatch when the scene loads
        filePath = Application.dataPath + "/SaveDataFile.json"; // Set the file path to the data directory and the file name to "SaveDataFile.json"
        bestTimes = new List<float>(); // Create a new empty list for the best times

        if (File.Exists(filePath))
        {
            // Load the JSON file and set the bestTimes list to the saved list
            string json = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestTimes = saveData.bestTimes;
        }
    }

    private void Update()
    {
        if (timerRunning)
        {
            timeElapsed += Time.deltaTime; // Increase the time elapsed by the amount of time since the last frame
            int minutes = Mathf.FloorToInt(timeElapsed / 60f); // Calculate minutes
            int seconds = Mathf.FloorToInt(timeElapsed % 60f); // Calculate seconds
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format text in "mm:ss"
            if (conditionsCompleted) // To be changed to check if all the checklist are checked
            {
                SaveTime(); // Save time taken to the JSON
            }
        }

        if (resetData) // To be replaced
        {
            // Clear the bestTimes list
            bestTimes.Clear();

            // Create a new SaveData object with the cleared bestTimes list
            SaveData saveData = new SaveData();
            saveData.bestTimes = bestTimes;

            // Convert the SaveData object to JSON
            string json = JsonUtility.ToJson(saveData);

            // Write the JSON string to the file
            File.WriteAllText(filePath, json);
        }
    }

    public void CompleteConditions() // To be changed to check if all the checklist are checked
    {
        conditionsCompleted = true;
    }

    private void SaveBestTimes()
    {
        bestTimes.Sort(); // Sort the list of times in ascending order
        if (bestTimes.Count > 5)
        {
            bestTimes.RemoveRange(5, bestTimes.Count - 5); // Remove any times after the 5th best time
        }
        SaveData data = new SaveData(); // Save the bestTimes into JSON
        data.bestTimes = bestTimes;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        print("saved the time");
    }

    private void SaveTime()
    {
        if (bestTimes.Count < 5)
        {
            bestTimes.Add(timeElapsed); // If there are less than 5 best times just add the time to list
        }
        else
        {
            float slowestTime = bestTimes[bestTimes.Count - 1]; // Get the slowest time from the list
            if (timeElapsed < slowestTime)
            {
                bestTimes[bestTimes.Count - 1] = timeElapsed; // If the time taken is faster than the slowest time, replace the slowest time with the new time
            }
            else
            {
                conditionsCompleted = false; // Reset the flag to indicate that all conditions have not been completed
                levelComplete();
                return; // If the time taken is slower than the slowest time don's need save
            }
        }
        SaveBestTimes(); // Save the time to JSON
        conditionsCompleted = false; // Reset the flag to indicate that all conditions have not been completed
        levelComplete();
    }

    public void levelComplete()
    {
        LevelCompleteScreen.SetActive(true);
        EndBtn.SetActive(true);
        Time.timeScale = 0f;
    }
}