using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0,0,-10);
    private float dampTime = 0.25f;
    private Vector3 currentVelocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.instance.transform.position + offset, ref currentVelocity, dampTime);
    }
}
