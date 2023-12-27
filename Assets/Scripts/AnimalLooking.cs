using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLooking : MonoBehaviour
{
    private Transform target;

    private void Awake()
    {
        target = GameManager.instance.idlePosition;
    }
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }   
    }

    private void OnMouseUp()
    {
        target = null;
    }
}
