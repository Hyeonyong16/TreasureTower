using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed;


    private Transform cameraTransform;


    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        Vector3 cameraDir = new Vector3(-v, h, 0);

        mouseX += h * rotateSpeed * Time.deltaTime;
        mouseY += v * rotateSpeed * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -90, 90);

        cameraTransform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}
