using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private Rigidbody2D rig;   //刚体
    private float horizontal;  //水平偏移量
    private float move; //水平移动速度（左 或 右）
    [Header("MoveValue")]
    public float moveSpeed = 5.5f; //水平移动速度绝对值
    public float jumpForce = 300f;  //跳跃的力


    void Start() {
        rig = GetComponent<Rigidbody2D>();   //获取主角刚体组件

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {    //如果按下空格 
            rig.AddForce(new Vector2(0, jumpForce));   //给刚体一个向上的力
            horizontal = Input.GetAxis("Horizontal");   //水平方向按键偏移量
            move = horizontal * moveSpeed;   //刚体具体速度
            rig.velocity = new Vector2(move, rig.velocity.y);
        }

        if (Input.GetButton("Horizontal")) {
            horizontal = Input.GetAxis("Horizontal");
            move = horizontal * moveSpeed;   //刚体具体速度
            rig.velocity = new Vector2(move, rig.velocity.y);
        }

    }
}