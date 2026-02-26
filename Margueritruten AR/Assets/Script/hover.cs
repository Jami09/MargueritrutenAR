using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    string spriteName;
    public Image[] objects;
    public GameObject[] objectPopup;

    void Start()
    {
        for (int i = 0; i < objectPopup.Length; i++)
        {
            objectPopup[i].SetActive(false);
        }
    }

    //reveal popup on hover
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hello: " + GetComponent<UnityEngine.UI.Image>().sprite.name);

        spriteName = GetComponent<UnityEngine.UI.Image>().sprite.name;

        if (spriteName == "unknown2")
        {
            Debug.Log("yes man!!!: " + this.gameObject.name);

            switch (this.gameObject.name)
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

    //deactivate popup
    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < objectPopup.Length; i++)
        {
            objectPopup[i].SetActive(false);
        }
    }
}
