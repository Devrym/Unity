using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Transform[] point;
    [SerializeField] private int index;


    void Start()
    {
        _meshAgent.destination = point[index].position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, point[index].position);
        if (distance < 0.5f)
        {
            index += 1;
            if (index > point.Length - 1)
            {
                index = 0;
            }
            _meshAgent.destination = point[index].position;
        }


    }
}
