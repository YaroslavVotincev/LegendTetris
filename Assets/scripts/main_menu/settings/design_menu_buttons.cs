using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class design_menu_buttons : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public bool left = false;
    public bool right = false;
    Vector3 normalScale;
    public float buttonTapDecreasePercent = 0.75f;
    GameObject main;

    public void OnPointerUp(PointerEventData data)
    {
        transform.localScale = normalScale;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (left)
        {
            main.GetComponent<design_menu>().Left();
        }
        else if (right)
        {
            main.GetComponent<design_menu>().Right();
        }
        transform.localScale = new Vector3(transform.localScale.x * buttonTapDecreasePercent, transform.localScale.y * buttonTapDecreasePercent);
    }


    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("design");
        normalScale = transform.localScale;
    }

}
