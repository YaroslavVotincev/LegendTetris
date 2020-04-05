using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextShape : MonoBehaviour
{

    public static int id;

    public static bool needToChange = false;

    public GameObject[] allshapes;

    public GameObject next;





    // Start is called before the first frame update
    void Start()
    {

       // id = Random.Range(0, 7);
        
    }



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

            next.transform.Rotate(new Vector3(0, 0, 90));

            next.transform.position = new Vector3(16 + isLine , 20, 0);

            next.transform.localScale = new Vector3(0.7f, 0.7f, 0f);

            next.GetComponent<shapes>().enabled=false;

        }

    }


}
