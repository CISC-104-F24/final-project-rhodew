using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;


public class FleshCube : MonoBehaviour
{

    Rigidbody fleshRigidbody;

    public Vector3 startingPosition = new Vector3(0f,1.1f, 0f);


    bool isAPressed;
    bool isWPressed;
    bool isSPressed;
    bool isDPressed;
    bool isSpacePressed;
    bool isPlayerJumping = false;

    public float moveSpeed = 1.0f;
    public float jumpPower = 1.0f;
    
    Vector3 Forward = new Vector3(0f, 0f, 1f);
    Vector3 Backward = new Vector3(0f, 0f, -1f);
    Vector3 Right = new Vector3(1f, 0f, 0f);
    Vector3 Left = new Vector3(-1f, 0f, 0f);
    Vector3 Up = new Vector3(0f, 1f, 0f);

    float mudSpeed;

    public int Orbs;
    public int neededOrbs = 1;
    public int Life;
    public int maxLife;

    public TextMeshProUGUI OrbsNumber;
    public TextMeshProUGUI OrbsNeededNumber;
    public TextMeshProUGUI FleshNumber;
    public TextMeshProUGUI LevelName;
    // Start is called before the first frame update
    void Start()
    {
        Life = maxLife;
        transform.position = startingPosition;
        Orbs = 0;
        mudSpeed = 1.0f;
        OrbsNumber.text = Orbs.ToString();
        OrbsNeededNumber.text = neededOrbs.ToString();
        FleshNumber.text = Life.ToString();
        Scene currentScene = SceneManager.GetActiveScene();
        LevelName.text = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDirection = new Vector3(0f, 0f, 0f);
        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isSPressed = Input.GetKey(KeyCode.S);
        bool isDPressed = Input.GetKey(KeyCode.D);
        bool isAPressed = Input.GetKey(KeyCode.A);
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

        transform.position = transform.position + moveSpeed * MoveDirection * mudSpeed * Time.deltaTime;

        if (isSpacePressed == true && isPlayerJumping == false)
        {
        
                Rigidbody fleshRigidbody = GetComponent<Rigidbody>();
                fleshRigidbody.AddForce(Up * jumpPower, ForceMode.Impulse);
                isPlayerJumping = true;
            }      


            transform.rotation = Quaternion.Euler(0f, 0f, 0f);



        if (Life < 1)
        {
            SceneManager.LoadScene(6);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            transform.position = startingPosition;
            Life = Life - 1;
            FleshNumber.text = Life.ToString();
        }
        if(collision.gameObject.CompareTag("Gate"))
        {
        if(Orbs >= neededOrbs)
            {
                Destroy(collision.gameObject);
            }
        }
        if(collision.gameObject.CompareTag("Fragile"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mud"))
        {
            mudSpeed = 0.5f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            {
            isPlayerJumping = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isPlayerJumping = true;
        }
        if (collision.gameObject.CompareTag("Mud"))
        {
            mudSpeed = 1.0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Orb"))
        {
            Destroy(other.gameObject);
            Orbs = Orbs + 1;
            OrbsNumber.text = Orbs.ToString();
        }
        if(other.gameObject.CompareTag("Portal"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }
}
