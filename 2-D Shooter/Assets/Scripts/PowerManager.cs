using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    [SerializeField] private GameObject powerMenu;

    private void Start()
    {
        Time.timeScale = 1f;
        powerMenu.SetActive(false);
    }
    public void PowerUpsMenu()
    {
        Time.timeScale = 0f;
        powerMenu.SetActive(true);
    }

    public void increaseSpeed()
    {
        Player.instance.playerSpeed *= 1.5f;
        Time.timeScale = 1f;

    }

    public void increaseDamage()
    {
        Bullet.damage *= 2;
        Time.timeScale = 1f;
    }

    public void increaseFireRate()
    {
        GameInput.fireRate += 0.1f;

        Time.timeScale = 1f;
    }
}
