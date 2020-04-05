using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class controlButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public static bool left = false, right = false, up = false, down = false;

    bool pressed = false;

    float t1,t2;

    public Vector3 normalScale;

    public float buttonTapDecreasePercent = 0.75f;




    public void OnPointerDown(PointerEventData eventData)
    {

        pressed = true;

        t1 = Time.time;

        if (transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            right = true;
        }

        else if (transform.rotation == Quaternion.Euler(0, 0, 90))
        {
            up = true;
        }

        else if (transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            left = true;
        }

        else down = true;

        transform.localScale = new Vector3( normalScale.x * buttonTapDecreasePercent  , normalScale.y * buttonTapDecreasePercent);

    }





    public void OnPointerUp(PointerEventData eventData)
    {

        pressed = false;

        transform.localScale = normalScale;

    }





    void Start()
    {

        normalScale = transform.localScale;

    }





    void Update()
    {

        t2 = Time.time;

        if (t2-t1>0.3f)
             if (pressed)
             {
                if (transform.rotation == Quaternion.Euler(0, 0, 0))
                {
                    right = true;
                }

                else if (transform.rotation == Quaternion.Euler(0, 0, 90))
                {
                    up = true;
                }

                else if (transform.rotation == Quaternion.Euler(0, 0, 180))
                {
                    left = true;
                }

                else down = true;

             }

    }

 

}
