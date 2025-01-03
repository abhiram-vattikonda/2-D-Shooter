using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    public static PowerManager instance { get; set; }


    public GameObject powerMenu;
    [SerializeField] private GameObject button0;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;


    public static bool buttonNotClicked = true;


    private void Awake()
    {
        if (instance != null)
            Debug.LogError("There is more than one PowerManager");
        instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1f;
        buttonNotClicked = true;
        powerMenu.SetActive(false);
        button0.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);

    }
    public void PowerUpsMenu()
    {
        Time.timeScale = 0f;
        buttonNotClicked = true;
        powerMenu.SetActive(true);
        button0.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);

        Powerup p = new Powerup { };


        Powerup.upgrade[] powers = p.ChoosePowerUps();


        button0.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[0].name + "\n\n\n" + powers[0].descriptions[powers[0].stages];
        button1.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[1].name + "\n\n\n" + powers[1].descriptions[powers[1].stages];
        button2.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[2].name + "\n\n\n" + powers[2].descriptions[powers[2].stages];

        if (buttonNotClicked)
            button0.GetComponent<Button>().onClick.AddListener(() => p.UpgradeChosen(powers[0]));
        if (buttonNotClicked)
            button1.GetComponent<Button>().onClick.AddListener(() => p.UpgradeChosen(powers[1]));
        if (buttonNotClicked)
            button2.GetComponent<Button>().onClick.AddListener(() => p.UpgradeChosen(powers[2]));
    }
}
