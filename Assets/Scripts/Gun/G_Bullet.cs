using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Bullet : MonoBehaviour
{
    public GameObject attackEffect;
    public float destroyTime;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(attackEffect, this.transform);
            Destroy(gameObject);
        }
    }
}
