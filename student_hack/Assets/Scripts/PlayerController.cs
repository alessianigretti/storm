using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 65;
    private float maxSpeed = 20;
    private float velocity;
    public GameObject whiteSmoke;
    public GameObject[] thunderSounds;
    public GameObject light;

    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
    
    IEnumerator GetUrl()
    {
        WWW www = new WWW(url);
        yield return www;
        //speed = www.GetHashCode();
    }

    void Start()
    {
        if (speed < 80)
        {
            StartCoroutine(PlayThenWait(3f));
            AnimationClip flashlight = (AnimationClip)Resources.Load("SlowerFlashLight");
            light.GetComponent<Animation>().AddClip(flashlight, "Flashlight");
        }
        else if (speed >= 80 && speed < 90)
        {
            StartCoroutine(PlayThenWait(2f));
            AnimationClip flashlight = (AnimationClip)Resources.Load("SlowerFlashLight");
            light.GetComponent<Animation>().AddClip(flashlight, "Flashlight");
        }
        else if (speed >= 90 && speed < 100)
        {
            StartCoroutine(PlayThenWait(1f));
            AnimationClip flashlight = (AnimationClip)Resources.Load("FlashLight");
            light.GetComponent<Animation>().AddClip(flashlight, "Flashlight");
        }
        else if (speed >= 100)
        {
            StartCoroutine(PlayThenWait(.5f));
            AnimationClip flashlight = (AnimationClip)Resources.Load("FlashLight");
            light.GetComponent<Animation>().AddClip(flashlight, "Flashlight");
        }
    }

    void Update()
    {
        if (speed < 80)
        {
            velocity = 0.1f;
            whiteSmoke.GetComponent<ParticleSystem>().emissionRate = 1f;
            light.GetComponent<Animation>().Play("FlashLight");
        }
        else if (speed >= 80 && speed < 90)
        {
            velocity = 0.5f;
            whiteSmoke.GetComponent<ParticleSystem>().emissionRate = 3f;
            light.GetComponent<Animation>().Play("FlashLight");
        }
        else if (speed >= 90 && speed < 100)
        {
            velocity = 0.8f;
            whiteSmoke.GetComponent<ParticleSystem>().emissionRate = 5f;
            light.GetComponent<Animation>().Play("FlashLight");
        }
        else if (speed >= 100)
        {
            velocity = 1f;
            whiteSmoke.GetComponent<ParticleSystem>().emissionRate = 10f;
            light.GetComponent<Animation>().Play("FlashLight");
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += this.transform.forward * velocity;
        }
    }

    IEnumerator PlayThenWait(float time)
    {
        int index = Random.Range(0, 4);
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
