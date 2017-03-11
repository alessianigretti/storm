using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsInteraction : MonoBehaviour
{
    public GameObject anx, depr, panic, exit;
    public GameObject mainAudio, hoverAudio, pressAudio;

    public void HighlightAnx()
    {
        anx.SetActive(true);
        hoverAudio.SetActive(true);
    }

    public void HighlightDepr()
    {
        depr.SetActive(true);
        hoverAudio.SetActive(true);
    }

    public void HighlightPanic()
    {
        panic.SetActive(true);
        hoverAudio.SetActive(true);
    }

    public void HighlightExit()
    {
        exit.SetActive(true);
        hoverAudio.SetActive(true);
    }

    public void Unhighlight()
    {
        anx.SetActive(false);
        depr.SetActive(false);
        panic.SetActive(false);
        exit.SetActive(false);
        hoverAudio.SetActive(false);
    }

    public void AnxButtonPressed()
    {
        Debug.Log("jdisjj");
        mainAudio.SetActive(false);
        pressAudio.SetActive(true);
    }
}
