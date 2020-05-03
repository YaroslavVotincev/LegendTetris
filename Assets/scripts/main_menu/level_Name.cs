using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class level_Name : MonoBehaviour, IPointerDownHandler
{
    public string lvlName;


    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerPrefs.SetString("chosen_lvl", lvlName);
        PlayerPrefs.Save();
    }

}
