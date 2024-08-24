using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemTpye type;

    public float rate; // ���� �� ������

    public void Init(ItemData data)
    {
        // Basic Set
        name = "Gear" + data.itemId;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero; // �÷��̾��� ��ġ�� �����.

        // Property Set
        type = data.itemTpye;
        rate = data.damages[0];

        ApplyGear();

    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyGear();
    }

    void ApplyGear()
    {
        switch (type)
        {
            case ItemData.ItemTpye.Glove:
                RateUp();
                break;

            case ItemData.ItemTpye.Shoe:
                SpeedUp();
                break;
        }
    }

    // ���ݼӵ� ����
    void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach (Weapon weapon in weapons)
        {
            switch(weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * rate);
                    break;
                
                // ���Ÿ� ����
                default:
                    weapon.speed = 0.5f * (1f - rate);
                    break;
            }
        }
    }

    // �̵��ӵ� ����
    void SpeedUp()
    {
        float speed = 3;
        GameManager.instance.player.speed = speed + speed * rate;
    }

}
