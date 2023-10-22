using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gravity : MonoBehaviour
{
    public Transform point;
    public float strength;

    Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
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
