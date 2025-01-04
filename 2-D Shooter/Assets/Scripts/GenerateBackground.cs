using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{
    [SerializeField] private Transform backgroundImage;

    private const float maxViewDistance = 15;
    int chunckSize;
    int chuncksVisibleInViewDist;

    private Dictionary<Vector2, Transform> backgroundSprites = new Dictionary<Vector2, Transform>();
    private List<Transform> activeBackgroundsLastRun = new List<Transform>();

    private void Start()
    {
        chunckSize = 10;
        chuncksVisibleInViewDist = Mathf.RoundToInt(maxViewDistance / chunckSize);
    }

    private void Update()
    {
        UpdateVisibleChuck();
    }

    private void UpdateVisibleChuck()
    {
        for(int i = 0; i < activeBackgroundsLastRun.Count; i++)
        {
            activeBackgroundsLastRun[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        activeBackgroundsLastRun.Clear();

        int currentChunckCoordX = Mathf.RoundToInt(Player.instance.transform.position.x / chunckSize);
        int currentChunckCoordY = Mathf.RoundToInt(Player.instance.transform.position.y / chunckSize);

        for(int yOffset = -chuncksVisibleInViewDist; yOffset <= chuncksVisibleInViewDist; yOffset++)
        {
            for(int xOffset = -chuncksVisibleInViewDist; xOffset <= chuncksVisibleInViewDist; xOffset++)
            {
                Vector2 viewedChunckCoord = new Vector2(currentChunckCoordX + xOffset, currentChunckCoordY + yOffset);

                if(backgroundSprites.ContainsKey(viewedChunckCoord))
                {
                    backgroundSprites[viewedChunckCoord].GetComponent<SpriteRenderer>().enabled = true;
                    activeBackgroundsLastRun.Add(backgroundSprites[viewedChunckCoord]);
                }
                else
                {
                    Transform back = Instantiate<Transform>(backgroundImage, viewedChunckCoord * chunckSize, Quaternion.identity); // got the 10 throught triel and error
                    backgroundSprites.Add(viewedChunckCoord, back);
                    activeBackgroundsLastRun.Add(back);
                }
            }
        }
    }
}
