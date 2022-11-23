using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody enemy = other.gameObject.GetComponent<Rigidbody>();
        enemy.AddForce(Vector3.back * Time.deltaTime * 100f, ForceMode.Impulse);
        gameObject.SetActive(false);
        other.gameObject.SetActive(false);
    }


}
