using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class settings : MonoBehaviour
{
    public static int shapes_upmoves = 1;

    public static float difficulty = 1;

    public static int manualNextShapeChanges = 2;

    public static bool shadowsEnabled = true;

    public static string design = "Yellow";
    
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
        //checkFactDir();
        //StartCoroutine(LoadFromServer(""));
    }

    void checkFactDir()
    {
        string path = "/data/data/com.ULG.LegendTetris/files/Facts";
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
            TextAsset[] themes = Resources.LoadAll<TextAsset>("facts") as TextAsset[];
            foreach(TextAsset subject in themes)
            {
                path = path + "/" + subject.name;
                print(subject.text);
                File.WriteAllText(path, subject.text );
            } 
        }
    }
    /*
    IEnumerator LoadFromServer(string url)
    {
        var request = new UnityWebRequest(url);
        request.SendWebRequest();
        while (request.isDone == false)
        {
            yield return new WaitForEndOfFrame();
        }
        if (!request.isHttpError && !request.isNetworkError)
        {
            Debug.Log(request.downloadHandler.text);
        }        
        request.Dispose();
    }*/
    /*
    IEnumerator LoadTextFromServer(string url, Action<string> response)
    {
        var request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (!request.isHttpError && !request.isNetworkError)
        {
            response(uwr.downloadHandler.text);
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);

            response(null);
        }

        request.Dispose();
    }*/


}
