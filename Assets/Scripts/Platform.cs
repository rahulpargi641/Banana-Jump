using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject banana, bananaS;
    [SerializeField] Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newBanana = null;
        if(Random.Range(0, 10) > 3)
        {
            newBanana = Instantiate(banana, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            newBanana = Instantiate(bananaS, spawnPoint.position, Quaternion.identity);
        }
        newBanana.transform.parent = transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
