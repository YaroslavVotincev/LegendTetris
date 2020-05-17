using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class design_spritesReload : MonoBehaviour
{
    public string nameOfSprite;
    public string path;

    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<SpriteRenderer>() != null)
            nameOfSprite = this.GetComponent<SpriteRenderer>().sprite.name;
        else
            nameOfSprite = this.GetComponent<Image>().sprite.name;
        path = "design/GUI/" + design_menu.stylesEngName[design_menu.id] + "/Normal/" + nameOfSprite;
        reload();
    }

    public void reload()
    {
        path = "design/GUI/" + design_menu.stylesEngName[design_menu.id] + "/Normal/" + nameOfSprite;
        if (this.GetComponent<SpriteRenderer>() != null)
            this.GetComponent<SpriteRenderer>().sprite = (Sprite)(Resources.Load<Sprite>(path) as Sprite);
        else
            this.GetComponent<Image>().sprite = (Sprite)(Resources.Load<Sprite>(path) as Sprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (design_menu.reseting)
            reload();
    }
    
}
