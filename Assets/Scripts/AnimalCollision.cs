using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    private Rigidbody rb;
    /*private Collider myCollider;*/

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        /*myCollider = GetComponent<Collider>();*/
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FreezeAnimal") || collision.gameObject.CompareTag("Floor"))
        {
            if (rb != null)
            {
                animator.SetBool("IsCollision", true);
                Destroy(rb);
                /*myCollider.enabled = false;*/
                gameObject.tag = "FreezeAnimal";
                /*myCollider.enabled = true;*/
                GameManager.instance.launchingPad.SpawnAnimal();
            }
        }
    }
}
