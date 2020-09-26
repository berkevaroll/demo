using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnWoods : MonoBehaviour
{


    public GameObject woodPrefab;
       
    void Start()
    {
        InvokeRepeating("SetSpawner", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetSpawner()
    {
        Vector3 pos = transform.position;
        Vector3 scale = woodPrefab.transform.localScale;
        scale.y = Random.Range(.7f, 2f);
        scale.z = Random.Range(1f, 3f);
        scale.x = scale.z;
        pos.z += Random.Range(5f - scale.z, -5f + scale.z);
        var newWood =Instantiate(woodPrefab, pos,transform.rotation);
        newWood.transform.localScale = scale;
        
    }
}
