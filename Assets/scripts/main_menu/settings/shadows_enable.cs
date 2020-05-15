using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class shadows_enable : MonoBehaviour, IPointerDownHandler
{
    bool shadowsEnabled;
    public GameObject shadowText;

    public void OnPointerDown(PointerEventData data)
    {
        shadowsEnabled = !shadowsEnabled;
        settings.shadowsEnabled = shadowsEnabled;
        settings.Save();
        updateText();
    }

    void Start()
    {
        //shadowText = GameObject.Find("shadowtxt");
        shadowsEnabled = settings.shadowsEnabled;
        updateText();
    }

    public void updateText()
    {
        /*if (shadowText == null)
            Application.Quit();*/

        if (shadowsEnabled)
        {
            shadowText.GetComponent<Text>().text = "Тени фигур: включены";
        }
        else shadowText.GetComponent<Text>().text = "Тени фигур: отключены";
    }
}
