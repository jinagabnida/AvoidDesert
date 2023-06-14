using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEditorInternal;
using UnityEngine;

public class P_Move : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpPower;
    public bool isJump;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& !isJump)
        {
            isJump = true;
            anim.SetTrigger("isJump");
            rb.AddForce(new Vector3 (rb.velocity.x, jumpPower, rb.velocity.z),ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isJump = false;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isJump = true;
        }
    }
}
