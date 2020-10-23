using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public float shipFollowSensitivity;
    private Vector2 rotation;
    public GameObject ShipBody;

    private void Start()
    {
        //transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector2(rotation.x, rotation.y) * mouseSensitivity;

        ShipBody.transform.rotation = Quaternion.Slerp(ShipBody.transform.rotation, transform.rotation, shipFollowSensitivity * Time.deltaTime) ;
    }
}
