using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class camera_MoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool needToMove = false;

    public GameObject cam;

    public float cameraSpeedMovement = 100f;

    public float movementLenght = 80;

    Vector3 firstPos, normalScale;

    float buttonTapDecreasePercent = 0.75f;

    void Start()
    {
        cam = GameObject.Find("Main Camera");

        normalScale = transform.localScale;
    }

    public void OnPointerUp(PointerEventData data)
    {
        transform.localScale = normalScale;
    }

    public void OnPointerDown(PointerEventData data)
    {
        needToMove = true;
        firstPos = cam.transform.position;
        transform.localScale = new Vector3(transform.localScale.x * buttonTapDecreasePercent, transform.localScale.y * buttonTapDecreasePercent);
    }

    void moveLeft()
    {
        if (cam.transform.position.x > -movementLenght + firstPos.x)
        {
            cam.transform.position -= new Vector3(cameraSpeedMovement * Time.deltaTime, 0);
        }
        else
        {
            cam.transform.position = new Vector3(-movementLenght + firstPos.x, firstPos.y, firstPos.z);
            needToMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (needToMove)
        {
            moveLeft();
        }
    }

}
