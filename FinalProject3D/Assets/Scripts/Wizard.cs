using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Wizard : MonoBehaviour
{

    int currentPositionNumber;
    Vector3 currentPosition;
    public Vector3 position1 = new Vector3(0f, 0f, 5f);
    public Vector3 position2 = new Vector3(0f, 0f, 6f);
    public Vector3 position3 = new Vector3(0f, 0f, 7f);
    public Vector3 position4 = new Vector3(0f, 0f, 8f);
    public Vector3 position5 = new Vector3(0f, 0f, 9f);

    public int WizzorbLife;
    public TextMeshProUGUI WizzorbHealthNumber;
    // Start is called before the first frame update
    void Start()
    {
        currentPositionNumber = 1;
        currentPosition = position1;
        transform.position = currentPosition;
        WizzorbHealthNumber.text = WizzorbLife.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPositionNumber == 1)
        {
            currentPosition = position1;
        }
        if (currentPositionNumber == 2)
        {
            currentPosition = position2;
        }
        if (currentPositionNumber == 3)
        {
            currentPosition = position3;
        }
        if (currentPositionNumber == 4)
        {
            currentPosition = position4;
        }
        if (currentPositionNumber == 5)
        {
            currentPosition = position5;
        }
        transform.position = currentPosition;

        if (WizzorbLife < 1)
        {
            SceneManager.LoadScene(7);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WizzorbLife = WizzorbLife - 1;
            WizzorbHealthNumber.text = WizzorbLife.ToString();
            currentPositionNumber = Random.Range(1, 6);
        }
    }
}
