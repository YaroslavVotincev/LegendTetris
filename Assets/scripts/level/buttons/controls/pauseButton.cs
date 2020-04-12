using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pauseButton : MonoBehaviour, IPointerDownHandler
{

    public GameObject play_button, pause_button;

    private GameObject currentButton;

    public void OnPointerDown(PointerEventData eventData)
    {

        if (game.currentShape.GetComponent<shapes>().enabled == true)
        {

            game.currentShape.GetComponent<shapes>().enabled = false;

            Destroy(currentButton);

            currentButton = Instantiate(play_button, transform.position, Quaternion.identity);

        }

        else
        {

            game.currentShape.GetComponent<shapes>().enabled = true;

            Destroy(currentButton);

            currentButton = Instantiate(pause_button, transform.position, Quaternion.identity);

        }
       
    }


    void Start()
    {
        currentButton = Instantiate(pause_button, transform.position, Quaternion.identity);
    }
}
