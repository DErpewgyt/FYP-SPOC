using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveNLoad : MonoBehaviour
{
    private int current_scene;
    public void Save()
    {
        SaveData data = new SaveData();
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.buildIndex);
        data.scene = currentScene.buildIndex;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
    }

    public void Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveDataFile.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        current_scene = data.scene;

        SceneManager.LoadScene(current_scene);
    }
}
