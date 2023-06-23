using UnityEngine;

public class P_Move : MonoBehaviour
{
    public Rigidbody rb;
    public Transform HorseTr;
    public BoxCollider bCol;
    float h_RotateY = 0;
    float h_RotateZ = 0;
    public float jumpPower;
    public float speed;
    public float maxSpeed;
    public bool isJump;
    public bool isSukE;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region 점프
        if (Input.GetKeyDown(KeyCode.Space) && !isJump && !isSukE)
        {
            isJump = true;
            anim.SetTrigger("isJump");
            rb.AddForce(new Vector3(rb.velocity.x, jumpPower, rb.velocity.z), ForceMode.Impulse);
        }
        #endregion

        #region 좌,우 움직임
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            h_RotateY = 0;
            h_RotateZ = 0;
            HorseTr.localRotation = Quaternion.Euler(0, h_RotateY, h_RotateZ);
        }

        if (Input.GetKey(KeyCode.A))
        {

            rb.AddForce(new Vector3(0, 0, -speed*Time.deltaTime), ForceMode.Force);
            h_RotateY -= 1.5f;
            h_RotateZ += 1f;
            if (h_RotateY < -15 || h_RotateY > 10)
            {
                h_RotateY = -15;
                h_RotateZ = 10;
            }
            HorseTr.localRotation = Quaternion.Euler(0, h_RotateY, h_RotateZ);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, 0, speed * Time.deltaTime), ForceMode.Force);
            h_RotateY += 1.5f;
            h_RotateZ -= 1f;
            if (h_RotateY > 15 || h_RotateY < -10)
            {
                h_RotateY = 15;
                h_RotateZ = -10;
            }
            HorseTr.localRotation = Quaternion.Euler(0, h_RotateY, h_RotateZ);
        }


        if (rb.velocity.z > maxSpeed)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, maxSpeed);
        }
        else if (rb.velocity.z < -maxSpeed)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, -maxSpeed);
        }
        #endregion

        #region 숙이기
        if (Input.GetKey(KeyCode.S) && !isJump)
        {

            if (!isSukE)
                HorseTr.localPosition = new Vector3(0, -1.65f, 0);
            isSukE = true;
            bCol.size = new Vector3(bCol.size.x, 1, bCol.size.z);
            
        }
        else if(Input.GetKeyUp(KeyCode.S) && !isJump)
        {
            bCol.size = new Vector3(bCol.size.x, 1.5f, bCol.size.z);// 이거 Y좌표값 바꿔서 말은 안내려가게하기
            HorseTr.localPosition = new Vector3(0,  -2, 0);
            isSukE = false;
        }
        #endregion

    }




    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isJump = false;
        }
    }private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isJump = false;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isJump = true;
        }
    }
}
