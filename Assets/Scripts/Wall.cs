using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public LaunchingPad launchingPad;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            Destroy(collision.gameObject);
            launchingPad.SpawnAnimal();
        }
    }
}
