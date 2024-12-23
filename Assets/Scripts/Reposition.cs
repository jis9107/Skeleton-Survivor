using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{

    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision) // 플레이어의 움직임에 따라 4개로 나눠진 맵이 이동하여 무한 맵을 생성한다
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;



        switch(transform.tag)
        {
            case "Ground":
                float diffX = playerPos.x - myPos.x;
                float diffY = playerPos.y - myPos.y;

                float dirX = diffX < 0 ? -1 : 1;
                float dirY = diffY < 0 ? -1 : 1;

                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);

                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }

                break;

            case "Enemy":
                if(col.enabled)
                {
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);

                    transform.Translate(ran + dist * 2);
                }
                break;
        }
    }
}
