using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PowerUpImplementations 
{

    public void Damage_Fire_implement(int stage)
    {
        if (stage == 0)
        {
            Bullet.currentDamage *= 1.5f;
            GameInput.currentFirerate /= 1.5f;
        }
        else if (stage == 1)
        {
            Bullet.currentDamage *= 1.75f;
            GameInput.currentFirerate /= 1.5f;
        }
        else if (stage == 2)
        {
            Bullet.currentDamage *= 2;
            GameInput.currentFirerate /= 1.5f;
        }

    }


    public void Movement_Speed(int stage)
    {
        if (stage == 0)
        {
            Player.instance.currentPlayerSpeed *= 1.3f;
        }
        else if (stage == 1)
        {
            Player.instance.currentPlayerSpeed *= 1.4f;
        }
        else if (stage == 2)
        {
            Player.instance.currentPlayerSpeed *= 1.5f;
        }

    }


    public void Increase_Size(int stage)
    {
        float currentHealthPercent = (Player.instance.health / Player.instance.currentMaxHealth) * 100;
        if (stage == 0)
        {
            Player.instance.transform.localScale *= 1.15f;
            Player.instance.currentMaxHealth *= 1.5f;
            Player.instance.healthBar.SetMaxHealth(Player.instance.currentMaxHealth);
            Player.instance.healthBar.UpdateHealth(Player.instance.currentMaxHealth * (currentHealthPercent / 100));
            Player.instance.currentPlayerSpeed *= 0.75f;
        }
        else if (stage == 1)
        {
            Player.instance.transform.localScale *= 1.30f;
            Player.instance.currentMaxHealth *= 1.75f;
            Player.instance.healthBar.SetMaxHealth(Player.instance.currentMaxHealth);
            Player.instance.healthBar.UpdateHealth(Player.instance.currentMaxHealth * (currentHealthPercent / 100));
            Player.instance.currentPlayerSpeed *= 0.75f;

        }
        else if (stage == 2)
        {
            Player.instance.transform.localScale *= 1.45f;
            Player.instance.currentMaxHealth *= 2f;
            Player.instance.healthBar.SetMaxHealth(Player.instance.currentMaxHealth);
            Player.instance.healthBar.UpdateHealth(Player.instance.currentMaxHealth * (currentHealthPercent/100));
            Player.instance.currentPlayerSpeed *= 0.75f;
        }
    }

    public void Razor(int stage)
    {
        if (stage == 0)
        {

        }
        else if (stage == 1)
        {

        }
        else if (stage == 2)
        {

        }
    }

    public void Regen(int stage)
    {
        Player.instance.regenIsOn = true;
        if (stage == 0)
        {
            Player.instance.regenRate = 1;
        }
        else if (stage == 1)
        {
            Player.instance.regenRate *= 1.5f;
        }
        else if (stage == 2)
        {
            Player.instance.regenRate *= 2f;
        }
    }

}
