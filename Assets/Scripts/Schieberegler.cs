using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schieberegler : MonoBehaviour
{
    Quaternion originalRotation;
    float originalX;
    float originalY;
    float offsetZ;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
        originalX = transform.position.x;
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = originalRotation;
        Vector3 position = new Vector3(originalX, originalY, transform.position.z);
        transform.position = position;
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    public void MoveSchieberegler()
    {

    }

    public void GetOffset(Transform transform)
    {
        offsetZ = transform.position.z - transform.position.z;
    }
}
