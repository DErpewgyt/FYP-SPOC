using System.IO;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    private GameObject blackCircle;
    private GameObject allCircles;
    private float lastZPosition = float.PositiveInfinity;

    // Start is called before the first frame update
    private void Start()
    {
        blackCircle = GameObject.FindWithTag("BlackCircle");
        allCircles = GameObject.FindWithTag("allCircles");
    }

    // Update is called once per frame
    /*private void Update()
    {
        *//*GameObject blackCircle = GameObject.FindWithTag("BlackCircle");
        if (blackCircle != null)
        {
            Debug.Log(blackCircle.transform.position.z);
            *//*if (blackCircle.transform.position.z <= -6)
            {
                SaveData data = new SaveData();
                data.black_circle_z = blackCircle.transform.position.z;
                string json = JsonUtility.ToJson(data, true);
                File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
                Debug.Log("saved" + blackCircle.transform.position.z);
            }*//*
        }*//*
        Debug.Log("curr z pos" + blackCircle.transform.position.z);
    }*/

    /*    private void Update()
        {
            if (blackCircle != null)
            {
                float currentZPosition = blackCircle.transform.position.z;
                if (currentZPosition <= -6 && lastZPosition > -6)
                {
                    SaveData data = new SaveData();
                    data.black_circle_z = currentZPosition;
                    string json = JsonUtility.ToJson(data, true);
                    File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
                    Debug.Log("Saved: " + data.black_circle_z);
                }
                lastZPosition = currentZPosition;
            }
        }*/

    private void Update()
    {
        if (blackCircle != null)
        {
            float currentZPosition = blackCircle.transform.position.z;
            if (currentZPosition <= -6 && lastZPosition > -6)
            {
                SaveData data = new SaveData();
                data.black_circle_z = currentZPosition;
                string json = JsonUtility.ToJson(data, true);
                File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
                Debug.Log("Saved: " + blackCircle.name + " Z Position: " + data.black_circle_z);
            }
            lastZPosition = currentZPosition;
        }

        if (allCircles != null)
        {
            Vector3 currentPosition = allCircles.transform.position;
            Debug.Log("X: " + currentPosition.x + " Y: " + currentPosition.y);
            if (currentPosition.x >= 0.07 && currentPosition.x <= 0.013 && currentPosition.y >= 1.2 && currentPosition.y <= 6.5)
            {
                SaveData data = new SaveData();
                data.all_circles_position = currentPosition;
                string json = JsonUtility.ToJson(data, true);
                File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
                Debug.Log("Saved: " + allCircles.name + " Position: " + data.all_circles_position);
            }
        }
    }

    public void Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveDataFile.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        /*current_scene = data.scene;*/
        /*SceneManager.LoadScene(current_scene, LoadSceneMode.Single);*/

        /*GameObject blackCircle = GameObject.FindWithTag("BlackCircle");*/
        if (blackCircle != null)
        {
            Vector3 position = blackCircle.transform.position;
            position.z = data.black_circle_z;
            blackCircle.transform.position = position;
        }
    }

    public void ClearAllData()
    {
        // Delete the save file to clear all data
        /*File.Delete(Application.dataPath + "/SaveDataFile.json");*/
        SaveData data = new SaveData();
        data.black_circle_z = -5;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
    }
}