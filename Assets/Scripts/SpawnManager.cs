using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefabs;
    [SerializeField] float xSpawnRange = 20;
    [SerializeField] float zSpawnPosition = 20;

    void Start()
    {
        InvokeRepeating("SpawnAnimal", 1.5f, 2f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SpawnAnimal();        
    }

    void SpawnAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animalPrefab = animalPrefabs[animalIndex];
        Vector3 pos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), 0, zSpawnPosition);
        Instantiate(animalPrefab, pos, animalPrefab.transform.rotation);
    }
}
