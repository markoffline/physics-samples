using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
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

    float GRAVITY_CONST = 6.67f * Mathf.Pow(10.0f, -11.0f);
    private void FixedUpdate()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody r in rigidbodies)
        {
            if (r == rb) continue;


            Vector3 direction = (transform.position - r.gameObject.transform.position);

            float mm = r.mass * rb.mass;
            float r2 = Mathf.Pow(direction.magnitude, 2);
            float G = GRAVITY_CONST * (mm/r2);

            direction.Normalize();
            r.AddForce(direction * G);
            rb.AddForce(-direction * G);
        }
    }
}
