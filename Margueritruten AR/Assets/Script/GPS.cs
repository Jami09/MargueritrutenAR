using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GPS : MonoBehaviour {

    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;

    private bool isGPSready;

    public Text coordinates;
    
    //samleobjekter
    public GameObject Knife, Dress, Ring;
    public int rewardStoryUnlocked;

    //koordinater
    float knifeLatMin, knifeLatMax, knifeLongMin, knifeLongMax;
    float ringLatMin, ringLatMax, ringLongMin, ringLongMax;
    float dressLatMin, dressLatMax, dressLongMin, dressLongMax;
    float stolLatMin, stolLatMax, stolLongMin, stolLongMax;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //on start, start coroutine
        StartCoroutine(StartLocationService());

        Knife.SetActive(false);
        Dress.SetActive(false);
        Ring.SetActive(false);

        //set latitude
        knifeLatMin = 55.378950f;
        knifeLatMax = 55.379150f;
        knifeLongMin = 10.126300f;
        knifeLongMax = 10.126800f;
        
        ringLatMin = 55.381800f;
        ringLatMax = 55.382000f;
        ringLongMin = 10.124300f;
        ringLongMax = 10.124800f;

        dressLatMin = 55.382000f;
        dressLatMax = 55.382200f;
        dressLongMin = 10.128300f;
        dressLongMax = 10.128800f;

        stolLatMin = 55.383300f;
        stolLatMax = 55.383500f;
        stolLongMin = 10.129300f;
        stolLongMax = 10.129800f;
    }

    private IEnumerator StartLocationService()
    {
        //give notice if GPS hasn't been enabled, break from coroutine
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        //if GPS has been enabled, continue initializing GPS. maxium waittime set to 20
        Input.location.Start();
        int maxWait = 20; 

        //while the GPS status is initializing AND the maximum waittime is more than 0, do maxWait--, to create a countdown
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        
        //if maxwait has been reached, give notice and break from coroutine
        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        //if the GPS status is initialized but failed, give notice and break
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to dertermin device location");
            yield break;
        }

        //if passed through entire coroutine without break, the GPS is ready for use
        isGPSready = true;

    }

    private void Update()
    {
        //if the GPS is ready, continuously update latitude and longitude 
        if (isGPSready)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;


            coordinates.text = "Lat: " + GPS.Instance.latitude.ToString() + "    Long: " + GPS.Instance.longitude.ToString();


            //popup on location
            if(latitude >= knifeLatMin && latitude <= knifeLatMax && longitude >= knifeLongMin && longitude <= knifeLongMax)
            {
                Knife.SetActive(true);
            }

            if (latitude >= ringLatMin && latitude <= ringLatMax && longitude >= ringLongMin && longitude <= ringLongMax)
            {
                Ring.SetActive(true);
            }

            if (latitude >= dressLatMin && latitude <= dressLatMax && longitude >= dressLongMin && longitude <= dressLongMax)
            {
                Dress.SetActive(true);
            }

            if (latitude >= stolLatMin && latitude <= stolLatMax && longitude >= stolLongMin && longitude <= stolLongMax)
            {
                if (PlayerPrefs.GetInt("dressFound") == 1)
                {
                    playStory();
                }                
            }
        }
    }

    public void playStory()
    {
        //play story audio
        PlayerPrefs.SetInt("rewardStoryUnlocked", 1);
        SceneManager.LoadScene("Story");
    }
}
