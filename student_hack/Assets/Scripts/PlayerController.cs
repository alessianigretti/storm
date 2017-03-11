using UnityEngine;
using System.Collections;
using System.Globalization;
using System;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private float maxSpeed = 20;
    private float velocity;
    public GameObject whiteSmoke;
    public GameObject[] thunderSounds;
    public GameObject lightObj;
    private string url = "http://cc427ea4.ngrok.io/api/public/rate";
    private int frameCount;
    
    public IEnumerator GetUrl()
    {
        WWW www = new WWW(url);
        yield return www;

        int i = 10;
        string temp;
        string concat = "";
        do
        {
            temp = www.text.Substring(i, 1);
            concat += temp;
            i++;
        }
        while (temp != "\"");

        string finalConcat = concat.Substring(0, concat.Length - 1);
        try
        {
            speed = float.Parse(finalConcat, CultureInfo.InvariantCulture.NumberFormat);
        } catch(Exception e)
        {
            Debug.Log(e);
        }
    }

    void Start()
    {
        StartCoroutine(GetUrl());

        if (speed < 80)
        {
            StartCoroutine(PlayThenWait(4f));
            AnimationClip flashlight = (AnimationClip)Resources.Load("SlowerFlashLight");
            lightObj.GetComponent<Animation>().AddClip(flashlight, "Flashlight");
        }
        else if (speed >= 80 && speed < 90)
        {
            StartCoroutine(PlayThenWait(3f));
            AnimationClip flashlight = (AnimationClip)Resources.Load("SlowerFlashLight");
            lightObj.GetComponent<Animation>().AddClip(flashlight, "Flashlight");
        }
        else if (speed >= 90 && speed < 100)
        {
            StartCoroutine(PlayThenWait(2f));
            AnimationClip flashlight = (AnimationClip)Resources.Load("FlashLight");
            lightObj.GetComponent<Animation>().AddClip(flashlight, "Flashlight");
        }
        else if (speed >= 100)
        {
            StartCoroutine(PlayThenWait(1f));
            AnimationClip flashlight = (AnimationClip)Resources.Load("FlashLight");
            lightObj.GetComponent<Animation>().AddClip(flashlight, "Flashlight");
        }
    }

    void Update()
    {
        Debug.Log(speed);
        if (speed < 80)
        {
            velocity = 0.1f;
            whiteSmoke.GetComponent<ParticleSystem>().emissionRate = 1f;
            lightObj.GetComponent<Animation>().Play("FlashLight");
        }
        else if (speed >= 80 && speed < 90)
        {
            velocity = 0.5f;
            whiteSmoke.GetComponent<ParticleSystem>().emissionRate = 3f;
            lightObj.GetComponent<Animation>().Play("FlashLight");
        }
        else if (speed >= 90 && speed < 100)
        {
            velocity = 0.8f;
            whiteSmoke.GetComponent<ParticleSystem>().emissionRate = 5f;
            lightObj.GetComponent<Animation>().Play("FlashLight");
        }
        else if (speed >= 100)
        {
            velocity = 1f;
            whiteSmoke.GetComponent<ParticleSystem>().emissionRate = 10f;
            lightObj.GetComponent<Animation>().Play("FlashLight");
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += this.transform.forward * velocity;
        }
    }

    IEnumerator PlayThenWait(float time)
    {
        int index = UnityEngine.Random.Range(0, 4);
        thunderSounds[index].SetActive(true);
        if (thunderSounds[index].activeSelf)
        {
            thunderSounds[index].SetActive(false);
            thunderSounds[index].SetActive(true);
        }
        yield return new WaitForSeconds(time);
        Start();
    }
}
