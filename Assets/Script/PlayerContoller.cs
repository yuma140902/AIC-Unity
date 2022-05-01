using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    public GameObject Camera;

    float pitch;

    // Start is called before the first frame update
    void Start()
    {
        pitch = Camera.transform.localRotation.eulerAngles.x;
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

        float mouseVertical = Input.GetAxis("Mouse Y");
        pitch += -mouseVertical * RotationSpeed;

        Camera.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
