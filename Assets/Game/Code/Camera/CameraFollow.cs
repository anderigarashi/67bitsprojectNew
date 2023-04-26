using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    void Start()
    {
        var objPlayer = GameObject.FindGameObjectWithTag("Player");
        target = objPlayer.transform;
    }
    void Update()
    {
        transform.position = target.position + offset;
    }
}
