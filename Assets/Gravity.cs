using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody r in rigidbodies)
        {
            if (r == rb) continue;

            Vector3 direction = (transform.position - r.gameObject.transform.position);
            direction.Normalize();
            r.AddForce(direction * 9.8f * r.mass);
            rb.AddForce(-direction * 9.8f * r.mass);
        }
    }
}
