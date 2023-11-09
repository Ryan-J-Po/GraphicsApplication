using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainSceneLight : MonoBehaviour
{
    [SerializeField]
    private Light _mainSceneLight;

    private Material _material;

    private MeshRenderer _meshRenderer;

    private Vector3 _direction;

    private Vector4 _color;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        
        _color = _mainSceneLight.color;
        _material = _meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = _mainSceneLight.transform.forward;
        _material.SetVector("_Light_Direction", _direction);

    }
}
