using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Slider slider;
    private bool isLoading = false;
    private AsyncOperation ao;

    public void MoveToGame()
    {
        // Prevent multiple click
        if (!isLoading)
        {
            isLoading = true;
            slider.gameObject.SetActive(true);
            ao = SceneManager.LoadSceneAsync("IntroductionScene");
        }
    }

    public void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        slider.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (ao != null)
        {
            Debug.Log(ao.progress);
            slider.value = ao.progress;
        }
    }
}
