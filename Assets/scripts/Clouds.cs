using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [System.Serializable]
    class Cloud
    {
        public MeshRenderer meshRenderer = null;
        public float speed = 0.0f;
        [HideInInspector] public Vector2 offset;
        [HideInInspector] public Material mat;
    }
    [SerializeField] Cloud[] allclouds;
    int count;
    private void Start()
    {
        count = allclouds.Length;
        for (int i = 0; i < count; i++)
        {
            allclouds[i].offset = Vector2.zero;
            allclouds[i].mat = allclouds[i].meshRenderer.material;
        }
    }

    private void Update()
    {
        for (int i = 0; i < count; i++)
        {
            allclouds[i].offset.x += allclouds[i].speed * Time.deltaTime;
            allclouds[i].mat.mainTextureOffset = allclouds[i].offset;
        }
    }
}
