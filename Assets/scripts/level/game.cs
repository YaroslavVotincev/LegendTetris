using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class game : MonoBehaviour
{
    public static string lvlName;

    public static GameObject[] allshapes;

    public GameObject fill, gameOverCube;

    public static GameObject currentShape;

    public static int currentShapeID;

    public static int score = 0;

    public static int targetScore;

    float ptrTime=0;

    int ai = 1, aj = 1;
        
    int completedLines=0;

    public static float difficulty;

    public GameObject textScore, textDiffScore, textFact;

    public GameObject empty,field;

    public static bool gameOver = false, poleGameOverCleared = false;

    public static bool activePhase = true, victory = false;

    public static bool exit = false;

    public static GameObject[,] pole2 = new GameObject[27, 12];

    public static byte[,] pole = new byte[27, 12]
    {

         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2}

    };


   


    void Start()
    {
        allshapes = shapesList.allshapes;

        if (presetStart.isEnabled && presetStart.firstShapeid >= 0)
        {
            nextShape.id = presetStart.firstShapeid;
        }
        else nextShape.id = Random.Range(0, 7);

        //currentShapeID = presetStart.level.currentShapeID;

        if (presetStart.level.wasStarted == true )              
        {
            currentShape = Instantiate(allshapes[presetStart.level.currentShapeID], new Vector3Int(presetStart.level.currentShape_x, presetStart.level.currentShape_y, 0), Quaternion.Euler(0,0,presetStart.level.currentShape_rotation));
            currentShapeID = presetStart.level.currentShapeID;
        }
        else
            NextShape();

        pole = presetStart.level.fromPoleStr_ToPole();
        poleFillingCubes();
        score = presetStart.level.score;
        targetScore = presetStart.level.targetScore;
        lvlName = PlayerPrefs.GetString("chosen_lvl");
        print(lvlName);
        textScore.GetComponent<Text>().text = ("Счёт: " + System.Convert.ToString(score));


        textDiffScore.GetComponent<Text>().text = ("До цели: " + System.Convert.ToString(targetScore - score));
        pole2FillingEmpty();
        Debug.Log("level loaded");
    }

    
    void Update()
    {

        if (activePhase)
        {
            if (shapes.isStopped == true)
            {
                shapeStoppedHandler();
            }    
        }

        else if (poleGameOverCleared == false && gameOver == true)
        {
            if (Time.time - ptrTime > 0.01f)
            {
                ptrTime = Time.time;

                if (poleFillGameOverCubes() == false)
                {
                    poleGameOverCleared = true;
                    this.GetComponent<cameraControl>().moveToGameOver();
                }
            }
        }
        
        if (exit)
        {
            Save();
            exit = false;
            poleRetryClear();
            Resources.UnloadUnusedAssets();
            SceneManager.LoadScene(0);
            Resources.UnloadUnusedAssets();
        }                   

    }
    

    private void OnApplicationQuit()
    {
        if (victory == false)
        {
            print("quit");
            Save();
        }
        
    }

    void shapeStoppedHandler()
    {
        if (gameOver == false && currentShape != null)
            transformToFilling();

        if (gameOver == false)
        {
            shapes.isStopped = false;

            completedLines = 0;

            poleGameOverCleared = false;

            if (checkForLines() == false)
            {
                NextShape();
            }
            else
            {
                Invoke("checkForLines", 0.3f);

                Invoke("checkForLines", 0.6f);

                Invoke("checkForLines", 0.9f);

                Invoke("checkScore", 0.9f);
            }
        }

        else
        {
            poleGameOverCleared = false;
            activePhase = false;
        }

    }

    void NextShape()
    {

        currentShapeID = nextShape.id;

        currentShape = Instantiate(allshapes[currentShapeID]) as GameObject;

        currentShape.transform.position = new Vector3(5, 23, 0);

        nextShape.needToChange = true;

    }

    void poleFillingCubes()
    {

        for (int i = 0; i < 27; i++)
        {

            for (int j = 0; j < 12; j++)
            {

                if (pole[i, j] == 1)
                {
                    pole2[i, j] = Instantiate(gameOverCube, new Vector3(j, i, 0), Quaternion.identity) as GameObject;
                    pole2[i, j].transform.SetParent(field.transform);
                }

            }

        }

    }

    void pole2FillingEmpty()
    {

        for (int i = 0; i < 27; i++)
        {

            for (int j = 0; j < 12; j++)
            {

                if (pole2[i, j] == null || pole2[i, j] == gameOverCube)
                {
                    pole2[i, j] = Instantiate(empty, new Vector3(j, i, 0), Quaternion.identity) as GameObject;
                    pole2[i, j].transform.SetParent(field.transform);
                }

            }

        }

    }

    public void poleRetryClear()
    {

        for (int i = 1; i < 25; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                if (pole[i, j] == 1 )
                {
                    pole[i, j] = 0;
                }
                Destroy(pole2[i, j]);
            }
        }
        pole2FillingEmpty();
    }

    bool poleFillGameOverCubes()
    {
        if (ai<25)
        {
            Destroy (pole2[ai, aj%12]) ;
            pole2[ai, aj%12] = Instantiate(gameOverCube, new Vector3(aj%12, ai, 0), Quaternion.identity) as GameObject;
            pole2[ai, aj % 12].transform.SetParent(field.transform);
            if (aj % 12 == 0) ai++;
            aj++;
            return true;
        }
        return false;
    }

    void transformToFilling()
    {

        foreach (Transform cube in currentShape.transform)
        {

            int x = Mathf.RoundToInt(cube.transform.position.x);

            int y = Mathf.RoundToInt(cube.transform.position.y);

           // Destroy( pole2[y, x] );

            pole2[y,x] = Instantiate(fill, new Vector3(x, y, 0), Quaternion.identity) as GameObject;

            pole2[y, x].GetComponent<SpriteRenderer>().color = cube.GetComponent<SpriteRenderer>().color;

            pole2[y, x].transform.SetParent(field.transform);

            pole[y,x] = 1;

            if (y >= 21)
                gameOver = true;

        }

        Destroy(currentShape);
        pole2FillingEmpty();

    }

    void checkScore()
    {
        if (score >= targetScore)
        {
            poleGameOverCleared = true;
            gameOver = true;
            activePhase = false;
            showFact();
            giveGravityToCubes();
            victorySave();
            Invoke("moveCameraToVictory", 2f);
        }
        else
            NextShape();
    }

    void moveCameraToVictory()
    {
        this.GetComponent<cameraControl>().moveToVictory();
    }

    bool checkForLines()
    {
        int a, i, j;
        for (i = 0; i < 22; i++)
        {
            a = 0;
            for (j = 1; j < 11; j++)
            {
                if (pole[i, j] == 1)
                    a++;
            }
            if (a == 10)
            {
                for (int k = 1; k < 11; k++)
                {
                    Destroy(pole2[i, k]);
                }
                for (int g = i; g < 20; g++)
                {
                    for (int k = 1; k < 11; k++)
                    {
                        pole[g, k] = pole[g + 1, k];
                        pole2[g, k] = pole2[g + 1, k];
                        pole2[g, k].transform.position += new Vector3(0, -1, 0);                       
                    }
                }
                completedLines++;
                score += 10 * completedLines;
                textScore.GetComponent<Text>().text = ("Счёт: " + System.Convert.ToString(score));
                
                textDiffScore.GetComponent<Text>().text = ("До цели: " + System.Convert.ToString( (targetScore - score)* System.Convert.ToInt32((targetScore - score)>0) ));
                pole2FillingEmpty();
                return true;
            }
        }
        return false;
    }

    public static void Save()
    {
        levelSaveData data = new levelSaveData();

        data.poleStr = data.fromPole_ToPoleStr(pole);
        data.score = score;
        data.targetScore = targetScore;
        data.currentShapeID = currentShapeID;
        data.currentShape_x = Mathf.RoundToInt(currentShape.transform.position.x);
        data.currentShape_y = Mathf.RoundToInt(currentShape.transform.position.y);
        data.currentShape_rotation = currentShape.transform.rotation.eulerAngles.z;
        data.lvlName = lvlName;
        data.wasStarted = true;

        string value = JsonUtility.ToJson(data);
        print(lvlName);
        print("level saved");
        PlayerPrefs.SetString(lvlName, value);

        PlayerPrefs.Save();

        //File.AppendAllText("Assets/Resources/12.txt", value);
        //File.AppendAllText("Assets/Resources/1.txt", PlayerPrefs.GetString(lvlName));
    }

    public void victorySave()
    {
        levelSaveData data = new levelSaveData();
        data.lvlName = lvlName;
        data.wasStarted = false;
        data.attempt = presetStart.level.attempt + 1;
        string value = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(lvlName, value);
        PlayerPrefs.Save();
    }

    public void RepeatStart()
    {
        Debug.Log("level loaded");

        allshapes = shapesList.allshapes;

        if (presetStart.isEnabled && presetStart.firstShapeid >= 0)
        {
            nextShape.id = presetStart.firstShapeid;
        }
        else nextShape.id = Random.Range(0, 7);

        if (presetStart.level.wasStarted == true)              // не забыть изменять repeat
        {
            currentShape = Instantiate(allshapes[presetStart.level.currentShapeID], new Vector3Int(presetStart.level.currentShape_x, presetStart.level.currentShape_y, 0), Quaternion.Euler(0, 0, presetStart.level.currentShape_rotation));
        }
        else
            NextShape();

        pole = presetStart.level.fromPoleStr_ToPole();
        poleFillingCubes();
        score = presetStart.level.score;
        targetScore = presetStart.level.targetScore;
        lvlName = presetStart.level.lvlName;
        pole2FillingEmpty();

        print("repeated");
    }

    void giveGravityToCubes()
    {
        foreach(GameObject cube in pole2)
        {
            if (cube!=empty)
            {
                cube.AddComponent<Rigidbody2D>();
                cube.AddComponent<BoxCollider2D>();
            }
        }
    }
    
    void showFact()
    {
        StreamReader fileStorage;
        string str;
        string path = "/data/data/com.ULG.LegendTetris/files/Facts";
        if (Directory.Exists(path) == true)
        {
            path = path + "/" + lvlName;
            if (File.Exists(path))
            {
                int lines = 0;
                fileStorage = new StreamReader(path);

                while((str = fileStorage.ReadLine()) != null) 
                    lines++;

                int rnd = Random.Range(0, lines);
                fileStorage = new StreamReader(path);

                for (int i = 0; i<lines; i++)
                {
                    str = fileStorage.ReadLine();
                    if (i == rnd)
                        break;
                }  
            }
            else
                str = "Файл с фактами отсутствует";
        }
        else
            str = "Папка с фактами отсутствует";

        textFact.GetComponent<Text>().text = str;
    }

}
