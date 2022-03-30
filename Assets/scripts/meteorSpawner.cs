using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] meteorPrefab;
    [SerializeField] int meteorsCount;
    [SerializeField] float spawnDelay;

    GameObject[] meteors;
    private void Start()
    {
        prepareMeteors();
        StartCoroutine(SpawnMeteors());
    }
    IEnumerator SpawnMeteors()
    {
        for (int i = 0; i < meteorsCount; i++) {
            yield return new WaitForSeconds(spawnDelay);
            meteors[i].SetActive(true);
           
        }
    }
    void prepareMeteors()
    {
        meteors = new GameObject[meteorPrefab.Length];
        for (int i = 0; i < meteorsCount; i++)
        {
            meteors[i] = Instantiate(meteorPrefab[Random.Range(0, meteorPrefab.Length)], transform);
            meteors[i].SetActive(false);
        }
    }
}
