using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private GameObject spawnCubes;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, _playerMovement.transform.position);
        if (distanceToPlayer<=5f)
        {
            ProcessCubeBehavior();
        }
    }

    private void ProcessCubeBehavior()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(spawnCubes, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
