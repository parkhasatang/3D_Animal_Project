using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingPad : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Transform animalSpawnPosition;
    public float animalFirePower = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject animal = Instantiate(animalPrefabs[0], animalSpawnPosition.position, animalSpawnPosition.rotation);
            animal.GetComponent<Rigidbody>().velocity = animalSpawnPosition.forward * animalFirePower;
            Debug.Log(animal.GetComponent<Rigidbody>().velocity);
            Debug.Log(animalSpawnPosition.forward);
        }
    }
}
