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
    [SerializeField] private float lookSpeed = 5f;

    [SerializeField] private ChunkPlacer ChunkFirst;
    
    public void Move(Vector3 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction.x * _rigidbody.transform.forward*Time.deltaTime*speed  /*+direction*speed*Time.deltaTime*/);
    }

    public void Rotate(Vector3 direction)
    {
        _rigidbody.MoveRotation(_rigidbody.rotation *Quaternion.Euler(direction*lookSpeed));
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
