using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Experimental.GlobalIllumination;
using System;

public class Schieberegler : MonoBehaviour
{
    public float minZ;
    public float maxZ;

    [SerializeField] private GameObject light_40;
    [SerializeField] private GameObject light_60;
    [SerializeField] private GameObject light_80;
    [SerializeField] private GameObject light_100;
    [SerializeField] private GameObject light_120;
    [SerializeField] private GameObject light_140;
    [SerializeField] private GameObject light_160;
    [SerializeField] private GameObject light_180;
    [SerializeField] private GameObject light_200;
    [SerializeField] private GameObject light_220;

    private Dictionary<int, GameObject> lights = new Dictionary<int, GameObject>();

    public int value;
    private float lastSliderZ;

    // Start is called before the first frame update
    void Start()
    {
        lights.Add(1, light_40);
        lights.Add(2, light_60);
        lights.Add(3, light_80);
        lights.Add(4, light_100);
        lights.Add(5, light_120);
        lights.Add(6, light_140);
        lights.Add(7, light_160);
        lights.Add(8, light_180);
        lights.Add(9, light_200);
        lights.Add(10, light_220);

        lastSliderZ = transform.position.z;
    }

    // Update is called once per frame
    private void Update()
    {
        DontMoveBeyondMax();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.name.Contains("Hand"))
        {
            lastSliderZ = other.gameObject.transform.position.z;

            string string_value = Regex.Replace(other.name, "[^0-9.]", "");
            try
            {
                value = int.Parse(string_value);

                GameObject light;

                // Set all Lights up until current one active
                for (int i = 1; i <= value; i++)
                {
                    Debug.Log(i + " Light on");
                    if (lights.TryGetValue(i, out light) && !light.activeSelf)
                    {
                        Debug.Log("Turned on");
                        light.SetActive(true);

                    }
                }
                // Set all lights after current one disabled
                for (int i = 10; i > value; i--)
                {
                    Debug.Log(i + " Light off");
                    if (lights.TryGetValue(i, out light) && light.activeSelf)
                    {
                        Debug.Log("Turned off");
                        light.SetActive(false);

                    }
                }
            }
            catch (System.FormatException)
            {
                //do nothing
            }
        }
    }

    private void DontMoveBeyondMax()
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

    //will be triggered when Controler is no longer touching slider
    private void OnCollisionExit(Collision collision)
    {
        ReleaseSlider();
    }

    private void ReleaseSlider()
    {
        Vector3 vector3 = transform.position;
        vector3.z = lastSliderZ;
        transform.position = vector3;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
