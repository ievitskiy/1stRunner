using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] Transform _begin;
    [SerializeField] Transform _end;
    [SerializeField] GameObject _meshCollider;


    public Transform get_begin()
    {
        return _begin;
    }
    public Transform get_end()
    {
        return _end;
    }

    public GameObject get_meshCollider()
    {
        return _meshCollider;
    }

}
