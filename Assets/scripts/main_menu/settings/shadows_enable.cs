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

    // Start is called before the first frame update
    void Start()
    {
        //shadowText = GameObject.Find("shadowText");
        shadowsEnabled = settings.shadowsEnabled;
        updateText();
    }

    void updateText()
    {
        if (shadowsEnabled)
        {
            shadowText.GetComponent<Text>().text = "Тени фигур: включены";
        }
        else shadowText.GetComponent<Text>().text = "Тени фигур: отключены";
    }
}
