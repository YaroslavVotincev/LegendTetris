using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class design_spritesReload_level : MonoBehaviour
{
    public string path;
    public static string design;
    void Start()
    {
        path = "design/GUI/" + design + "/Normal/";

        if (this.GetComponent<SpriteRenderer>() != null)      
        {
            this.GetComponent<SpriteRenderer>().sprite = (Sprite)(Resources.Load<Sprite>(path + this.GetComponent<SpriteRenderer>().sprite.name) as Sprite); 
        }
        else
        {
            this.GetComponent<Image>().sprite = (Sprite)(Resources.Load<Sprite>(path + this.GetComponent<Image>().sprite.name) as Sprite);
        }
    }

}
