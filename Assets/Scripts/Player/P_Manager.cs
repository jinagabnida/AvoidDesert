using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Manager : MonoBehaviour
{
    public static float health=100;
    public static float score;
    void Start()
    {
        health = 100;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Damge(int dmg)
    {
        health -= dmg;
        Debug.Log(health);
    }
}
