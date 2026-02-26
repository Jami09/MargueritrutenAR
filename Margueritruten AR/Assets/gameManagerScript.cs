using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour
{
    public Image[] objects;
    public GameObject[] objectPopup;

    // Start is called before the first frame update
    void Start()
    {
        //objectPopup.SetActive(false);
    }

    // Update is called once per frame
    public void popup()
    {        
            Debug.Log("hej: " + objects[0].name); //objects[i].sprite.name);

            if(objects[0].sprite.name == "unknown2")
            {
                objectPopup[0] = objects[0].transform.GetChild(0).gameObject;

                switch (objects[0].name)
                {
                    case "KnifeObject":
                        objectPopup[0].SetActive(true);
                        break;
                    case "RingObject":
                        objectPopup[1].SetActive(true);
                        break;
                    case "DressObject":
                        objectPopup[2].SetActive(true);
                        break;
                    default:
                        Debug.Log("Popup Error");
                        break;
                }
            }        
    }

    public void exitPopup()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            //Debug.Log("hej: " + objects[i].sprite.name); //objects[i].sprite.name);

            if (objects[i].sprite.name == "unknown2")
            {
                Debug.Log("yay");

                //Find the child named "ammo" of the gameobject "magazine" (magazine is a child of "gun").
                //objectPopup[i] = objects[i].transform.Find("popup");

                // objectPopup[i].SetActive(true);

                objectPopup[i] = objects[i].transform.GetChild(0).gameObject;
               /* objectPopup[1] = objects[1].transform.GetChild(0).gameObject;
                objectPopup[2] = objects[2].transform.GetChild(0).gameObject;*/

                objectPopup[i].SetActive(false);
                /*objectPopup[1].SetActive(false);
                objectPopup[2].SetActive(false);*/
            }
        }
    }
}
