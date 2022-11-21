using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullet_hole;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
        
        
        
    }

    
    //


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
