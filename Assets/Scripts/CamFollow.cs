using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform cube;
    [SerializeField] Vector3 dist;
    void Update()
    {
        transform.position = cube.position - cube.forward*5;
        transform.localPosition += dist;
        //transform.localRotation = cube.rotation;
    }
}
