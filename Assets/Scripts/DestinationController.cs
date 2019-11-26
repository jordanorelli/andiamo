using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationController : MonoBehaviour
{
    public string Address;

    [TextArea(15,20)]
    public string Directions;

    public GameObject visualModel;

    private float period;
    // private float phase;
    private Vector3 startPosition;
    private float startTime;
    
    // Start is called before the first frame update
    void Start() {
        period = 3.0f;
        // phase = 0f;
        startPosition = transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        float elapsedTime = Time.time - startTime;
        float phase = (elapsedTime % period) / period;
        phase = phase * 2.0f * Mathf.PI;
        transform.position = startPosition + (Mathf.Sin(phase) * Vector3.up * 0.5f);
    }

}
