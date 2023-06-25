using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Manager : MonoBehaviour
{
    public static float health=100;
    public static float score;
    public GameObject pannel;
    public Text scoreTxt;
    void Start()
    {
        health = 100;
        score = 0;
        pannel.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            pannel.active = true;
            scoreTxt.text = "SCORE : " + score;
        }
        else
        {
            score++;
        }
    }
    public static void Damge(int dmg)
    {
        health -= dmg;
        Debug.Log(health);
    }
}
