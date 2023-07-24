using UnityEngine;
using System.IO;

public class ConfigLoader : MonoBehaviour
{
    public static string GetConfigFilePath()
    {
        // Path to the config.json file relative to the Unity application data path
        return Path.Combine(Application.dataPath, "./config.json");
    }

    public static MySQLConfig LoadConfig()
    {
        string configPath = GetConfigFilePath();

        if (!File.Exists(configPath))
        {
            Debug.LogError("Config file not found! Make sure to create a config.json file.");
            return null;
        }

        string json = File.ReadAllText(configPath);
        return JsonUtility.FromJson<MySQLConfig>(json);
    }
}

// Define a custom class to hold the configuration data
[System.Serializable]
public class MySQLConfig
{
    public string Server;
    public string Database;
    public string Uid;
    public string Pwd;
}
