using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{
    [SerializeField] private Transform backgroundImage;

    private const float maxViewDistance = 10;
    int chunckSize;
    int chuncksVisibleInViewDist;

    private Dictionary<Vector2, Transform> backgroundSprites = new Dictionary<Vector2, Transform>();

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
        int currentChunckCoordX = Mathf.RoundToInt(Player.instance.transform.position.x / chunckSize);
        int currentChunckCoordY = Mathf.RoundToInt(Player.instance.transform.position.y / chunckSize);

        for(int yOffset = -chuncksVisibleInViewDist; yOffset <= chuncksVisibleInViewDist; yOffset++)
        {
            for(int xOffset = -chuncksVisibleInViewDist; xOffset <= chuncksVisibleInViewDist; xOffset++)
            {
                Vector2 viewedChunckCoord = new Vector2(currentChunckCoordX + xOffset, currentChunckCoordY + yOffset);

                if(backgroundSprites.ContainsKey(viewedChunckCoord))
                {
                    //
                }
                else
                {
                    Transform back = Instantiate<Transform>(backgroundImage, viewedChunckCoord * chunckSize, Quaternion.identity); // got the 10 throught triel and error
                    backgroundSprites.Add(viewedChunckCoord, back);
                }
            }
        }
    }
}
