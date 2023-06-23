using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Move : MonoBehaviour
{
    public Transform MapLine;
    public Transform Player;
    public float speed = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MapLine.position.x >= Player.position.x)
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f); 
        }
        transform.position += transform.right * speed*Time.deltaTime;

    }
}
