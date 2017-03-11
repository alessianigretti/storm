using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnxLevelManager : MonoBehaviour
{
    public Transform mainCamera;

    void Update()
    {
        if (mainCamera.position.z > 50f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
