using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform lookTarget;
    private Transform posTarget;
    private float follow; // distance behind the target
    private float lift; // distance above the target
    private float smooth;
    private Vector3 offset;

    void Start() {
        lookTarget = GameObject.FindWithTag("Player").transform;
        posTarget = GameObject.FindWithTag("CamPos").transform;
    }

    void LateUpdate() {
        // -1 0 10
        // -1 3 -7.5
        //Vector3 pos = lookTarget.position + Vector3.up*2f - lookTarget.forward*5f;
        transform.position = Vector3.Lerp(transform.position, posTarget.position, Time.deltaTime*3f);
        //transform.position = posTarget.position;
        //transform.position = pos;        
        transform.LookAt(lookTarget.position + Vector3.up*3f);
    }
}
