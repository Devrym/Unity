using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private bool key;
    [SerializeField] private float speed;
    
    
    // Start is called before the first frame update
    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward*Time.deltaTime*10f*speed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up*Time.deltaTime*100f);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up*Time.deltaTime*-100f);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.forward*Time.deltaTime*-10f * speed);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("BOMB"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        if (other.tag.Equals("DOOR"))
        {

            Vector3 positionRight = other.gameObject.transform.GetChild(2).position;
            Vector3 positionLeft = other.gameObject.transform.GetChild(3).position;
            positionLeft.x += 4;
            positionRight.x -= 4;
            other.gameObject.transform.GetChild(2).position = positionLeft;
            other.gameObject.transform.GetChild(3).position = positionRight;


        }

        if (other.tag.Equals("SECRET_DOOR"))
        {
            if (key)
            {
                Vector3 positionRight = other.gameObject.transform.GetChild(2).position;
                Vector3 positionLeft = other.gameObject.transform.GetChild(3).position;
                positionLeft.x += 4;
                positionRight.x -= 4;
                other.gameObject.transform.GetChild(2).position = positionLeft;
                other.gameObject.transform.GetChild(3).position = positionRight;
            }

        }

        if (other.tag.Equals("KEY"))
        {
            key = true;
            other.gameObject.SetActive(false);

        }
        
        if (other.tag.Equals("BULLET"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }

        if (other.tag.Equals("HEALTH"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.tag.Equals("AMMO"))
        {
            other.gameObject.SetActive(false);
        }


    }


}
