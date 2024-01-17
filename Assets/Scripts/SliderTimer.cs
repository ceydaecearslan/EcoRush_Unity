using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public Slider slider;
    public float startTime = 60f;
    public GameObject PauseUI;
    public GameObject GameUI;
    public GameObject DeadUI;
    private float remainingTime;

    void Start()
    {
        remainingTime = startTime;

        slider.value = startTime;
    }

    void Update()
    {
        if(!PauseUI.activeSelf)
        {
            remainingTime -= Time.deltaTime;

            slider.value = remainingTime;

            if (remainingTime <= 0f)
            {
                TimeRunOut();
            }
        }
    }

    public void TimeAdd(float addedTime)
    {
        remainingTime += addedTime;
    }

    void TimeRunOut()
    {
        GameUI.SetActive(false);
        DeadUI.SetActive(true);
    }
}
