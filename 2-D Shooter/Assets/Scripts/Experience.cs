using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    [SerializeField] private ExpBar expBar;
    private int exp = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player.instance.gameObject)
        {
            expBar.UpdateExp(exp);
            Destroy(this.gameObject);
        }
    }
}
