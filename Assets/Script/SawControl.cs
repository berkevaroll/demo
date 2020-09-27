using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControl : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.position += new Vector3(0,0,-.03f);
                
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.transform.position += new Vector3(0, 0, .03f);
        }
    }
}
