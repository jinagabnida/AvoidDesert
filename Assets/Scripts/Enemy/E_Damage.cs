using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Damage : MonoBehaviour
{
    public int damage;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            P_Manager.Damge(damage);
        }
    }
}
