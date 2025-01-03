using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    [SerializeField] private GameObject powerMenu;
    [SerializeField] private GameObject button0;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;

    private void Start()
    {
        Time.timeScale = 1f;
        powerMenu.SetActive(false);
        button0.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
    }
    public void PowerUpsMenu()
    {
        Time.timeScale = 0f;
        powerMenu.SetActive(true);
        button0.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);

        Powerup.upgrade[] powers = Powerup.ChoosePowerUps();
        Debug.Log(powers[0].name + " and " + powers[1].name + " and " + powers[2].name);


        button0.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[0].name + "\n\n\n" + powers[0].descriptions[powers[0].stages];
        button1.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[1].name + "\n\n\n" + powers[1].descriptions[powers[1].stages];
        button2.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[2].name + "\n\n\n" + powers[2].descriptions[powers[2].stages];
    }
}
