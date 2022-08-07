using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HentaiSpawner : MonoBehaviour
{
    //Object for instantiating
    [SerializeField] private GameObject gameObjectToSpawn;
    //Row count of the instatntiated object
    [SerializeField] private float rowCount;
    //colomn count of the instantiated object
    [SerializeField] private float colomnCount;
    //distance between each instantiated object
    [SerializeField] private float distance;

    private Vector3 StartPos;
    
    // Start is called before the first frame update
    void Start()
    {
       // assigning target objects position to allign the instantiated objects
        StartPos = gameObjectToSpawn.transform.position;
        //itrating through rows and col
        for(int i = 0; i<rowCount; i++)
        {
            //every first object in the row is spawning behind and behind
            StartPos = new Vector3(gameObjectToSpawn.transform.position.x,gameObjectToSpawn.transform.position.y,gameObjectToSpawn.transform.position.z-i*distance);
            for(int j=0; j<colomnCount; j++)
            {
                // instantiating the game object
                Instantiate(gameObjectToSpawn,StartPos,Quaternion.identity);
                // every object in colomn will keep x distance away from its nearest 
                StartPos=new Vector3(StartPos.x-distance,StartPos.y,StartPos.z);
                
            }
            
        }
        
        gameObjectToSpawn.SetActive(false);
    }
}
