using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject settingsPanel;
    public int rewardStoryUnlocked;     //1 = true, 0 = false

    void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void arCam()
    {
        resetGame();
        SceneManager.LoadScene("Story");
    }

    public void profileScene()
    {
        SceneManager.LoadScene("Story");
    }

    public void resetGame()
    {
        PlayerPrefs.SetInt("rewardStoryUnlocked", 0);
        PlayerPrefs.SetInt("ringFound", 0);
        PlayerPrefs.SetInt("dressFound", 0);
        PlayerPrefs.SetInt("knifeFound", 0);
    }
}
