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
        //canvas�� ��ǥ��� �÷��̾��� ��ǥ�谡 �ٸ��� ������ ī�޶� �̿�
        //WorldToScreenPoint() => ���� ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ���ִ� �Լ� (�ݴ뵵 ����)
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
    }
}
