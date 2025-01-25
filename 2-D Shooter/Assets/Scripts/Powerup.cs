using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;


public class Powerup
{

    public static Powerup instance {  get; set; }

    public static upgrade[] upgrades = new upgrade[]
    {
        new upgrade {name= "Bullet Damage and Speed", descriptions= new string[]{"Increase damage: +50%\nIncrease Fire rate: +50%", "Increase damage: +75%\nIncrease Fire rate: +50%", "Increase damage: +100%\nIncrease Fire rate: +50%"}},
        new upgrade {name= "Movement Speed", descriptions= new string[]{"Increase speed: +30%", "Increase speed: +40%", "Increase speed: +50%"}},
        new upgrade {name= "Increase Size", descriptions= new string[]{"Increase size: +15%\nIncrease Max health: +50%\nDecrease speed: -25%", "Increase size: +30%\nIncrease Max health: +75%\nDecrease speed: -25%", "Increase size: +45%\nIncrease Max health: +100%\nDecrease speed: -25%"}},
        new upgrade {name= "Razor", descriptions= new string[]{"Razors: +1", "Razors: +1\nIncrease damage: +50%", "Raxors: +2\nIncrease damage: +50%\nIncrease Rotation Speed: +50%"}},
        new upgrade {name= "Regeneration", descriptions= new string[]{"Increase health: +1 hp/s", "Increase Regenration rate: +50%", "Increase Regeneration rate: +100%"}}
    };

    
    private void Start()
    {
        if (instance == null)
            instance = this;

        foreach(upgrade upgrade in upgrades)
        {
            upgrade.stages = 0;
        }
    }



    public List<upgrade> ChoosePowerUps()
    {
        upgrade none = new upgrade {name = "NONE", descriptions = new string[]{ "no Powerups Left, This is zill", "no Powerups Left This is zill", "no Powerups Left This is zill" }, stages = 0 };

        List<upgrade> availableUpgrades = new List<upgrade> { };
        foreach (upgrade upgrade in upgrades)
        {
            if (upgrade.stages < 3)
            { availableUpgrades.Add(upgrade); }
        }
        ReShuffle(availableUpgrades);

        while (availableUpgrades.Count < 3)
        {
            availableUpgrades.Add(none);
        }
        
        upgrade power1 = availableUpgrades[0];
        upgrade power2 = availableUpgrades[1];
        upgrade power3 = availableUpgrades[2];
        return new List<Powerup.upgrade> { power1, power2, power3 };
    }


    public void UpgradeChosen(upgrade power)
    {
        if (power.name == "NONE")   return;

        PowerUpImplementations p = new PowerUpImplementations();


        PowerManager.instance.buttonNotClicked = false;
        //Debug.Log(power.name + " Clicked " + power.stages);

        if (power.name == "Damage and fire rate")
        {
            p.Damage_Fire_implement(power.stages);
        }
        if (power.name == "Movement Speed")
        {
            p.Movement_Speed(power.stages);
        }
        if (power.name == "Increase Size")
        {
           p.Increase_Size(power.stages);
        }
        if (power.name == "Razor")
        {
            p.Razor(power.stages);
        }
        if (power.name == "Regeneration")
        {
            p.Regen(power.stages);
        }

        foreach (upgrade upgrade in upgrades)
        { if (upgrade.name == power.name) upgrade.stages++; }

        PowerManager.instance.menuIsShowing = false;
        PauseMenu.Resume();
    }


    public void ReShuffle<T>(List<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }



    public class upgrade
    {
        public int stages = 0;
        public string name { get; set; }
        public string[] descriptions {  get; set; }
    }
    
}
