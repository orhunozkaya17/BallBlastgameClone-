using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    public float screenWitdht;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        screenWitdht = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

    }
    
}
