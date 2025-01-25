using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;

    private float currentTime = 0f;

    private void Awake()
    {
        //timerText = GetComponent<TextMeshPro>();
    }


    void Update()

    {

        currentTime += Time.deltaTime;

        string formattedTime = FormatTime(currentTime);

        timerText.text = formattedTime;

    }



    // Helper function to format time into minutes and seconds

    string FormatTime(float time)

    {

        int minutes = Mathf.FloorToInt(time / 60);

        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
