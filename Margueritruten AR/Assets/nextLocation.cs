using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLocation : MonoBehaviour
{
    public Text nextLoc;
    public GameObject[] pins;
    public GameObject[] objects; // 0-2 fundet img --- 3-5 q'mark

    
    void Start()
    {
        vibrate = false;

        for(int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(false);
        }

        for (int i = 0; i < 3; i++)
        {
            objects[i].SetActive(false);
        }
        for (int i = 3; i < 6; i++)
        {
            objects[i].SetActive(true);
        }
    }

    /* Objekter der skal findes:
     * Kniv, ved afgrunden
     * Ring, ved bakkerne
     * Kjole, ved udsigten
     * Den endelige historie kommer frem når alle objekter er fundet og man er ved talerstoeln
     */
    void Update()
    {
        //Intet fundet
        if (PlayerPrefs.GetInt("knifeFound") == 0)
        {
            Debug.Log("start");
            pins[0].SetActive(true);
            nextLoc.text = "Første lokation:  Afgrunden";
        }
        //kniv fundet
        if (PlayerPrefs.GetInt("knifeFound") == 1)
        {
            Debug.Log("kniv");
            nextLoc.text = "Næste lokation:  Bakkerne";
        }
        //ring fundet
        if (PlayerPrefs.GetInt("ringFound") == 1)
        {
            Debug.Log("ring");
            nextLoc.text = "Næste lokation:  Udsigten";
        }
        //kjole fundet
        if (PlayerPrefs.GetInt("dressFound") == 1)
        {
            Debug.Log("kjole");
            nextLoc.text = "Sidste lokation:  Talerstolen";
        }
    }

    //0 = ikke fundet, 1 = fundet
    public void KnifeFound()
    {
        PlayerPrefs.SetInt("knifeFound", 1);
        pins[0].SetActive(false);
        pins[1].SetActive(true);
        objects[0].SetActive(true);
        objects[3].SetActive(false);
    }

    public void RingFound()
    {
        PlayerPrefs.SetInt("ringFound", 1);
        pins[1].SetActive(false);
        pins[2].SetActive(true);
        objects[1].SetActive(true);
        objects[4].SetActive(false);
    }

    public void DressFound()
    {
        PlayerPrefs.SetInt("dressFound", 1);
        pins[2].SetActive(false);
        pins[3].SetActive(true);
        objects[2].SetActive(true);
        objects[5].SetActive(false);
    }

    //reset game
    public void resetGame()
    {
        PlayerPrefs.SetInt("ringFound", 0);
        PlayerPrefs.SetInt("dressFound", 0);
        PlayerPrefs.SetInt("knifeFound", 0);
        PlayerPrefs.SetInt("rewardStoryUnlocked", 0);
        Start();
    }

    public void storyScene()
    {
        PlayerPrefs.SetInt("rewardStoryUnlocked", 1);
        SceneManager.LoadScene("Story");
    }
}
