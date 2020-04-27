using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public static int shapes_upmoves = 1;

    public static float difficulty = 1;

    public static int manualNextShapeChanges = 2;

    public static bool shadowsEnabled = true;

    public static int design = 0;

    void Load()
    {
        string key = "settings";
        if (PlayerPrefs.HasKey(key))
        {
            string value = PlayerPrefs.GetString(key);

            settingsData data = JsonUtility.FromJson<settingsData>(value);

            shapes_upmoves = data.shapes_upmoves;
            difficulty = data.difficulty;
            manualNextShapeChanges = data.manualNextShapeChanges;
            shadowsEnabled = data.shadowsEnabled;
            design = data.design;
        }
        else
        {
            settingsData data = new settingsData();

            shapes_upmoves = data.shapes_upmoves;
            difficulty = data.difficulty;
            manualNextShapeChanges = data.manualNextShapeChanges;
            shadowsEnabled = data.shadowsEnabled;
            design = data.design;

            string value = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(key, value);

            PlayerPrefs.Save();
        }

    }
    public static void Save()
    {
        string key = "settings";

        settingsData data = new settingsData();

        data.shapes_upmoves = shapes_upmoves;
        data.difficulty = difficulty;
        data.manualNextShapeChanges = manualNextShapeChanges;
        data.shadowsEnabled = shadowsEnabled;
        data.design = design;        

        string value = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(key, value);

        PlayerPrefs.Save();

        //File.Create("Assets/Resources/12.txt");
        File.AppendAllText("Assets/Resources/12.txt", value);
        
    }
    
    void Awake()
    {
        Load();
    }

}
