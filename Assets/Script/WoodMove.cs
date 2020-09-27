﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class WoodMove : MonoBehaviour
{
    private Rigidbody rb;
    private Transform myTransform;
    private Vector3 contactPoint;
    private float distance;
    private Vector3 big_scale;
    private Vector3 small_scale;
    private Vector3 big_pos;
    private Vector3 small_pos;
    public GameObject bigPiece;
    public GameObject smallPiece;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(new Vector3(1, 0, 0) * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.tag == "saw")
        {
            contactPoint = collision.contacts[0].point;
            Transform childTransform = GetComponentInChildren<Transform>();
            UnityEngine.Debug.Log(childTransform.tag + ": " + contactPoint.z);
            if (contactPoint.z < childTransform.position.z + childTransform.localScale.z/2 && contactPoint.z> childTransform.position.z - childTransform.localScale.z / 2)
            {
                UnityEngine.Debug.Log("Girdi!");
                myTransform = null;
                distance = transform.position.z - contactPoint.z;
                big_scale.y = Math.Abs(distance) + transform.localScale.y / 2;
                big_scale.x = transform.localScale.x;
                big_scale.z = transform.localScale.z;
                small_scale.y = transform.localScale.y - big_scale.y;
                small_scale.x = transform.localScale.x;
                small_scale.z = transform.localScale.z;
                big_pos.z = (distance >= 0) ? contactPoint.z + big_scale.y   : contactPoint.z - big_scale.y;
                big_pos.y = transform.position.y;
                big_pos.x = transform.position.x;
                small_pos.z = (distance >=0) ? contactPoint.z - small_scale.y : contactPoint.z + small_scale.y ;
                small_pos.y = transform.position.y;
                small_pos.x = transform.position.x;
                Destroy(gameObject);
                var newBig = Instantiate(bigPiece, big_pos , transform.rotation);
                var newSmall = Instantiate(smallPiece, small_pos, transform.rotation);
                newBig.transform.localScale = big_scale;
                newSmall.transform.localScale = small_scale;   
                
            }
            else
            {
                UnityEngine.Debug.Log("Oyun Bitti!");
            }
        }
    }
    private void Update()
    {
        
    }
    IEnumerator WaitForAFew()
    {
        //Do Something Before the Wait
        yield return new WaitForSeconds(1.0f);
        //Do Something After the Wait
    }

}
