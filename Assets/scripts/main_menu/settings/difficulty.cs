﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class difficulty : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool left = false;
    public bool right = false;
    public GameObject difficultyText;

    Vector3 normalScale;

    public float buttonTapDecreasePercent = 0.75f;

    void Start()
    {
        normalScale = transform.localScale;
        difficultyText = GameObject.Find("difficultyText");
        if (settings.difficulty == 0)
            difficultyText.GetComponent<Text>().text = "Сложность: Легко";
        else if (settings.difficulty == 1)
            difficultyText.GetComponent<Text>().text = "Сложность: Средне";
        else if (settings.difficulty == 2)
            difficultyText.GetComponent<Text>().text = "Сложность: Трудно";
        else
        {
            settings.difficulty = 1;
            difficultyText.GetComponent<Text>().text = "Сложность: Средне";
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        transform.localScale = normalScale;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (left)
        {

            if ( settings.difficulty == 0 )
            {
                settings.difficulty = 2;
                difficultyText.GetComponent<Text>().text = "Сложность: Трудно";
            }
            else if (settings.difficulty == 1)
            {
                settings.difficulty = 0;
                difficultyText.GetComponent<Text>().text = "Сложность: Легко";
            }
            else if (settings.difficulty == 2)
            {
                settings.difficulty = 1;
                difficultyText.GetComponent<Text>().text = "Сложность: Средне";
            }
            else
            {
                settings.difficulty = 1;
                difficultyText.GetComponent<Text>().text = "Сложность: Средне";
            }

        }
        else
        {
            if (settings.difficulty == 0)
            {
                settings.difficulty = 1;
                difficultyText.GetComponent<Text>().text = "Сложность: Средне";
            }
            else if (settings.difficulty == 1)
            {
                settings.difficulty = 2;
                difficultyText.GetComponent<Text>().text = "Сложность: Трудно";
            }
            else if (settings.difficulty == 2)
            {
                settings.difficulty = 0;
                difficultyText.GetComponent<Text>().text = "Сложность: Легко";
            }
            else
            {
                settings.difficulty = 1;
                difficultyText.GetComponent<Text>().text = "Сложность: Средне";
            }
        }

        settings.Save();

        transform.localScale = new Vector3(normalScale.x * buttonTapDecreasePercent, normalScale.y * buttonTapDecreasePercent, normalScale.z);
    }
}
