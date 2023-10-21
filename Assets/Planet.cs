using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    Rigidbody rbody;

    public float explosionPower = 100;
    public float explosionRadius = 100;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rbody.AddExplosionForce(explosionPower, transform.position, explosionRadius);
        }
    }
}
