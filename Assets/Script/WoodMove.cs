using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WoodMove : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "saw")
        {

            Destroy(gameObject);
            UnityEngine.Debug.Log("Hello!");

        }
    }
   
}
