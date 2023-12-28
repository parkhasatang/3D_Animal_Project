using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    private Rigidbody rb;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FreezeAnimal") || collision.gameObject.CompareTag("Floor"))
        {
            if (rb != null)
            {
                animator.SetBool("IsCollision", true);
                gameObject.tag = "FreezeAnimal";
                Invoke("DisableRigidBody", 0.1f); // Todo : CutLine로직 여기서 처리하게 해주고 Invoke를 지워줘야한다.
                GameManager.instance.score++;
                GameManager.instance.launchingPad.SpawnAnimal();
            }
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            UiManager.instance.AnimalHitGround();
            GameManager.instance.launchingPad.SpawnAnimal();
            Invoke("DestroyObject", 0.1f);
        }
    }
    private void DisableRigidBody()
    {
        Destroy(rb);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
