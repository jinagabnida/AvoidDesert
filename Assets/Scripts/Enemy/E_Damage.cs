using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Damage : MonoBehaviour
{
    public int damage;
    public float speed = 13;

    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            P_Manager.Damge(damage);
        }
    }
}
