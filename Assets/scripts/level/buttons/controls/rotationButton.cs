using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rotationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool doRotation = false;

    public Vector3 normalScale;

    public float buttonTapDecreasePercent = 0.75f;

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = normalScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        doRotation = true;
        transform.localScale = new Vector3(  normalScale.x * buttonTapDecreasePercent  , normalScale.y * buttonTapDecreasePercent  );
    }

     void Start()
     {
        normalScale = transform.localScale;
     }

}
