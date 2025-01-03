using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu]
public class Powerup : MonoBehaviour
{
    private upgrade[] upgrades = new upgrade[]
    {
        new upgrade {name= "Damage and fire rate", descriptions= new string[]{"Increase damage: +50%\nIncrease Fire rate: +50%", "Increase damage: +75%\nIncrease Fire rate: +50%", "Increase damage: +100%\nIncrease Fire rate: +50%"}},
        new upgrade {name= "Movement Speed", descriptions= new string[]{"Increase speed: +30%", "Increase speed: +40%", "Increase speed: +50%"}},
        new upgrade {name= "Increase Size", descriptions= new string[]{"Increase size: +15%\nIncrease Max health: +50%\nDecrease speed: -25%", "Increase size: +30%\nIncrease Max health: +75%\nDecrease speed: -25%", "Increase size: +45%\nIncrease Max health: +100%\nDecrease speed: -25%"}},
        new upgrade {name= "Razor", descriptions= new string[]{"Razors: +1", "Razors: +1\nIncrease damage: +50%", "Raxors: +2\nIncrease damage: +50%\nIncrease Rotation Speed: +50%"}},
        new upgrade {name= "Regeneration", descriptions= new string[]{"Increase health: +1 hp/s", "Increase Regenration rate: +50%", "Increase Regeneration rate: +100%"}},
    };

    public void ChoosePowerUps()
    {
        reshuffle(upgrades);
        upgrade power1 = upgrades[0];
        upgrade power2 = upgrades[1];
        upgrade power3 = upgrades[2];
    }

    void reshuffle(upgrade[] texts)
    {
        for (int t = 0; t < texts.Length; t++)
        {
            upgrade tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }


    public class upgrade
    {
        public bool[] stages = { false };
        public string name { get; set; }
        public string[] descriptions {  get; set; }

    }
    
}