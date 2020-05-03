using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class nextShape : MonoBehaviour, IPointerDownHandler
{
    public GameObject nextshape_frame;

    public static int id;

    public static bool needToChange = false;

    public GameObject[] allshapes;

    public GameObject next;

    public GameObject textChanges;

    public static int manualNextShapeChanges, manualChangeCounter;

    public static bool isManualChange;

    public static Vector3 nextShapePos = new Vector3(15f, 19, 0); 

    // Update is called once per frame
    void Update()
    {

        if (needToChange)
        {
            int isLine = 0;

            Destroy(next);

            if (presetStart.isEnabled && presetStart.constantShapeid >= 0)
            {
                id = presetStart.constantShapeid;
            }
            else id = Random.Range(0, 7);

            if (id==2)
                isLine = 1;

            needToChange = false;

            next = Instantiate(allshapes[id]) as GameObject;

            next.transform.position = nextShapePos;

            next.transform.position += new Vector3(0, -isLine);

            next.transform.localScale = new Vector3(0.7f, 0.7f, 0f);

            next.GetComponent<shapes>().enabled=false;

            next.transform.SetParent(nextshape_frame.transform);

            manualChangeCounter = manualNextShapeChanges;

            textChanges.GetComponent<Text>().text = System.Convert.ToString(manualChangeCounter);
        }

    }

    private void Start()
    {
        int isLine = 0;


        if (presetStart.isEnabled && presetStart.constantShapeid >= 0)
        {
            id = presetStart.constantShapeid;
        }
        else id = Random.Range(0, 7);

        if (id == 2)
            isLine = 1;

        needToChange = false;

        next = Instantiate(allshapes[id]) as GameObject;

        next.transform.position = nextShapePos;

        next.transform.position += new Vector3(0, -isLine);

        next.transform.localScale = new Vector3(0.7f, 0.7f, 0f);

        next.GetComponent<shapes>().enabled = false;

        next.transform.SetParent(nextshape_frame.transform);

        manualChangeCounter = manualNextShapeChanges;

        textChanges.GetComponent<Text>().text = System.Convert.ToString(manualChangeCounter);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (manualChangeCounter > 0)
        {
            int isLine = 0;

            Destroy(next);

            if (presetStart.isEnabled && presetStart.constantShapeid >= 0)
            {
                id = presetStart.constantShapeid;
            }
            else id = Random.Range(0, 7);

            if (id == 2)
                isLine = 1;

            needToChange = false;

            next = Instantiate(allshapes[id]) as GameObject;

            next.transform.position = nextShapePos;

            next.transform.position += new Vector3(0, -isLine);

            next.transform.localScale = new Vector3(0.7f, 0.7f, 0f);

            next.GetComponent<shapes>().enabled = false;

            next.transform.SetParent(nextshape_frame.transform);

            manualChangeCounter--;

            textChanges.GetComponent<Text>().text = System.Convert.ToString(manualChangeCounter);
        }

    }


}
