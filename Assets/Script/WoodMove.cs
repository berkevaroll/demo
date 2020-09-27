using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class WoodMove : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 contactPoint;
    private float distance;
    private Vector3 big_scale;
    private Vector3 small_scale;
    private Vector3 big_pos;
    private Vector3 small_pos;
    public GameObject bigPiece;
    public GameObject smallPiece;
    private GameObject myCamera;
    private GameObject newBig;
    private GameObject newSmall;
    private Vector3 originPosition;
    private Quaternion originRotation;
    public float shake_decay = 0.001f;
    public float shake_intensity = .002f;

    private float temp_shake_intensity = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        newBig = null;
        newSmall = null;
        myCamera = GameObject.Find("Main Camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "saw")
        {
            rb.velocity = rb.velocity / 4;
            Shake();
            
        }
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
                distance = transform.position.z - contactPoint.z;
                big_scale.y = Math.Abs(distance) + transform.localScale.y / 2;
                big_scale.x = transform.localScale.x;
                big_scale.z = transform.localScale.z;
                small_scale.y = transform.localScale.y - big_scale.y;
                small_scale.x = transform.localScale.x;
                small_scale.z = transform.localScale.z;
                big_pos.z = (distance >= 0) ? contactPoint.z + big_scale.y   : contactPoint.z - big_scale.y;
                big_pos.y = transform.position.y;
                big_pos.x = transform.position.x*4/3 ;
                small_pos.z = (distance >=0) ? contactPoint.z - small_scale.y : contactPoint.z + small_scale.y ;
                small_pos.y = transform.position.y;
                small_pos.x = transform.position.x*4/3;
                Destroy(gameObject);
                newBig = Instantiate(bigPiece, big_pos, transform.rotation);
                newSmall = Instantiate(smallPiece, small_pos, transform.rotation);
                newBig.transform.localScale = big_scale;
                //newBig.GetComponent<Rigidbody>().velocity = rb.velocity/2;
                newSmall.transform.localScale = small_scale;
                //newSmall.GetComponent<Rigidbody>().velocity = rb.velocity/2;
                myCamera.transform.position = originPosition;
                myCamera.transform.rotation = originRotation;
            }
            else
            {
                UnityEngine.Debug.Log("Oyun Bitti!");
            }
        }
    }
    private void Update()
    {
        if (temp_shake_intensity > 0)
        {
            myCamera.transform.position = originPosition + UnityEngine.Random.insideUnitSphere * temp_shake_intensity;
            myCamera.transform.rotation = new Quaternion(
                originRotation.x + UnityEngine.Random.Range(-temp_shake_intensity, temp_shake_intensity) * .02f,
                originRotation.y + UnityEngine.Random.Range(-temp_shake_intensity, temp_shake_intensity) * .02f,
                originRotation.z + UnityEngine.Random.Range(-temp_shake_intensity, temp_shake_intensity) * .02f,
                originRotation.w + UnityEngine.Random.Range(-temp_shake_intensity, temp_shake_intensity) * .02f);
            temp_shake_intensity -= shake_decay;
        }
    }
    void Shake()
    {
        originPosition = myCamera.transform.position;
        originRotation = myCamera.transform.rotation;
        temp_shake_intensity = shake_intensity;

    }
}
