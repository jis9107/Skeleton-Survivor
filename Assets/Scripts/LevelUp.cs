using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true); // ��Ȱ��ȭ �Ǿ� �ִ� �������� �ֱ� ������ true
    }

    public void Show()
    {
        Next();
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }

    public void Select(int index)
    {
        items[index].OnClick();
    }

    void Next()
    {
        // 1. ��� ������ ��Ȱ��ȭ
        foreach (Item item in items)
        {
            item.gameObject.SetActive(false);
        }

        // 2. �� �߿��� ���� 3�� ������ Ȱ��ȭ
        int[] random = new int[3];

        while(true)
        {
            random[0] = Random.Range(0, items.Length);
            random[1] = Random.Range(0, items.Length);
            random[2] = Random.Range(0, items.Length);

            // if���� ���� ��� ���� ���� ������ while���� �ݺ��ϰ�, �� �ٸ� ����� while���� �������´�.
            if (random[0] != random[1] && random[1] != random[2] && random[0] != random[2])
                break;
        }

        for (int i = 0; i < random.Length; i++)
        {
            Item randomItem = items[random[i]];

            // 3. ���� �������� ���� �Һ� ���������� ��ü
            if(randomItem.level == randomItem.data.damages.Length )
            {
                items[4].gameObject.SetActive(true);
            }
            else
            {
                randomItem.gameObject.SetActive(true);
            }
        }


    }
}


