using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    private Vector3 _normal;

    private void OnCollisionStay(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }
    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = Vector3.ProjectOnPlane(direction, _normal);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
        //_rigidbody.velocity = direction.normalized * _speed;
        //_rigidbody.AddForce(direction.normalized  * _speed,ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.ProjectOnPlane(transform.forward, _normal) * 3);

    }

}
