using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonAnimation : MonoBehaviour
{
    public float speed;
    public bool buttonIsPressed;
    public float maxY;
    public float minY;

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    void Update()
    {
        if (gameObject.transform.position.y < minY)
        {
            Vector3 vector3 = transform.position;
            vector3.y = minY;
            transform.position = vector3;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (transform.position.y >= maxY)
        {
            Vector3 vector3 = transform.position;
            vector3.y = maxY;
            transform.position = vector3;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (!buttonIsPressed)
        {
            Vector3 vector3 = transform.position;
            vector3.y += speed * Time.deltaTime;
            transform.position = vector3;
        }
    }



    private void OnCollisionStay(Collision collisionInfo)
    {
        buttonIsPressed = true;
    }

    private void OnCollisionExit()
    {
        buttonIsPressed = false;
    }
}
