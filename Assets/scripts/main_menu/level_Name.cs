using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class level_Name : MonoBehaviour, IPointerDownHandler
{
    public string lvlName;
    public int targetScore;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerPrefs.SetString("chosen_lvl", lvlName);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("chosen_lvl_target_score", targetScore);
        PlayerPrefs.Save();
        //print(lvlName);
        //print(PlayerPrefs.GetString("chosen_lvl"));
    }

}
