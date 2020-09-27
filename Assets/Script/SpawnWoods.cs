using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnWoods : MonoBehaviour
{

    private static float MIN_WOOD_LENGTH = .7f;
    private static float MAX_WOOD_LENGTH = 2f;

    public GameObject woodPrefab;
    public GameObject cutArea;
    void Start()
    {
        InvokeRepeating("SetSpawner", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetSpawner()
    {

        Vector3 pos = transform.position;
        Vector3 cutPos = pos;
        Vector3 scale = woodPrefab.transform.localScale;
        Vector3 cutScale = cutArea.transform.localScale;
       
        //Scaling objects
        scale.y = Random.Range(MIN_WOOD_LENGTH,MAX_WOOD_LENGTH);
        scale.z = Random.Range(1f, 2f);
        scale.x = scale.z;
        cutScale.y = Random.Range(scale.y / 6f, scale.y/3);
        cutScale.z = scale.z+.01f;
        cutScale.x = scale.x+.01f;
        //Positioning objects
        pos.z += Random.Range(-5f + scale.z, 5f - scale.z);
        cutPos.z = Random.Range(pos.z - scale.z / 2+.3f, pos.z + scale.z / 2-.3f);
        var newWood = Instantiate(woodPrefab, pos,transform.rotation);
        var newCutArea = Instantiate(cutArea, cutPos,transform.rotation);
        newWood.transform.localScale = scale;
        newCutArea.transform.localScale = cutScale;

        newCutArea.transform.parent = newWood.transform;

        
    }
}
