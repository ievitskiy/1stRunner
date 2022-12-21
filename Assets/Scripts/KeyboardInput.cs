using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");

        _movement.Move(new Vector3(vertical, 0,0));

        float yRot = Input.GetAxisRaw("Mouse X");

        _movement.Rotate(new Vector3(0f, yRot, 0f));
    }
}
