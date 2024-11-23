using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        SetMaxExp(100);
    }

    public void SetMaxExp(float maxExp)
    {
        slider.maxValue = maxExp;
        slider.value = 0;
    }

    public void UpdateExp(float exp)
    {
        slider.value += exp;
    }
}
