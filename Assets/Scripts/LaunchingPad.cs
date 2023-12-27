using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingPad : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Transform animalSpawnPosition;
    public float animalFirePower = 0;

    private SlingShot slingShot;

    public Transform currentAnimalTransform;

    private void Awake()
    {
        slingShot = GetComponent<SlingShot>();
    }

    private void Update()
    {
        GenerateAnimal();
    }

    public void SpawnAnimal()
    {
        currentAnimalTransform = Instantiate(animalPrefabs[0], animalSpawnPosition.position, animalSpawnPosition.rotation).transform;
        slingShot.isMouseDown = true;
    }

    private void GenerateAnimal()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentAnimalTransform = Instantiate(animalPrefabs[0], animalSpawnPosition.position, animalSpawnPosition.rotation).transform;
            slingShot.isMouseDown = true;
            /*animal.GetComponent<Rigidbody>().velocity = animalSpawnPosition.forward * animalFirePower;
            Debug.Log(animal.GetComponent<Rigidbody>().velocity);
            Debug.Log(animalSpawnPosition.forward);*/
        }
    }
}
