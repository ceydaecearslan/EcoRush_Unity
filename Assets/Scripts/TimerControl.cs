using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    private Slider timerSlider;
    public GameObject GameUI;
    public GameObject DeadUI;
    private int time = 100;

    private void Awake() 
    {
        timerSlider = GetComponent<Slider>();
    }
    void Start()
    {
        timerSlider.value = time;
        TimeUpdate();
    }

    private void TimeUpdate()
    {
        StartCoroutine(TimeRoutine());
        IEnumerator TimeRoutine()
        {
            for (int i = 0; i <= 100; i++)
            {
                yield return new WaitForSeconds(1f);
                time--;
                timerSlider.value = time;
            }
            GameUI.SetActive(false);
            DeadUI.SetActive(true);
        }
    }
}
