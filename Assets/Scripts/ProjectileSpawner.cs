using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    // all the available projectiles are stored on this list
    [SerializeField] private List<GameObject> projectiles;
    // a singleton instance
    public static ProjectileSpawner instance;
    //parent of all the pooled gameobjects
    private GameObject activeProjectile;

    private void Awake()
    {
        // creating singleton instance
        if(instance!= null && instance != this)
        {
            Destroy(instance);
        }
        else instance = this;
    }
    
    private void Start()
    {
        // disabling every projectile
        foreach(GameObject projectile in projectiles)
        {
            projectile.SetActive(false);
        }
        //spwning one random projectile
        SpawnProjectile();
    }
    //this method is used to spawn a random projectile
    public void SpawnProjectile()
    {
        int number= Random.Range(0,projectiles.Count);
        activeProjectile = projectiles[number];
        activeProjectile.SetActive(true);
    }
    // this method will trigger the projectile
    public void LaunchProjectile()
    {
        activeProjectile.GetComponent<Projectile>().TriggerProjectile();
    }
    
}
