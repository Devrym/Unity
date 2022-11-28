using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private List<Transform> _enemySpawns;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawn in _enemySpawns)
        {
            Instantiate(_sphere, spawn.position, Quaternion.identity);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
