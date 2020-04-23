using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAllKeys : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.DeleteAll();
        print("All keys deleted");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
