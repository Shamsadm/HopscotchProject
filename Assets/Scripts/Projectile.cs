using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Speed of the projectile
    [SerializeField] private float speed;
    //Damage radius of the projectile
    [SerializeField] private float DamageRadius;
    // explosion amount of the projectile
    [SerializeField] private float explosionPower;
    [SerializeField] private ParticleSystem explosion;
    //rigidbody refernce of the projectile
    private Rigidbody rb;


//start position of the projectile
    private Vector3 startPosition;
    //start rotation
    private Quaternion startRotation;
    // array of colliders 
    private Collider[] inRangeColliders;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        startPosition=transform.position;
        startRotation= transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,startPosition)>40)
        {
            DestroyProjectile();
        }
        // controlling projectile according to the user input
        ControllProjectile(InputManager.instance.movement);

    }
    public void TriggerProjectile()
    {
       
        
        rb.AddForce(transform.up*speed,ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        //collecting all the colliders in range when the projectile met a collision
        inRangeColliders = Physics.OverlapSphere(transform.position,DamageRadius);
        foreach(Collider collider in inRangeColliders)
        {
            if(collider.attachedRigidbody!= null)
            {
                // adding explosive force according to the projectile specification
                collider.attachedRigidbody.AddExplosionForce(explosionPower,transform.position,DamageRadius,5,ForceMode.Impulse);
            }
        }
        DestroyProjectile();
        
       
    }
    //This method is used to Reset the projectile .in every projectile destroying situations , this method can be called
    private void DestroyProjectile()
    {
        explosion.transform.position = transform.position;
        explosion.Play();
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
        transform.position = startPosition;
        transform.rotation=startRotation;
        ProjectileSpawner.instance.SpawnProjectile();
        
    }
    // this method is used to controll the prjectile rotation. so that player can launch projectile accroding to his will
    private void ControllProjectile(Vector2 _axis)
    {
        transform.Rotate(new Vector3(_axis.y,0,_axis.x));
    }
}
