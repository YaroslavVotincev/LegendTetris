using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class design_menu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool left = false;
    public bool right = false;
    Vector3 normalScale;
    public float buttonTapDecreasePercent = 0.75f;
    public GameObject designText;
    static int id;
    public GameObject[] backgrounds;
    static public GameObject[] backGrounds;

    string[] stylesEngName = new string[6]
    {
        "Blue",
        "Green",
        "Grey",
        "Red",
        "Teal",
        "Yellow"
    };

    string[] stylesRusName = new string[6]
    {
        "Синий",
        "Зеленый",
        "Серый",
        "Красный",
        "Голубой",
        "Желтый"
    };

    public void OnPointerUp(PointerEventData data)
    {
        transform.localScale = normalScale;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (left)
        {
            id--;
            if (id < 0)
                id = 5;
            designText.GetComponent<Text>().text = "Цвета оформления: " + stylesRusName[id];
            settings.design = stylesEngName[id];
            settings.Save();
            transform.localScale = new Vector3(transform.localScale.x * buttonTapDecreasePercent, transform.localScale.y * buttonTapDecreasePercent);
            ReloadAssets();
        }
        else if (right)
        {
            id++;
            if (id > 5)
                id = 0;
            designText.GetComponent<Text>().text = "Цвета оформления: " + stylesRusName[id];
            settings.design = stylesEngName[id];
            settings.Save();
            transform.localScale = new Vector3(transform.localScale.x * buttonTapDecreasePercent, transform.localScale.y * buttonTapDecreasePercent);
            ReloadAssets();
        }
    }



    void Start()
    {
        designText = GameObject.Find("designText");
        //if(left == false && right == false)
        normalScale = transform.localScale;
        backGrounds = backgrounds;
        id = getStyleID();
        designText.GetComponent<Text>().text = "Цвета оформления: " + stylesRusName[id];
        if(left == false)    
        ReloadAssets();


       
    }

    int getStyleID()
    {
        for (int i = 0; i < 6; i++)
        {
            if (settings.design == stylesEngName[i])
                return i;
        }
        print("design id error");
        return 0;
    }

    
    void ReloadAssets()
    {
        string path = "design/GUI/" + stylesEngName[id] + "/";
        //иконки

        //задний фон
        print(path + "background_" + stylesEngName[id]);
        GameObject style_background = Resources.Load<GameObject>(path + "background_" + stylesEngName[id]) as GameObject;
        reloadBackGround(backGrounds[0], style_background, 0);
        reloadBackGround(backGrounds[1], style_background, 1);
        reloadBackGround(backGrounds[2], style_background, 2);
        reloadBackGround(backGrounds[3], style_background, 3);
        GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor;
        //кнопки

        //стрелки
    }

    void reloadBackGround(GameObject back, GameObject style_background, int i)
    {
        Vector3 position = back.transform.position;
        Quaternion rotation = back.transform.transform.rotation;
        Vector3 scale = back.transform.localScale;
        Destroy(back);
        back = Instantiate(style_background) as GameObject;
        back.transform.position = position;
        back.transform.rotation = rotation;
        back.transform.localScale = scale;
        back.GetComponent<SpriteRenderer>().sortingOrder = -3;
        backGrounds[i] = back;
    }

}
