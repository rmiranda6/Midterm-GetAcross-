using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] Transform theDest;
    bool carrying = false;
    [SerializeField] float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying == false && (this.transform.position - transform.position).sqrMagnitude < range / range)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().freezeRotation = true;
                this.transform.position = theDest.position;
                this.transform.parent = GameObject.Find("Destination").transform;
                carrying = true;
            }
        }
        else if (carrying == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<Rigidbody>().freezeRotation = false;
                carrying = false;
            }
        }
    }
}
