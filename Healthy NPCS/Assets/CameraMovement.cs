using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float rotX;
    private float rotY;
    void Update()
    {
        rotX += Input.GetAxis("Mouse X") * 3f;
        rotY += Input.GetAxis("Mouse Y") * 1f;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;
        if (Input.GetKey(KeyCode.E))
            y = 1;
        else if (Input.GetKey(KeyCode.Q))
            y = -1;
        Vector3 dir = transform.right * x + transform.up * y + transform.forward * z;
        transform.position += dir * 5f * Time.deltaTime;

        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Euler(-rotY, rotX, 0);
        }
    }
}
