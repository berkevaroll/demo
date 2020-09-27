using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageDump : MonoBehaviour
{
    private int count = 0;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        count++;
        if (collision.gameObject.tag == "Wood")
        {
            Debug.Log("Odunu kesemedin!!");
        }            
            Destroy(collision.gameObject);
    }
}
