using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Schieberegler : MonoBehaviour
{
    public float minZ;
    public float maxZ;

    public int value;

    private float lastSliderZ;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        //Debug.Log(transform.position);
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
        //Debug.Log($"Trigger with {other}");
        if (!other.name.Contains("Hand"))
        {
            //Debug.Log($"{other}, {other.transform.position}");
            lastSliderZ = other.gameObject.transform.position.z;

            //get value from name
            string string_value = Regex.Replace(other.name, "[^0-9.]", "");
            try
            {
                value = int.Parse(string_value);
            }
            catch (System.FormatException)
            {
                //do nothing
            }
        }
    }

    //will be triggered when Controler is no longer touching slider
    private void OnCollisionExit(Collision collision)
    {
        ReleaseSlider();
    }

    private void ReleaseSlider()
    {
        //make new position
        Vector3 vector3 = transform.position;
        vector3.z = lastSliderZ;
        transform.position = vector3;
        //Debug.Log($"Slider released. new position {vector3}");


    }

}
