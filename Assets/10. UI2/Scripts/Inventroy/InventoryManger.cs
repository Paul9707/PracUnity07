using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManger : MonoBehaviour
{
    public static InventoryManger Instance { get; private set; }

    private void Awake()
    {
            Instance = this;
    }

    public RectTransform equipPage;
    public RectTransform inventoryContent;

    public int inventorySlotCount; // ������ ���� ����
    public InventorySlot InventorySlotPrefab; // ���� ������
    private List<InventorySlot> inventorySlots = new(); // ���� ����Ʈ

    [Space(20)]
    public InventorySlot focusedSlot;
    public InventorySlot selectedSlot;

    public List<Weapon> tempWeapons;
    public List<Item> tempItems;

    private void Start()
    {
        // tempItems ����Ʈ�� tempWeapons ��ҵ��� 0�� �ε������� ����
        tempItems.InsertRange(0, tempWeapons);
        for (int i = 0; i < tempItems.Count; i++)
        {
            // �ӽ� �������� inventory ���� ���Կ� �Ѱ��� �Ҵ�.
            inventoryContent.GetChild(i).GetComponent<InventorySlot>().Item = tempItems[i];   
        }
    }
}


[Serializable]
public class Item
{
    public Sprite iconSprite; // ������ ������
    public string name; // ������ �̸� 
    public string desc; // ������ ����
}

[Serializable]
public class Weapon : Item 
{
    public float damage; // ������
    public GameObject equipPrefab; // ����� ������ ������ ��� ������
}
