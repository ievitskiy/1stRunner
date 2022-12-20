using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhysicsMovement : MonoBehaviour
{
    PhotonView view;

    public GameObject Camera;

    public PhysicsMovement scriptPlayerController;

    public KeyboardInput scriptKeyboardInput;

    private void Awake()
    {
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
        {
            Camera.SetActive(false);
            scriptPlayerController.enabled = false;
            scriptKeyboardInput.enabled = false;
        }
    }

    //[Header("Скорость перемещения персонажа")]
    //public float speed = 7f;

    //private void Update()
    //{
    //    GetInput();
    //}

    //private void GetInput()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.localPosition += transform.forward * speed * Time.deltaTime;
    //    }

    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.localPosition += -transform.forward * speed * Time.deltaTime;
    //    }

    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.localPosition += -transform.right * speed * Time.deltaTime;
    //    }

    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.localPosition += transform.right * speed * Time.deltaTime;
    //    }
    //}

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] public float speed;
    private Vector3 _normal;

    private void OnCollisionStay(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }
    public void Move(Vector3 direction)
    {

        Vector3 directionAlongSurface = Vector3.ProjectOnPlane(direction, _normal);
        Vector3 offset = directionAlongSurface * (speed * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

}
