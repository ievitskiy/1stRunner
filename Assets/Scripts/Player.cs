using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode jump;
    
    [SerializeField] private int speed;
    [SerializeField] int jumpforce;

    bool cubeIsOnGround = true;

    public GameManager gm;


    private Rigidbody cube;
    void Awake()
    {
        cube = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(up))
            cube.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey(down))
            cube.AddForce(-speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey(right))
            cube.AddForce(0, 0, -speed * Time.deltaTime, ForceMode.VelocityChange);
        if (Input.GetKey(left))
            cube.AddForce(0, 0, speed * Time.deltaTime, ForceMode.VelocityChange);

        if (Input.GetKey(jump) && cubeIsOnGround)
        {
            cube.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            cubeIsOnGround = false;
        }


        if (transform.position.y < -10)
            gm.EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
            speed += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
            cubeIsOnGround = true;

        if (collision.collider.tag == "wall")
        {
            gm.EndGame();
        }
    }
}
