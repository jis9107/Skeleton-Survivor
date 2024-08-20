using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //canvas의 좌표계와 플레이어의 좌표계가 다르기 때문에 카메라 이용
        //WorldToScreenPoint() => 월드 상의 좌표를 스크린 좌표로 변환해주는 함수 (반대도 가능)
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
    }
}
