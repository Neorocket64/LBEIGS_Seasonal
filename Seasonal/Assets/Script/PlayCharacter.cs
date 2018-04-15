using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayChara : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected int direction = 1;
    private bool isJump;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] protected float jumpPower = 1f;
    [SerializeField] private PlayerController control;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isJump = false;
    }

    void Update()
    {
        float moveDir = Input.GetAxis(control.horizontalKey);
        rb2d.velocity = new Vector2(moveDir * moveSpeed, rb2d.velocity.y);
        if (moveDir >= 1f)
        {
            direction = 1;
        }
        else if (moveDir <= -1f)
        {
            direction = -1;
        }
        if (Input.GetKeyDown(control.jumpKey)&&isJump==false)
        {
            isJump = true;
            Jump();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Ground":
                isJump = false;
                break;
        }
    }
    protected abstract void Jump();
}
