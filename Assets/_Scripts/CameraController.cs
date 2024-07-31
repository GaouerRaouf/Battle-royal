using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Look senstivity")]
    public float sensX;
    public float sensY;

    [Header("Clamp")]
    public float minY;
    public float maxY;

    [Header("Spectator")]
    private bool isSpectator = false;
    private float rotX, rotY;
    public float spectatorMoveSpeed;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rotX += Input.GetAxis("Mouse X") * sensX;
        rotY += Input.GetAxis("Mouse Y") * sensY;

        Mathf.Clamp(rotY, minY, maxY);

        if (isSpectator)
        {
            transform.rotation = Quaternion.Euler(-rotY, rotX, 0);


            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float y = 0;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                y = 1;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                y = -1;
            }


            Vector3 dir = transform.right * x + transform.up * y + transform.forward * z;
            transform.position += dir * spectatorMoveSpeed * Time.deltaTime;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(-rotY, 0, 0);

            transform.parent.rotation = Quaternion.Euler(0, rotX, 0);
        }

    }
}
