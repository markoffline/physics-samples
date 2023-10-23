using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CentripetalPull : MonoBehaviour
{
    public Transform point;
    public float strength;

    float distance;

    Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        Vector3 direction = (point.position - transform.position);
        distance = direction.magnitude;
        direction.Normalize();

        Vector3 referenceVector = Vector3.up;
        Vector3 perp = Vector3.Cross(direction, referenceVector);
        rbody.velocity = perp * Mathf.Sqrt(strength * distance);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = -(point.position - transform.position);

        direction.Normalize();

        if (Input.GetMouseButton(0))
        {
            rbody.AddForce(direction * rbody.mass * (strength * 2));
        }
    }

    // Ran every physics update
    void FixedUpdate()
    {
        Vector3 direction = (point.position - transform.position);
        direction.Normalize();

        rbody.AddForce(direction * strength * rbody.mass);
    }
}
