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
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                break;
        }
    }

    public void LevelUp(float damage, int count)
    {

    }

    void Batch() // ���� ��ġ
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.parent = transform;

            Vector3 rotVec = Vector3.forward * 360 * i / count; // ���� ������ ���� ���� ��ȯ
            bullet.Rotate(rotVec); 
            bullet.Translate(bullet.up * 1.5f, Space.World); // �÷��̾� �������� ��ġ

            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is Infinity Per.
        }
    }
}
