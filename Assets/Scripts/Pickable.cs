using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] GameObject tempParent;
    public Transform guide;
    bool carrying;
    [SerializeField] float range = 5;

    // Start is called before the first frame update
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(carrying == false)
        {
            if(Input.GetKeyDown(KeyCode.Space) && (guide.transform.position - transform.position).sqrMagnitude < range / range)
            {
                pickup();
                carrying = true;
            }
        }
        else if(carrying == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                drop();
                carrying = false;
                //Add Where the player would place the item for the bridge
            }
        }
    }

    void pickup()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }

    void drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }
}
