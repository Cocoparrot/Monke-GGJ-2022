using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    public float sensitivity = 5;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            CameraMovement();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void CameraMovement()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensitivity;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
