using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSides : MonoBehaviour
{
    [SerializeField] BoxCollider2D leftWallCollider;
    [SerializeField] BoxCollider2D rightWallCollider;

    private void Start()
    {
        float screenWidth = Game.Instance.screenWitdht;
        leftWallCollider.transform.position = new Vector3(-screenWidth -leftWallCollider.size.x/2f, 0, 0);
        rightWallCollider.transform.position = new Vector3(+screenWidth + rightWallCollider.size.x/2f, 0, 0);
        Destroy(this);
    }
}
