using UnityEngine;
using System.Collections;

public class AnxCanvasManager : MonoBehaviour
{
    public GameObject[] wrongSigns = new GameObject[8];
    public GameObject background;
    private WaitForSeconds wrongWait, wrongPause, youAreWrongWait;
    public float wrongWaitSec, wrongPauseSec, youAreWrongWaitSec;
    public GameObject wrongTone;
    public GameObject mainCamera;

    void Start()
    {
        wrongWait = new WaitForSeconds(wrongWaitSec);
        wrongPause = new WaitForSeconds(wrongPauseSec);
        youAreWrongWait = new WaitForSeconds(youAreWrongWaitSec);
        StartCoroutine(WrongWait(1.5f));
        wrongTone.SetActive(true);
    }

    IEnumerator WrongWait(float time)
    {
        yield return wrongWait;
        DeactivateWrongSign();
    }

    void DeactivateWrongSign()
    {
        wrongSigns[0].SetActive(false);
        background.SetActive(false);
        wrongTone.SetActive(false);
        StartCoroutine(WrongPause(3f));
    }

    IEnumerator WrongPause(float time)
    {
        yield return wrongPause;
        ActivateYouAreWrongSign();
    }

    void ActivateYouAreWrongSign()
    {
        wrongSigns[1].SetActive(true);
        background.SetActive(true);
        wrongTone.SetActive(true);
        StartCoroutine(YouAreWrongWait(1.5f));
    }

    IEnumerator YouAreWrongWait(float time)
    {
        yield return youAreWrongWait;
        DeactivateAll();
    }

    void DeactivateAll()
    {
        wrongSigns[1].SetActive(false);
        background.SetActive(false);
        wrongTone.SetActive(false);
    }

    void Update()
    {
        if (mainCamera.transform.position.z > -350f && mainCamera.transform.position.z < -330f)
        {
            wrongSigns[2].SetActive(true);
            background.SetActive(true);
            wrongTone.SetActive(true);
        }
        else if (mainCamera.transform.position.z > -330f && mainCamera.transform.position.z < -310f)
        {
            wrongSigns[2].SetActive(false);
            background.SetActive(false);
            wrongTone.SetActive(false);
        }
        else if (mainCamera.transform.position.z > -310f && mainCamera.transform.position.z < -290f)
        {
            wrongSigns[3].SetActive(true);
            background.SetActive(true);
            wrongTone.SetActive(true);
        }
        else if (mainCamera.transform.position.z > -290f && mainCamera.transform.position.z < -250f)
        {
            wrongSigns[3].SetActive(false);
            background.SetActive(false);
            wrongTone.SetActive(false);
        }
        else if (mainCamera.transform.position.z > -250f && mainCamera.transform.position.z < -240f)
        {
            wrongSigns[4].SetActive(true);
            background.SetActive(true);
            wrongTone.SetActive(true);
        }
        else if (mainCamera.transform.position.z > -240f && mainCamera.transform.position.z < -200f)
        {
            wrongSigns[4].SetActive(false);
            background.SetActive(false);
            wrongTone.SetActive(false);
        }
        else if (mainCamera.transform.position.z > -200f && mainCamera.transform.position.z < -180f)
        {
            wrongSigns[5].SetActive(true);
            background.SetActive(true);
            wrongTone.SetActive(true);
        }
        else if (mainCamera.transform.position.z > -180f && mainCamera.transform.position.z < -100f)
        {
            wrongSigns[5].SetActive(false);
            background.SetActive(false);
            wrongTone.SetActive(false);
        }
        else if (mainCamera.transform.position.z > -100f && mainCamera.transform.position.z < -80f)
        {
            wrongSigns[6].SetActive(true);
            background.SetActive(true);
            wrongTone.SetActive(true);
        }
        else if (mainCamera.transform.position.z > -80f && mainCamera.transform.position.z < -50f)
        {
            wrongSigns[6].SetActive(false);
            background.SetActive(false);
            wrongTone.SetActive(false);
        }
        else if (mainCamera.transform.position.z > -50f && mainCamera.transform.position.z < -20f)
        {
            wrongSigns[7].SetActive(true);
            background.SetActive(true);
            wrongTone.SetActive(true);
        }
        else if (mainCamera.transform.position.z > -20f && mainCamera.transform.position.z < 50f)
        {
            wrongSigns[7].SetActive(false);
            background.SetActive(false);
            wrongTone.SetActive(false);
        }
        else if (mainCamera.transform.position.z > 50f && mainCamera.transform.position.z < 100f)
        {
            wrongSigns[8].SetActive(true);
            background.SetActive(true);
            wrongTone.SetActive(true);
        }
        else if (mainCamera.transform.position.z > 100f && mainCamera.transform.position.z < 150f)
        {
            wrongSigns[8].SetActive(false);
            background.SetActive(false);
            wrongTone.SetActive(false);
        }
    }
}
