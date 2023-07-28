using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCam : MonoBehaviour
{
    public Transform target;

    private Vector3 _Position;

    public float SpeedCamForward = 5;
    public float SpeedCamRotation = 5;


    void Start()
    {
        _Position = target.InverseTransformPoint(transform.position);
    }

    void FixedUpdate()
    {
        Vector3 currentPosition = target.TransformPoint(_Position);

        transform.position = Vector3.Lerp(transform.position, currentPosition, SpeedCamForward * Time.deltaTime);

        var currentRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, SpeedCamRotation * Time.deltaTime);
    }
}
