using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class deleteAllKeys : MonoBehaviour
{
    private void OnMouseDown()
    {
        print(PlayerPrefs.HasKey("test"));
        File.AppendAllText("Assets/Resources/123.txt", PlayerPrefs.GetString("test"));


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
