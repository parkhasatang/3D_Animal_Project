using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingPad : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Transform animalSpawnPosition;

    private SlingShot slingShot;

    public Transform currentAnimalTransform;

    private void Awake()
    {
        slingShot = GetComponent<SlingShot>();
    }

    private void Start()
    {
        SpawnAnimal();
    }

    public void SpawnAnimal()
    {
        currentAnimalTransform = Instantiate(animalPrefabs[0], animalSpawnPosition.position, animalSpawnPosition.rotation).transform;
        slingShot.isMouseDown = true;
    }

    public void StripRefresh()
    {
        slingShot.Refresh();
    }
}
