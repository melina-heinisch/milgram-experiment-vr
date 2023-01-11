using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonAnimation : MonoBehaviour
{
    public float speed;
    public bool buttonIsPressed;
    public float maxY;
    public float minY;

    private bool touchedByHand;
   

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        if (gameObject.transform.position.y < minY)
        {
            Vector3 vector3 = transform.position;
            vector3.y = minY;
            transform.position = vector3;
        }
        if (transform.position.y >= maxY)
        {
            buttonIsPressed = false;
            Vector3 vector3 = transform.position;
            vector3.y = maxY;
            transform.position = vector3;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            buttonIsPressed = true;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        
        if (!touchedByHand)
        {
            Vector3 vector3 = transform.position;
            vector3.y += speed * Time.deltaTime;
            transform.position = vector3;
        }
    }



    //private void OnCollisionStay(Collision collisionInfo)
    //{
    //    if (collisionInfo.gameObject.name.Contains("Hand"))
    //    {
    //        touchedByHand = true;            
    //    }
    //}

    //private void OnCollisionExit()
    //{
    //    touchedByHand = false;
    //    Debug.Log("Not touched anymore");
    //    gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    //}
}
