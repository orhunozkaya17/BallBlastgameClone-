using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misslies : MonoBehaviour
{
    Queue<GameObject> missilesQueue;
    [SerializeField] GameObject missilePrefab;
    [SerializeField] int maxMissilesCount;
    
    [Space]
    [SerializeField] float delay=0.3f;
    [SerializeField] float speed=0.3f;

    GameObject g;
    float t = 0f;

    public static Misslies instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        PrepareMissiles();
    }
    private void Update()
    {
        t += Time.deltaTime;
        if (t>delay)
        {
            t = 0;
            g = SpawnMissile(transform.position);
            g.GetComponent<Rigidbody2D>().velocity = Vector2.up* speed;
        }
    }
    void PrepareMissiles()
    {
        missilesQueue = new Queue<GameObject>();
        for (int i = 0; i < maxMissilesCount; i++)
        {
            g = Instantiate(missilePrefab, transform.position, Quaternion.identity,transform);

            g.SetActive(false);

            missilesQueue.Enqueue(g);
        }
    }
    public GameObject SpawnMissile(Vector2 postion)
    {
        if (missilesQueue.Count>0)
        {
            g = missilesQueue.Dequeue();
            g.transform.position = postion;
            g.SetActive(true);
            return g;
        }
        else return null;
    }
    public void DespawnMissile(GameObject g)
    {
        g.SetActive(false);
        missilesQueue.Enqueue(g);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("missile"))
        {
            DespawnMissile(collision.gameObject);
        }
    }
}
