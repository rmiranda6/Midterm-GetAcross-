using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed = 40;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);        
    }
}
