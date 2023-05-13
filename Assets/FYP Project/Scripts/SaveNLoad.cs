/*using System.IO;
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
        //Debug.Log(black_circle.transform.position.z);

        data.scene = currentScene.buildIndex;
        GameObject blackCircle = GameObject.FindWithTag("BlackCircle");
        if (blackCircle != null)
        {
            Vector3 position = blackCircle.transform.position;
            data.black_circle_z = position.z;
            Debug.Log(position.z);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
    }

    public void Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveDataFile.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        current_scene = data.scene;
        *//*SceneManager.LoadScene(current_scene, LoadSceneMode.Single);*//*

        GameObject blackCircle = GameObject.FindWithTag("BlackCircle");
        if (blackCircle != null)
        {
            Vector3 position = blackCircle.transform.position;
            position.z = data.black_circle_z;
            blackCircle.transform.position = position;
        }
    }
}*/