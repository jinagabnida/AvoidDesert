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
    public float s_duration;
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


    }

    IEnumerator CameraShake()
    {


        float halfDuration = s_duration / 2;
        float elapsed = 0f;
        float tick = 0;

        while (elapsed < s_duration)
        {
            elapsed += Time.deltaTime / halfDuration;

            tick += Time.deltaTime * s_roughness;
            cam.transform.position = new Vector3(
                player.position.x + Mathf.PerlinNoise(tick, 0) - .5f,
                player.position.y + Mathf.PerlinNoise(0, tick) - .5f,
                player.position.z) * s_magnitude * Mathf.PingPong(elapsed, halfDuration);
            yield return null;


        }
    }
}
