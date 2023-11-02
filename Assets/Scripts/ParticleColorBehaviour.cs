using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorBehaviour : MonoBehaviour
{
    private ParticleSystem _mainSystem;

    [SerializeField]
    private ParticleSystem _subSystem;

    private int _playerID;

    public int PlayerID { get => _playerID; set => _playerID = value; }

    private void Awake()
    {
        _mainSystem = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerID == 1)
        {
            _mainSystem.startColor = Color.cyan;
            _subSystem.startColor = Color.cyan;
        }
        else if (PlayerID == 2)
        {
            _mainSystem.startColor = Color.red;
            _subSystem.startColor = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
