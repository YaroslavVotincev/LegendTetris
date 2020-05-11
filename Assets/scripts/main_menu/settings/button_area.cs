using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class button_area : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    Vector3 normalScale;
    public float buttonTapDecreasePercent = 0.75f;

    public void OnPointerDown(PointerEventData data)
    {
        transform.localScale = new Vector3(transform.localScale.x * buttonTapDecreasePercent, transform.localScale.y * buttonTapDecreasePercent);
    }

    public void OnPointerUp(PointerEventData data)
    {
        transform.localScale = normalScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        normalScale = transform.localScale;
    }
    
}
