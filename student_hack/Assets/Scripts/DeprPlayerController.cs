using UnityEngine;
using System.Collections;
using System.Globalization;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeprPlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;
    private string url = "http://cc427ea4.ngrok.io/api/public/rate";
    private float speed;
    public float maxDistance;
    private int frameCount = 0;
    private Vector3 oldScale;
    private Vector3 newScale1 = new Vector3(1, 1, 1);
    private Vector3 newScale2 = new Vector3(2, 2, 2);
    private Vector3 newScale3 = new Vector3(3, 3, 3);
    private Vector3 newScale4 = new Vector3(4, 4, 4);
    public GameObject audioS;
    public Text heartrate;

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
        speed = float.Parse(finalConcat, CultureInfo.InvariantCulture.NumberFormat);
    }

    void Start()
    {
        StartCoroutine(GetUrl());

        oldScale = target.transform.localScale;

        if (speed < 80)
        {
            target.GetComponent<Animator>().speed = 1f;
            target.transform.localScale = newScale1;
            audioS.GetComponent<AudioSource>().pitch = 1f;
        }
        else if (speed >= 80 && speed < 90)
        {
            target.GetComponent<Animator>().speed = 2f;
            target.transform.localScale = newScale2;
            audioS.GetComponent<AudioSource>().pitch = 1.5f;
        }
        else if (speed >= 90 && speed < 100)
        {
            target.GetComponent<Animator>().speed = 4f;
            target.transform.localScale = newScale3;
            audioS.GetComponent<AudioSource>().pitch = 2f;
        }
        else if (speed >= 100)
        {
            target.GetComponent<Animator>().speed = 5f;
            target.transform.localScale = newScale4;
            audioS.GetComponent<AudioSource>().pitch = 3f;
        }

        StartCoroutine(CallWeb());
    }

    void Update()
    {
        Debug.Log(speed);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            mainCamera.transform.position += mainCamera.transform.forward * 0.1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Vector3.Distance(mainCamera.transform.position, target.transform.position) < maxDistance)
                mainCamera.transform.position += -mainCamera.transform.forward * 0.1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            mainCamera.transform.position += mainCamera.transform.right * 0.1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            mainCamera.transform.position += -mainCamera.transform.right * 0.1f;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            BackToMenu();
        }

        mainCamera.transform.LookAt(target.transform);

        heartrate.text = speed.ToString();
    }

    IEnumerator CallWeb()
    {
        if (target.transform.localScale == newScale4)
        {
            yield return new WaitForSeconds(20f);
            BackToMenu();
        }
        else
        {
            yield return new WaitForSeconds(5f);
            Start();
        }
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}