using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presetStart : MonoBehaviour
{

    public GameObject testCube;

    public GameObject constantShape;

    public GameObject firstShape;

    public static int firstShapeid = -1;

    public static int constantShapeid = -1;

    public GameObject[] allshapes;

    public static bool isEnabled = true;

    public static int[,] presetPole =
    {
        /*
        { 1 , 1 },
        { 1 , 2 },
        { 2 , 1 },
        { 3 , 1 },
        { 4 , 1 },
        { 5 , 1 },
        { 6 , 1 },
        { 7 , 1 },
        { 8 , 1 },
        { 9 , 1 },
        { 10 , 1 },
        */
    };

    settingsData Settings;

    public static levelSaveData level = new levelSaveData();

    public static string lvlName;

    public static bool begin = false;
    //public static float difficulty = 1;

    

    void Load ()
    {
        string value;

        value = PlayerPrefs.GetString("settings");

        Settings = JsonUtility.FromJson<settingsData>(value);
        string val1 = PlayerPrefs.GetString("chosen_lvl");

        if (PlayerPrefs.HasKey(val1))
        {
            value = PlayerPrefs.GetString(PlayerPrefs.GetString("chosen_lvl"));
            level = JsonUtility.FromJson<levelSaveData>(value);
            lvlName = level.lvlName;
        }
        else
        {
            level = new levelSaveData();
            lvlName = PlayerPrefs.GetString("chosen_lvl");
            //print(lvlName);
        }
        level.targetScore = PlayerPrefs.GetInt("chosen_lvl_target_score");
        //print(lvlName);
    }
    
    void Awake()
    {
        print("awake");
        Load();

        shapes.shadowsEnabled = Settings.shadowsEnabled;
        shapes.upmoves = Settings.shapes_upmoves;
        game.difficulty = Settings.difficulty;
        nextShape.manualNextShapeChanges = Settings.manualNextShapeChanges;

        if (isEnabled)
        {
            allshapes = this.GetComponent<shapesList>().shp;
            shapesInGame();
            presetPoleFill(); 
        }
    }

    void presetPoleFill()
    {
        for (int i = 0; i < presetPole.GetUpperBound(0) + 1; i++)
        {
            game.pole[presetPole[i, 1], presetPole[i, 0]] = 1;
            game.pole2[presetPole[i, 1], presetPole[i, 0]] = Instantiate(testCube, new Vector3(presetPole[i, 0], presetPole[i, 1]), Quaternion.identity);
        }
    }

    void shapesInGame()
    {
        for (int i = 0; i < 7; i++)
        {
            if (allshapes[i] == firstShape)
            {
                firstShapeid = i;
            }
            if (allshapes[i] == constantShape)
            {
                constantShapeid = i;
            }
        }
        if (firstShapeid == -1)
        {
            firstShapeid = constantShapeid;
        }
    }

}
