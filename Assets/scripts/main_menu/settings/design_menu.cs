using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class design_menu : MonoBehaviour
{
    public GameObject designText;
    public static int id;
    public GameObject[] backgrounds;
    static public GameObject[] backGrounds;
    public static bool reseting = false;

    public static string[] stylesEngName = new string[6]
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

    Color[] colors = new Color[6];
    


    public void Left()
    {
        id--;
        if (id < 0)
            id = 5;
        designText.GetComponent<Text>().text = "Цвет оформления: " + stylesRusName[id];
        settings.design = stylesEngName[id];
        settings.Save();        
        ReloadAssets();
    }

    public void Right()
    {
        id++;
        if (id > 5)
            id = 0;
        designText.GetComponent<Text>().text = "Цвет оформления: " + stylesRusName[id];
        settings.design = stylesEngName[id];
        settings.Save();
        ReloadAssets();
    }

    void Start()
    {
        designText = GameObject.Find("designText");       
        backGrounds = backgrounds;
        id = getStyleID();
        colorsInit();
        designText.GetComponent<Text>().text = "Цвет оформления: " + stylesRusName[id];
        
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
        reseting = true;

        string path = "design/GUI/" + stylesEngName[id] + "/Normal/";
        //иконки
        Invoke("stopReseting", 0.1f);
        //задний фон
        Sprite style_background =  (Sprite)(Resources.Load<Sprite>(path + "background_" + stylesEngName[id]) as Sprite);
        reloadBackGround(backGrounds[0], style_background);
        reloadBackGround(backGrounds[1], style_background);
        reloadBackGround(backGrounds[2], style_background);
        reloadBackGround(backGrounds[3], style_background);

        //цвет камеры
        GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = colors[id];
    }

    void reloadBackGround(GameObject back, Sprite style_background)
    {
        back.GetComponent<SpriteRenderer>().sprite = style_background;
        back.GetComponent<SpriteRenderer>().sortingOrder = -3;
    }

    void colorsInit()
    {
        colors[0].a = 1f;
        colors[0].b = 1f;
        colors[0].g = 0f;
        colors[0].r = 0f;

        colors[1].a = 1f;
        colors[1].b = 0f;
        colors[1].g = 1f;
        colors[1].r = 0f;
        
        colors[2].a = 1f;
        colors[2].b = 0.5f;
        colors[2].g = 0.5f;
        colors[2].r = 0.5f;

        colors[3].a = 1f;
        colors[3].b = 0f;
        colors[3].g = 0f;
        colors[3].r = 1f;

        colors[4].a = 1f;
        colors[4].b = 1f;
        colors[4].g = 1f;
        colors[4].r = 0f;

        colors[5].a = 1f;
        colors[5].b = 0f;
        colors[5].g = 1f;
        colors[5].r = 1f;
    }


    void stopReseting()
    {
        reseting = false;
    }
}
