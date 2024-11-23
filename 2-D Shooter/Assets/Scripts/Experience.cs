using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{

    private int exp = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player.instance.gameObject)
        {
            ExpBar.UpdateExp(exp);
            Destroy(this.gameObject);
        }
    }
}
