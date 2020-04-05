using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class retry : MonoBehaviour, IPointerDownHandler
{
    public GameObject cam;

    public void OnPointerDown (PointerEventData a)
    {

        game.gameOver = false;

        cam.GetComponent<cameraControl>().moveToGame();

        cam.GetComponent<game>().poleRetryClear();

        game.activePhase = true;
        game.gameOver = false;
        game.poleGameOverCleared = false;

    }




}
