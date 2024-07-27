using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;

    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; // 속도 제어
        rigid.MovePosition(rigid.position + nextVec);
    }

    //void OnMove(InputValue value)
    //{
    //    inputVec = value.Get<Vector2>(); //Input System에 noramlized를 사용하고 있어 nextVec에 normalized 생략가능 
    //}

    private void LateUpdate() // 업데이트가 끝나고 다음 프레임으로 넘어갈 때 실행된다.
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if(inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
