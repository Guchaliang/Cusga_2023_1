using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private float speed = 1f;
    Vector3 moveDir;
    private float rotSpeed = -5f;

    private float rotateSpeed = 30f;
    private float movespeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        moveDir = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        //con1();

        //con2();

        con3();

        //transform.Rotate(Vector3.forward, speed * Time.deltaTime );
    }

    void con1()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //通过a,d键控制了旋转,而且相对是平滑的
        transform.Rotate(0,0,h* rotSpeed * Time.deltaTime);
        //通过验证，发现zAngle一直是0，说明这不是我要的值
        //Debug.Log("zAngle:"+ zAngle);

        //transform.rotation = Quaternion.Euler(0, 0, h*Time.deltaTime*speed);

        //现在的一个核心问题是：如何能让Z旋转角能够平滑的旋转，但是不用Rotate函数
        Debug.Log(transform.rotation.eulerAngles);
        moveDir = transform.rotation.eulerAngles;

        //dir2D.x * moveSpeed*Time.deltaTime,dir2D.y * moveSpeed*Time.deltaTime, 0
        //transform.position += moveDir * v * Time.deltaTime * speed;
        //transform.position += new Vector3(moveDir.z * v * Time.deltaTime * speed, moveDir.z * v * Time.deltaTime * speed, 0);
    }

    void con2()
    {
        if (Input.GetKey(KeyCode.W)) //前进
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) //后退
        {
            transform.Translate(Vector3.back * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))//向左旋转
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))//向右旋转
　　     {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }

    void con3()
    {
        if (Input.GetKey(KeyCode.W)) //前进
        {
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) //后退
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))//向左旋转
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))//向右旋转
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }
    }
}
