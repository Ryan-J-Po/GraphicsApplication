using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSSpawnerBehaviour : MonoBehaviour
{

    [SerializeField]
    private GameObject _particleSystem;

    Camera _mainCamera;

    private Vector3 _mousePosition;

    // Start is called before the first frame update
    void Awake()
    {
        //Sets the camera being used in the script.
        _mainCamera = Camera.main;
        //Sets the chosen particle system to be toggled 'off' in the scene.
        _particleSystem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Create a variable that acts as a place holder for the mouse's  X and Y positions. 
            Vector3 mouseScreenPosition = Input.mousePosition;
            //Sets variable Z position to be the camera's nearClipPlane plus the OPPOSITE of the camera's Z position.
            mouseScreenPosition.z = _mainCamera.nearClipPlane + 5;

            _mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            _mousePosition.z = _mainCamera.nearClipPlane;

            //Sets the particle system's position to be the mouse position in screen space.
            _particleSystem.transform.position = _mousePosition;
            //Toggled chosen particle system to be toggled 'on' in the scene.
            _particleSystem.SetActive(true);

        }

        if (Input.GetMouseButtonUp(0))
        {
            _particleSystem.SetActive(false);
        }


    }
}
