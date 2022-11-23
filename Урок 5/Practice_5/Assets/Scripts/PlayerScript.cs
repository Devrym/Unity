using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private bool key;
    [SerializeField] private float speed;
    [SerializeField] private GameObject _mine;
    private Rigidbody player;
    private NavMeshAgent agent;
    public bool grounded = true;
    private Vector3 minePosition;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            minePosition = gameObject.transform.localPosition;
            minePosition.z += 2;
            Instantiate(_mine, minePosition , Quaternion.identity);
        }

        
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

        if (Input.GetKey(KeyCode.Space))
        {
            grounded = false;
            if (agent.enabled)
            {
                
                agent.SetDestination(transform.position);
                agent.updatePosition = false;
                agent.updateRotation = false;
                agent.isStopped = true;
            }
            
            player.isKinematic = false;
            player.useGravity = true;
            player.AddForce(Vector3.up* Time.deltaTime * 100f, ForceMode.Impulse);



        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("BOMB"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //gameObject.SetActive(false);
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
