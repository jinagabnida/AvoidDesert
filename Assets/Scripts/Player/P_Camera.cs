using System.Collections;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    private float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 500.0f;
    [Space]
    public float s_roughness;
    public float s_magnitude;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
        StartCoroutine("CameraShake");
    }

    // Update is called once per frame
    void Update()
    {
        #region 카메라 움직임
        xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

        yRotate = yRotate + yRotateMove;
        xRotate = xRotate + xRotateMove;

        xRotate = Mathf.Clamp(xRotate, -30, 45); // 위, 아래 고정
        yRotate = Mathf.Clamp(yRotate, -80, 80); // 좌, 우 고정

        cam.transform.localEulerAngles = new Vector3(xRotate, yRotate, 0);
        #endregion

        if (P_Manager.health <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    IEnumerator CameraShake()
    {
        float tick = 0;
        float cameraDown = 0;
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z + 1.4f);
        while (true)
        {
            
            tick += Time.deltaTime * s_roughness;
            if (Input.GetKey(KeyCode.S))
            {
                cameraDown = 0.4f;
            }
            cam.transform.localPosition = new Vector3(
                Mathf.PerlinNoise(tick, 0) - .5f,
                playerPos.y-cameraDown+Mathf.PerlinNoise(0, tick) - .5f, 
                0) * s_magnitude; 
            yield return null;


        }
    }
}
