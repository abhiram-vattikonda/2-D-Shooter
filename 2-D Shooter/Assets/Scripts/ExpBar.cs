using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private PowerManager powerManager;

    static public Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        SetMaxExp(100);
    }

    private void Update()
    {
        if (slider.value == slider.maxValue)
        {
            Debug.Log("EXP MAX");
            SetMaxExp(slider.maxValue * 2);
            powerManager.PowerUpsMenu();

        }
    }

    static public void SetMaxExp(float maxExp)
    {
        slider.maxValue = maxExp;
        slider.value = 0;
    }

    static public void UpdateExp(float exp)
    {
        slider.value += exp;
    }
}
