using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public int MaxMagCapacity = 30;
    private int CurrentMagCapacity; //if this hits zero, we won't be able to fire any more.

    public float MaxShootDelay;
    public float ShootDelay;

    public GameObject BulletPrefab; //bullet to spawn
    public Transform BulletSpawn; // location of bullet spawn

    //public Transform Shootpoint;


    float DT; //is usually private

   


    public void Fire()
    {
        if(CurrentMagCapacity > 0 && ShootDelay <= 0)
        {
            Debug.Log("Bam"); //instantiate bullet
            //launch bullet in direction
            //GameObject TempBullet = Instantiate(BulletPrefab, ShootPoint);
            //TempBullet.GetComponent<Rigidbody>().velocity = ShootPoint.forward * bulletLaunchVelocity;

            ShootDelay = MaxShootDelay; //reset it so it fires again.
            CurrentMagCapacity--; //to make it so the gun runs out of ammo.
        }
        else if(CurrentMagCapacity <= 0)
        {
            Debug.Log("Empty");
        }

        var Bullet = (GameObject)Instantiate(BulletPrefab,BulletSpawn.position,BulletSpawn.rotation);

        Bullet.GetComponent<MoreBullets>().Owner = gameObject;

        Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * 6;

        Destroy(Bullet, 2.0f);
    }

    // Use this for initialization
    void Start ()
    {
        CurrentMagCapacity = MaxMagCapacity; //set this at the start so it will load the maximum # of bullets
        

	}

    void UpdateInput()
    {
     

    }


    // Update is called once per frame
    void Update ()
    {
        DT = Time.deltaTime;
        ShootDelay -= DT; //shoot delay will minus itself by time

        // UpdateInput();


     

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

    }
}
