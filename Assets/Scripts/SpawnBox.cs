using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField] GameObject boxPrefab;
    private Vector3 spawnPos = new Vector3(-13.88f, 1.2f, 0.59f);
    [SerializeField] bool spawn = false;
    private GameObject destinationScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn == false)
        {
            Spawn();
            spawn = true;
        }
    }

    void Spawn()
    {
        GameObject box = Instantiate(boxPrefab, spawnPos, transform.rotation);
        Rigidbody rb = box.GetComponent<Rigidbody>();
    }
}
