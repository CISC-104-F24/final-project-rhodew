using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine.UIElements;


public class FleshCube : MonoBehaviour
{

    Rigidbody fleshRigidbody;

    public Vector3 startingPosition = new Vector3(0f,1.1f, 0f);

    bool isAPressed;
    bool isWPressed;
    bool isSPressed;
    bool isDPressed;
    bool isSpacePressed;
    bool isFPressed;

    public float moveSpeed = 1.0f;
    public float jumpPower = 1.0f;
    
    Vector3 Forward = new Vector3(0f, 0f, 1f);
    Vector3 Backward = new Vector3(0f, 0f, -1f);
    Vector3 Right = new Vector3(1f, 0f, 0f);
    Vector3 Left = new Vector3(-1f, 0f, 0f);
    Vector3 Up = new Vector3(0f, 1f, 0f);

    int Orbs;
    public int neededOrbs = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPosition;
        Orbs = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDirection = new Vector3(0f, 0f, 0f);
        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isSPressed = Input.GetKey(KeyCode.S);
        bool isDPressed = Input.GetKey(KeyCode.D);
        bool isAPressed = Input.GetKey(KeyCode.A);
        bool isFPressed = Input.GetKey(KeyCode.F);
        bool isSpacePressed = Input.GetKeyDown(KeyCode.Space);

        if (isWPressed == true)
        {
            MoveDirection = MoveDirection + Forward;
        }
        if (isSPressed == true)
        {
            MoveDirection = MoveDirection + Backward;
        }
        if (isDPressed == true)
        {
            MoveDirection = MoveDirection + Right;
        }
        if (isAPressed == true)
        {
            MoveDirection = MoveDirection + Left;
        }

        transform.position = transform.position + moveSpeed * MoveDirection * Time.deltaTime;

        if (isSpacePressed == true)
        {
                Rigidbody fleshRigidbody = GetComponent<Rigidbody>();
            fleshRigidbody.AddForce(Up * jumpPower, ForceMode.Impulse);
        }



        if (isFPressed == true)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }







    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            transform.position = startingPosition;
        }
        if(collision.gameObject.CompareTag("Gate"))
        {
        if(Orbs >= neededOrbs)
            {
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Orb"))
        {
            Destroy(other.gameObject);
            Orbs = Orbs + 1;
        }
    }
}
