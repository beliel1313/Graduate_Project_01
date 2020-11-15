using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCCtrl : MonoBehaviour {
    private Rigidbody2D m_rg;
    public float MoveSpeed;
    private Animator pcAnimator;

    // Use this for initialization
    void Awake () {
        m_rg = gameObject.GetComponent<Rigidbody2D>();
        pcAnimator = gameObject.GetComponent<Animator>();
    }

    public void SetEnable()
    {
        this.enabled = true;
    }

	// Update is called once per frame
	void Update () {
        // 水平移動
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            m_rg.velocity = new Vector2(MoveSpeed, m_rg.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
            pcAnimator.SetBool("isWalking", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            m_rg.velocity = new Vector2(-MoveSpeed, m_rg.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
            pcAnimator.SetBool("isWalking", true);
        }
        else
        {
            m_rg.velocity = new Vector2(0, m_rg.velocity.y);
        }
        // 垂直移動
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            m_rg.velocity = new Vector2(m_rg.velocity.x, MoveSpeed);
            pcAnimator.SetBool("isWalking", true);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            m_rg.velocity = new Vector2(m_rg.velocity.x, -MoveSpeed);
            pcAnimator.SetBool("isWalking", true);
        }
        else
        {
            m_rg.velocity = new Vector2(m_rg.velocity.x, 0);
        }
        // 完全靜止
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) 
        {
            pcAnimator.SetBool("isWalking", false);
        }
    }


}
