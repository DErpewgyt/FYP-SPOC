// Jayden Lim 2123066
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI timeText; // text where time will be displayed

    private float time; // variable to store the time
    private List<float> bestTimes = new List<float>(); // List of the user's 5 best times

    public bool timerRunning; // checker if time is running
    public bool conditionsCompleted = false; // checker if conditions are completed or not
    private bool timeSaved = false; // checker if time has been saved or not

    public GameObject LevelCompleteScreen; // screen that pops up when level completes
    public GameObject EndBtn; // the retry and main menu btns
    public GameObject ResetBtn; // reset btn
    public GameObject BestTimesBtn; // best time btn
    public GameObject BestTimeScreen; // best time screen
    public GameObject SubmitBtn; // submit btn

    private string filePath; // directory of save file

    private void Start()
    {
        bestTimes = new List<float>();
        time = 0f;
        timerRunning = false;
        timeSaved = false;
        filePath = Application.dataPath + "/SaveDataFile.json"; // declare file path

        if (File.Exists(filePath)) // check if any existing saved times
        {
            string json = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestTimes = saveData.bestTimes; // load best times
        }
    }

    private void Update()
    {
        if (timerRunning) // timer
        {
            time += Time.deltaTime; // run timer
            int mins = Mathf.FloorToInt(time / 60f); // calculate minutes
            int secs = Mathf.FloorToInt(time % 60f); // calculate seconds
            timeText.text = string.Format("{0:00}:{1:00}", mins, secs); // format time
            if (conditionsCompleted && timeSaved == false) // check if conditions completed
            {
                Checker.saved = true;
                AddTime(); // add time
                timeSaved = true;
                levelComplete(); // activate level complete screen
            }
        }
    }

    public void CompleteConditions() // set conditionsCompleted
    {
        Debug.Log("Best time byutr");
        conditionsCompleted = true; 
        print("conditions completed:" + conditionsCompleted);
    }

    private void SaveBestTimes() // save times to file
    {
        SaveData data = new SaveData();
        data.bestTimes = bestTimes;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json); // save times to json
        print("saved the time");
    }

    private void AddTime() // add to list 
    {
        bestTimes.Sort(); // sort times in ascending order
        if (bestTimes.Count < 5)
        {
            bestTimes.Add(time); // If there are less than 5 best times just add the time to lists
        }
        else
        {
            float slowestTime = bestTimes[bestTimes.Count - 1]; // slowest time from current list
            if (time < slowestTime)
            {
                bestTimes[bestTimes.Count - 1] = time; // if new time faster, remove current slowest time
            }
            else
            {
                conditionsCompleted = false; // reset checker
                return; // if time taken slower dont save
            }
        }
        SaveBestTimes(); // save the time to JSON
        conditionsCompleted = false; // reset checker
    }

    public void levelComplete() // activate level complete screen
    {
        ResetBtn.SetActive(false);
        BestTimesBtn.SetActive(false);
        BestTimeScreen.SetActive(false);
        LevelCompleteScreen.SetActive(true);
        EndBtn.SetActive(true);
        SubmitBtn.SetActive(false);
        Time.timeScale = 0f;
    }
}