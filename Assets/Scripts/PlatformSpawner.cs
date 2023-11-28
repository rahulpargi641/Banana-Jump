using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject leftPlatform, rightPlatform;
    [SerializeField] Transform platformParent;
    [SerializeField] private GameObject bird;

    public float birdY = 5f;
    private float birdXMin = -2.3f, birdXMax = 2.3f;

    public static PlatformSpawner instance;

    float leftXMin = -4.4f, leftXMax = -2.8f, rightXMin = 4.4f, rightXMax = 2.8f;
    float yTreshold = 2.6f; // Height difference between two platforms
    float lastY;

    public int spawnCount = 8; // How many platforms per spawns
    int spawnedPlatforms;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        lastY = transform.position.y;
        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        Vector2 temp = transform.position;
        GameObject newPlatform = null;

        for (int i = 0; i < spawnCount; i++)
        {
            temp.y = lastY;
            if ((spawnedPlatforms % 2) == 0)
            {
                temp.x = Random.Range(leftXMin, leftXMax);
                newPlatform = Instantiate(rightPlatform, temp, Quaternion.identity);
            }
            else
            {
                temp.x = Random.Range(rightXMin, rightXMax);
                newPlatform = Instantiate(leftPlatform, temp, Quaternion.identity);
            }

            newPlatform.transform.parent = platformParent;

            lastY += yTreshold;
            spawnedPlatforms++;


            if(Random.Range(0 , 2) > 0 )
            {
                SpawnBird();
            }
        }
    }

    void SpawnBird()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(birdXMin, birdXMax);
        temp.y += birdY;

        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);
        newBird.transform.parent = platformParent;
    }
}


// Create Score System
// Change input for android