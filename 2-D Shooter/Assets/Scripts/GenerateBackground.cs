using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{
    [SerializeField] private Transform backgroundImage;
    private List<Transform> backgroundSprites;

    void Start()
    {
        //for(int i = 0; i < 9; i++)
       
        backgroundSprites.Add(Instantiate<Transform>(backgroundImage, Player.instance.transform.position + new Vector3(0, 0, 1), Quaternion.identity));
       // backgroundSprites.Add(Instantiate<Sprite>(backgroundImage, Player.instance.transform.position + backgroundImage., Quaternion.identity));
        //backgroundSprites.Add(Instantiate<Sprite>(backgroundImage, Player.instance.transform.position, Quaternion.identity));
        //backgroundSprites.Add(Instantiate<Sprite>(backgroundImage, Player.instance.transform.position, Quaternion.identity));
        //backgroundSprites.Add(Instantiate<Sprite>(backgroundImage, Player.instance.transform.position, Quaternion.identity));
    }

    
    void Update()
    {
        
    }
}
