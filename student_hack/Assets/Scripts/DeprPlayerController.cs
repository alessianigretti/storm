using UnityEngine;
using System.Collections;
using System.Globalization;


public class DeprPlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;
    private string url = "http://cc427ea4.ngrok.io/api/public/rate";
    private float speed;
    private int frameCount = 0;

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

        if (speed < 80)
        {
            target.GetComponent<Animator>().speed = target.GetComponent<Animator>().speed * 2f;
        }
        else if (speed >= 80 && speed < 90)
        {
            target.GetComponent<Animator>().speed = target.GetComponent<Animator>().speed * 3f;
        }
        else if (speed >= 90 && speed < 100)
        {
            target.GetComponent<Animator>().speed = target.GetComponent<Animator>().speed * 4f;
        }
        else if (speed >= 100)
        {
            target.GetComponent<Animator>().speed = target.GetComponent<Animator>().speed * 5f;
        }
    }

    void Update()
    {
        frameCount++;
        if (frameCount % 3 == 0)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                mainCamera.transform.position += mainCamera.transform.forward * 0.1f;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
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

            mainCamera.transform.LookAt(target.transform);
        }
    }
}