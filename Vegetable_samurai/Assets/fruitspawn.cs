using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitspawn : MonoBehaviour
{
    public GameObject fruit;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f ;

    void Start()
    {
        StartCoroutine(spawnFruits());    
    }
     IEnumerator spawnFruits ()
        {
            while(true)
            {
                float delay= Random.Range(minDelay,maxDelay);   
                yield return new WaitForSeconds(1f);

                int spawnIndex=Random.Range(0,spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];
                GameObject Spawnedfruit=Instantiate(fruit,spawnPoint.position, spawnPoint.rotation);
                Destroy(Spawnedfruit,5f);
            }
        }
   

    
}
