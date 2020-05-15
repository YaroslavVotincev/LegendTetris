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

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerPrefs.SetString("chosen_lvl", lvlName);        
        PlayerPrefs.SetInt("chosen_lvl_target_score", targetScore);
        PlayerPrefs.SetString("chosen_lvl_rusName", lvlNameText.GetComponent<Text>().text);
        PlayerPrefs.Save();
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
        targetScore = 500 * (System.Convert.ToInt32(settings.difficulty) + 1) + Random.Range(-200, 100) / 10 * 10 + attempt*100;
        updateText();
    }


    void updateText()
    {
        //lvlNameText.GetComponent<Text>().text = lvlName;
        targetScoreText.GetComponent<Text>().text = "Цель: " +targetScore+ " очков";
    }


    void Start()
    {
        if (PlayerPrefs.HasKey(lvlName))
        {
            levelSaveData data = JsonUtility.FromJson<levelSaveData>(PlayerPrefs.GetString(lvlName));
            if (data.wasStarted)
                targetScoreText.GetComponent<Text>().text = "ПРОДОЛЖИТЬ...";
            else if (targetScore ==0) 
                setTargetScore();
        }
        else if(targetScore == 0)
        {
            setTargetScore();
        }
    }




}
