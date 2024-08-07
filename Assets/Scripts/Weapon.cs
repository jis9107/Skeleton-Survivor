using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;


    private void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150; // �ð� �����̱� ������ -
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch() // ��ġ
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.parent = transform;
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity Per.
        }
    }
}
