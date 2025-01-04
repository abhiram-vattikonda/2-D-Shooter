using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    //public static PowerManager instance { get; set; }


    public GameObject powerMenu;
    [SerializeField] private GameObject button0;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;

    Powerup.upgrade[] powers;
    Powerup p = new Powerup { };


    public static bool buttonNotClicked;
    public static bool menuIsShowing;


    //
    private void Start()
    {
        Time.timeScale = 1f;
        buttonNotClicked = true;
        powerMenu.SetActive(false);
        button0.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);

    }

    private void Update()
    {
        CheckPower();

        if (!menuIsShowing)
        {
            powerMenu.SetActive(false);
        }
    }


    private void CheckPower()
    {
       ///
    }
    public void PowerUpsMenu()
    {
        Time.timeScale = 0f;
        powerMenu.SetActive(true);
        button0.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);


        powers = p.ChoosePowerUps();


        button0.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[0].name + "\n\n\n" + powers[0].descriptions[powers[0].stages];
        button1.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[1].name + "\n\n\n" + powers[1].descriptions[powers[1].stages];
        button2.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[2].name + "\n\n\n" + powers[2].descriptions[powers[2].stages];


        menuIsShowing = true;
        buttonNotClicked = true;
    }
}
