using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schieberegler : MonoBehaviour
{
    public float minZ;
    public float maxZ;

    private float lastSliderZ = -9999;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (gameObject.transform.position.z < minZ)
        {
            Vector3 vector3 = transform.position;
            vector3.z = minZ;
            transform.position = vector3;
        }
        else if (transform.position.z > maxZ)
        {
            Vector3 vector3 = transform.position;
            vector3.z = maxZ;
            transform.position = vector3;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Trigger with {other}");
        if (!other.name.Contains("Hand"))
        {
            Debug.Log($"{other}, {other.transform.position}");
            lastSliderZ = other.gameObject.transform.position.z;

        }
    }

    //will be triggered when Controler is no longer touching slider
    private void OnCollisionExit(Collision collision)
    {
        ReleaseSlider();
    }

    public void ReleaseSlider()
    {
        if (lastSliderZ != -9999)
        {
            Vector3 vector3 = transform.position;
            vector3.z = lastSliderZ;
            transform.position = vector3;
            Debug.Log($"Slider released. new position {vector3}");

        }
    }

    public void MoveSchieberegler()
    {

    }

    public void GetOffset(Transform transform)
    {
        //offsetZ = transform.position.z - transform.position.z;
    }
}
