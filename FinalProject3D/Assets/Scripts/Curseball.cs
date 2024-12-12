using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curseball : MonoBehaviour
{

    public Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            transform.position = startPosition;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
