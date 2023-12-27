using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            if (rb != null)
            {
                Destroy(rb);
            }
        }
    }
}
