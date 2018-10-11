using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBullets : MonoBehaviour
{
    public GameObject Owner;
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject != Owner)
            {

            Destroy(gameObject);

            }
        
        

    }

}
