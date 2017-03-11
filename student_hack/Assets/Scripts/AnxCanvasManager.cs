using UnityEngine;
using System.Collections;

public class AnxCanvasManager : MonoBehaviour
{
    public GameObject wrongSign, youAreWrongSign, background;
    private WaitForSeconds wrongWait, wrongPause, youAreWrongWait;
    public float wrongWaitSec, wrongPauseSec, youAreWrongWaitSec;
    public GameObject wrongTone;

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
        wrongSign.SetActive(false);
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
        youAreWrongSign.SetActive(true);
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
        youAreWrongSign.SetActive(false);
        background.SetActive(false);
        wrongTone.SetActive(false);
    }
}
