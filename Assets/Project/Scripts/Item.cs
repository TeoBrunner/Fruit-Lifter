using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }
    public void SetInvisible(bool value)
    {
        rb.isKinematic = value;
        collider.enabled = !value;
    }
    public void Throw(Vector3 force)
    {
        rb.AddForce(force);
    }
}
