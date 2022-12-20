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

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] public float speed;
    private Vector3 _normal;
    void Update()
    {

        Vector3 pos = _rigidbody.position;
        if (pos.y < -10)
        {
            _rigidbody.transform.position = new Vector3(0, 1, 2);
        }
    }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
            speed += 1;
        }
    }
}
