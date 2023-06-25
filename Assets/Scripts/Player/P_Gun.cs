using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Gun : MonoBehaviour
{
    public GameObject gun;
    public GameObject fireEffect;
    public GameObject bullet;
    public GameObject ammoText;
    public Transform muzzlePos;
    public Text ammoZero;
    public Animator anim;
    int maxAmmo = 6;
    public static int remainAmmo;
    public float attackDelay = 0.1f;
    public float reloadTime=1f;
    public bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        remainAmmo = 6;
        ammoText.active = false;
        isShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0)&&!isShot && remainAmmo>0)
        {
            isShot = true;
            StartCoroutine("ShotGun");
        }

        if (Input.GetKeyDown(KeyCode.R)&&!isShot)
        {
            StartCoroutine("Reload");
        }
        if (remainAmmo <= 0)
        {
            ammoText.active = true;
            
        }
        else if (remainAmmo > 0)
        {
            ammoText.active = false;
        }


    }

    


    IEnumerator ShotGun()
    {
        remainAmmo--;
        anim.SetTrigger("isShot");
        Instantiate(fireEffect, new Vector3(muzzlePos.position.x,muzzlePos.position.y,muzzlePos.position.z), gun.transform.rotation);
        Instantiate(bullet, new Vector3(muzzlePos.position.x,muzzlePos.position.y,muzzlePos.position.z), gun.transform.rotation);
        yield return new WaitForSeconds(attackDelay);
        isShot = false;
        yield return null;
    }

    IEnumerator Reload()
    {
        anim.SetTrigger("isReload");
        remainAmmo = maxAmmo;
        yield return null;
    }

}
