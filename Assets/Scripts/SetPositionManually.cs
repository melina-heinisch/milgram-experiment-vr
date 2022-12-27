using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionManually : MonoBehaviour
{
    enum Positions
    {
        manual,
        teacherScreen
    }

    [SerializeField] private bool setPositionManually;
    [SerializeField] private Positions position;
    [SerializeField] private Vector3 positionV3;
    [SerializeField] private int rotation;

    private Vector3 teacherScreen = new Vector3(0.7f, 1, 1.2f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (setPositionManually)
        {
            Vector3 rotationV3 = gameObject.transform.rotation.eulerAngles;
            switch (position)
            {
                case Positions.manual:
                    gameObject.transform.position = positionV3;
                    rotationV3.y = rotation;
                    break;
                case Positions.teacherScreen:
                    gameObject.transform.position = teacherScreen;
                    rotationV3.y = 90;
                    break;
                default:
                    break;
            }
            gameObject.transform.rotation = Quaternion.Euler(rotationV3);
        }
    }
}
