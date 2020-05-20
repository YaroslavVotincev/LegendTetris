using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class level_Name : MonoBehaviour, IPointerDownHandler
{
    public string lvlName;
    public int targetScore;
    public GameObject targetScoreText;
    public GameObject lvlNameText;
    public Sprite levelPicture;

    public GameObject title;
    public GameObject startPicture;
    public GameObject startTargetScoreText;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerPrefs.SetString("chosen_lvl", lvlName);        
        PlayerPrefs.SetInt("chosen_lvl_target_score", targetScore);
        PlayerPrefs.SetString("chosen_lvl_rusName", lvlNameText.GetComponent<Text>().text);
        PlayerPrefs.Save();

        title.GetComponent<Text>().text = lvlNameText.GetComponent<Text>().text;
        startPicture.GetComponent<SpriteRenderer>().sprite = levelPicture;
        startTargetScoreText.GetComponent<Text>().text = targetScoreText.GetComponent<Text>().text;


        //print(lvlName);
        //print(PlayerPrefs.GetString("chosen_lvl"));
    }

    void setTargetScore()
    {
        int attempt = 0;
        if (PlayerPrefs.HasKey(lvlName))
        {
            levelSaveData data =  JsonUtility.FromJson<levelSaveData>(PlayerPrefs.GetString(lvlName));
            attempt = data.attempt;
        }
        targetScore = 150 + 150 * (System.Convert.ToInt32(settings.difficulty)) + Random.Range(-150, 100) / 10 * 10 + attempt*100;
        updateText();
    }


    void updateText()
    {
        //lvlNameText.GetComponent<Text>().text = lvlName;
        targetScoreText.GetComponent<Text>().text = "Цель: " +targetScore;
    }


    void Start()
    {
        if (PlayerPrefs.HasKey(lvlName))
        {
            levelSaveData data = JsonUtility.FromJson<levelSaveData>(PlayerPrefs.GetString(lvlName));
            if (data.wasStarted)
                targetScoreText.GetComponent<Text>().text = "Начато/До цели:" + (data.targetScore - data.score);
            else if (targetScore == 0) 
                setTargetScore();
        }
        else if(targetScore == 0)
        {
            setTargetScore();
        }
        else if (targetScore == -1)
        {
            targetScoreText.GetComponent<Text>().text = "Лучший счет:" + PlayerPrefs.GetInt("endless_bestScore");
        }
        //updateText();
        levelPicture = GameObject.Find(lvlName + "_pic").GetComponent<SpriteRenderer>().sprite;
        title = GameObject.Find("title");
        startPicture = GameObject.Find("startPicture");
        startTargetScoreText = GameObject.Find("startTargetScoreText");
    }




}
