using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    public GameObject Camera;
    public float JumpForce;

    float pitch;
    float yaw;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        pitch = Camera.transform.localRotation.eulerAngles.x;
        yaw = Camera.transform.localRotation.eulerAngles.y;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            this.transform.position += this.transform.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            this.transform.position -= this.transform.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            this.transform.position += this.transform.right * Speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)) {
            this.transform.position -= this.transform.right * Speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * JumpForce * Time.deltaTime, ForceMode.Impulse);
        }

        float mouseVertical = Input.GetAxis("Mouse Y");
        pitch += -mouseVertical * RotationSpeed;
        pitch = Mathf.Clamp(pitch, -90, 90);

        float mouseHorizontal = Input.GetAxis("Mouse X");
        yaw += mouseHorizontal * RotationSpeed;

        Camera.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        this.transform.localRotation = Quaternion.Euler(0, yaw, 0);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
