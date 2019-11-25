﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public GameObject indicator;
    private bool hasPizza;
    public int score;

    // Start is called before the first frame update
    void Start() {
        hasPizza = false;
        score = 0;
    }

    void FixedUpdate() {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        foreach (AxleInfo axle in axleInfos) {
            if (axle.steering) {
                axle.leftWheel.steerAngle = steering;
                axle.rightWheel.steerAngle = steering;
            }
            if (axle.motor) {
                axle.leftWheel.motorTorque = motor;
                axle.rightWheel.motorTorque = motor;
            }
        }
        orientWheels();
    }

    // Update is called once per frame
    void Update() {
        indicator.SetActive(hasPizza);
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Pizza")) {
            hasPizza = true;
            Destroy(other.gameObject);
            return;
        }

        if (other.gameObject.CompareTag("Destination")) {
            if (hasPizza) {
                Destroy(other.gameObject);
                hasPizza = false;
                score++;
                return;
            }
        }
    }

    private void orientWheels() {
        foreach (AxleInfo axle in axleInfos) {
            setWheelOrientation(axle.leftWheel);
            setWheelOrientation(axle.rightWheel);
        }
    }

    private void setWheelOrientation(WheelCollider wheel) {
        if (wheel.transform.childCount == 0) {
            return;
        }

        Transform mesh = wheel.transform.GetChild(0);

        Vector3 pos;
        Quaternion rot;
        Quaternion q = new Quaternion(0, 0, 0, 1);
        wheel.GetWorldPose(out pos, out rot);

        mesh.transform.position = pos;
        mesh.transform.rotation = rot;// * q;
        mesh.transform.Rotate(new Vector3(0, 0, 90));
    }
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}