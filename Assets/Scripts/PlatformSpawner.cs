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

    public static PlatformSpawner instance;

    float leftXMin = -4.4f, leftXMax = -2.8f, rightXMin = 4.4f, rightXMax = 2.8f;
    float yTreshold = 2.6f; // Height difference between two platforms
    float lastY;

    public int spawnCount = 8; // How many platforms per spawns
    int spawnedPlatforms;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
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

        for (int i=0;i<spawnCount;i++)
        {
            temp.y = lastY;
            if((spawnedPlatforms % 2) == 0)
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
