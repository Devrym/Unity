using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DefaultNamespace;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullet_hole;
    [SerializeField] private Transform _player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UnityEngine.Color color = UnityEngine.Color.blue;
        RaycastHit hit;
        var startPos = transform.position;
        startPos.y += 0.5f;
        var dir = _player.position - startPos;
        //dir.y += 1.5f;
        var rayCast = Physics.Raycast(startPos, dir, out hit, Mathf.Infinity);
        if (rayCast)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                color = UnityEngine.Color.green;
            }
            else
            {
                color = UnityEngine.Color.red;
            }
        }
        Debug.DrawRay(startPos, dir, color);

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameObject bullet_ins = Instantiate(bullet, bullet_hole.position, Quaternion.identity);
            Bullet b = bullet_ins.GetComponent<Bullet>();
            b.SetEnemy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        transform.LookAt(other.gameObject.transform);
        

    }
}
