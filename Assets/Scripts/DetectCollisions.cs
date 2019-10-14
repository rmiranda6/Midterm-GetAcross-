using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    Rigidbody rb;
    MoveForward moveForward;
    BoxCollider boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        moveForward = GetComponent<MoveForward>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 2f);

        Vector3 direction = Quaternion.Euler(-20, 0, 0) * -transform.forward;
        rb.AddForce(direction * 20f, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * 15f, ForceMode.Impulse);

        moveForward.enabled = false;
        boxCollider.enabled = false;

        Destroy(other.gameObject);
    }
}
