using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public List<TextMeshProUGUI> timeTexts; // list of textMeshPro to display the times

    private List<float> bestTimes; // List of the user's 5 best times

    private string filePath; // file path 

    public GameObject leaderboardScreen; // leaderboard gameobject

    public bool leaderboard = false; // checker for whether leaderboard is visible or not

    private void Start()
    {
        filePath = Application.dataPath + "/SaveDataFile.json"; // decalre file path

        LoadTimes(); // load times from saved file
        DisplayTimes(); // display times on the leaderboard
    }

    private void LoadTimes()
    {
        if (File.Exists(filePath)) // if file exists load times
        {
            string json = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestTimes = saveData.bestTimes;
        }
    }

    private void DisplayTimes()
    { 
        bestTimes.Sort(); // sort times in ascending order

        // display times on textMeshPros
        if (bestTimes.Count == 0)
        {
            timeTexts[0].text = "No Attempts Yet!"; // if no saved times
            for (int i = 1; i < timeTexts.Count; i++)
            {
                timeTexts[i].text = ""; // set remaining tmp as blank
            }
        }
        else
        {
            for (int i = 0; i < timeTexts.Count; i++)
            {
                if (i < bestTimes.Count)
                {
                    int mins = Mathf.FloorToInt(bestTimes[i] / 60f); // calculate minutes
                    int secs = Mathf.FloorToInt(bestTimes[i] % 60f); // calculate seconds
                    timeTexts[i].text = string.Format("{0:00}:{1:00}", mins, secs); // format time
                }
                else
                {
                    timeTexts[i].text = "N/A"; // display N/A if less than 5 saved times
                }
            }
        }
    }

    public void ToggleLeaderboard()
    {
        LoadTimes();
        DisplayTimes();
        leaderboard = !leaderboard; // set whether leaderboard visible or not

        leaderboardScreen.SetActive(leaderboard);

        if (leaderboard)
        {
            Time.timeScale = 0f; // pause game
        }
        else
        {
            Time.timeScale = 1f; // resume game
        }
    }
}