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

        xRotate = Mathf.Clamp(xRotate, -20, 35); // 위, 아래 고정
        yRotate = Mathf.Clamp(yRotate, -80, 80); // 좌, 우 고정

        cam.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        #endregion
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z + 1.4f);

        cam.transform.position = playerPos; 

    }

    IEnumerator CameraShake()
    {
        float tick = 0;

        while (true)
        {
            
            tick += Time.deltaTime * s_roughness;
            cam.transform.localPosition = new Vector3(
                Mathf.PerlinNoise(tick, 0) - .5f,
                Mathf.PerlinNoise(0, tick) - .5f,
                0) * s_magnitude; 
            yield return null;


        }
    }
}
