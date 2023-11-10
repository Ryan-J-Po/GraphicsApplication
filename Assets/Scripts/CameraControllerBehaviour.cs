using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("The variable controls how fast the camera moves.")]
    private float _speed;

    [SerializeField, Tooltip("The variable that controls how sensitive the mouse movement is for rotating the camera.")]
    private float _mouseSensitivity;


    // Update is called once per frame
    void Update()
    {
        //Move the camera on X,Y,Z axes.
        transform.position += transform.forward * Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        //If Right-Mouse button is being held down...
        if (Input.GetMouseButton(1))
        {
            //...Rotate the camera based on the mouse movement.
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.eulerAngles += new Vector3(-mouseY * _mouseSensitivity, mouseX * _mouseSensitivity, 0);
        }
        
    }
}
