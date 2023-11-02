using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private ParticleColorBehaviour _explosion;

    [SerializeField]
    private int _playerID;

    private void OnDisable()
    {
        ParticleColorBehaviour explosion = Instantiate(_explosion, transform.position, transform.rotation);
        explosion.PlayerID = _playerID;
    }
}
