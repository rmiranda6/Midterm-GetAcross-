using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeBuilder : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject Prefab;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Instantiate(Prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
