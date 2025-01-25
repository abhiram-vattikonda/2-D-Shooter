using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    public static PowerManager instance { get; set; }


    public GameObject powerMenu;
    [SerializeField] private Button button0;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;

    private List<Powerup.upgrade> powers = new List<Powerup.upgrade> { };
    private Powerup p = new Powerup { };


    public bool buttonNotClicked;
    public bool menuIsShowing;


    //
    private void Start()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1f;
        buttonNotClicked = true;
        menuIsShowing = false;
        powerMenu.SetActive(false);
        button0.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

    }

    private void Update()
    {
        CheckWhichPowerIsPressed();

        if (!menuIsShowing)
            powerMenu.SetActive(false);
        
    }


    private void CheckWhichPowerIsPressed()
    {
        button0.onClick.RemoveAllListeners();
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();


        if (powers.Count == 0)
            return;
        if (menuIsShowing && buttonNotClicked)
            button0.onClick.AddListener(() => p.UpgradeChosen(powers[0]));
        if (menuIsShowing && buttonNotClicked)
            button1.onClick.AddListener(() => p.UpgradeChosen(powers[1]));
        if (menuIsShowing && buttonNotClicked)
            button2.onClick.AddListener(() => p.UpgradeChosen(powers[2]));
      
    }
    public void PowerUpsMenu()
    {
        Time.timeScale = 0f;
        powerMenu.SetActive(true);
        button0.gameObject.SetActive(true);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);


        powers = p.ChoosePowerUps();


        button0.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[0].name + "\n\n\n" + powers[0].descriptions[powers[0].stages];
        button1.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[1].name + "\n\n\n" + powers[1].descriptions[powers[1].stages];
        button2.transform.GetChild(0).GetComponent<TMP_Text>().text = powers[2].name + "\n\n\n" + powers[2].descriptions[powers[2].stages];


        menuIsShowing = true;
        buttonNotClicked = true;
    }
}
