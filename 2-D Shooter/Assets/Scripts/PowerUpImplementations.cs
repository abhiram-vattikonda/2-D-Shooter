using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpImplementations
{
    public void Damage_Fire_implement(int stage)
    {
        if (stage == 0)
        {
            Bullet.damage *= 1.5f;
            GameInput.fireRate /= 1.5f;
        }
        else if (stage == 1)
        {
            Bullet.damage *= 1.75f;
            GameInput.fireRate /= 1.5f;
        }
        else if (stage == 2)
        {
            Bullet.damage *= 2;
            GameInput.fireRate /= 1.5f;
        }

        Debug.Log("dandf player");
    }


    public void Movement_Speed(int stage)
    {
        if (stage == 0)
        {
            Player.instance.playerSpeed *= 1.3f;
        }
        else if (stage == 1)
        {
            Player.instance.playerSpeed *= 1.4f;
        }
        else if (stage == 2)
        {
            Player.instance.playerSpeed *= 1.5f;
        }

        Debug.Log("speed played");
    }


    public void Increase_Size(int stage)
    {
        float currentHealthPercent = (Player.instance.health / Player.instance.maxHealth) * 100;
        if (stage == 0)
        {
            Player.instance.transform.localScale *= 1.15f;
            Player.instance.maxHealth *= 1.5f;
            Player.instance.healthBar.SetMaxHealth(Player.instance.maxHealth);
            Player.instance.healthBar.UpdateHealth(Player.instance.maxHealth * (currentHealthPercent / 100));
            Player.instance.playerSpeed *= 0.75f;
        }
        else if (stage == 1)
        {
            Player.instance.transform.localScale *= 1.30f;
            Player.instance.maxHealth *= 1.75f;
            Player.instance.healthBar.SetMaxHealth(Player.instance.maxHealth);
            Player.instance.healthBar.UpdateHealth(Player.instance.maxHealth * (currentHealthPercent / 100));
            Player.instance.playerSpeed *= 0.75f;

        }
        else if (stage == 2)
        {
            Player.instance.transform.localScale *= 1.45f;
            Player.instance.maxHealth *= 2f;
            Player.instance.healthBar.SetMaxHealth(Player.instance.maxHealth);
            Player.instance.healthBar.UpdateHealth(Player.instance.maxHealth * (currentHealthPercent/100));
            Player.instance.playerSpeed *= 0.75f;
        }
        Debug.Log("size played");
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

        Debug.Log("Razor played");
    }

    public void Regen(int stage)
    {
        if (stage == 0)
        {

        }
        else if (stage == 1)
        {
;
        }
        else if (stage == 2)
        {

        }

        Debug.Log("Regn played");
    }

}
