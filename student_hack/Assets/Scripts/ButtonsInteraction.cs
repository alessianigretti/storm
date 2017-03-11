using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsInteraction : MonoBehaviour
{
    public GameObject anx, depr, panic, exit;
    public GameObject mainAudio, hoverAudio, pressAudio;
    public GameObject canvas, mainMenu;

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
        Debug.Log("Load scene 1");
        mainAudio.SetActive(false);
        pressAudio.SetActive(true);
        SceneManager.LoadScene(1);
    }
}
