
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class aItem : MonoBehaviour
{
    enum ItemType1
    {
        Weapon,
        ETC
    }
    enum ItemType2
    {
        Expandable,
        Equipment
    }

    private ItemType1 itemType1;
    private ItemType2 itemType2;

    private Image itemImage;

    public Image arrowImage;
    public Image axeImage;
    public Image cloakImage;
    public Image coinImage;
    List<aItem> Items = new List<aItem>();
    List<GameObject> items = new List<GameObject>();
    public Transform ItemParent;
    private int itemCount = 0;
    public void Start()
    {
        aItem arrow = new aItem();
        arrow.itemImage = arrowImage;
        arrow.itemType1 = ItemType1.Weapon;
        arrow.itemType2 = ItemType2.Expandable;

        Items.Add(arrow);

        aItem axe = new aItem();
        axe.itemImage = axeImage;
        axe.itemType1 = ItemType1.Weapon;
        axe.itemType2 = ItemType2.Equipment;

        Items.Add(axe);

        aItem cloak = new aItem();
        cloak.itemImage = cloakImage;
        cloak.itemType1 = ItemType1.ETC;
        cloak.itemType2 = ItemType2.Equipment;

        Items.Add(cloak);

        aItem coin = new aItem();
        coin.itemImage = coinImage;
        coin.itemType1 = ItemType1.ETC;
        coin.itemType2 = ItemType2.Expandable;

        Items.Add(coin);

    }

    public void WeaponButtonClick()
    {
        List<aItem> weapon = Items.FindAll(item => item.itemType1 == ItemType1.Weapon);

        Items.ForEach(item => item.itemImage.color = new Color(1.0f, 1.0f, 1.0f, 0.5f));
        foreach (aItem item in weapon)
        {
            Color itemColor = item.itemImage.color;
            itemColor.a = 1.0f;
            item.itemImage.color = itemColor;
        }
    }
    public void ETCButtonClick()
    {
        List<aItem> etc = Items.FindAll(item => item.itemType1 == ItemType1.ETC);

        Items.ForEach(item => item.itemImage.color = new Color(1.0f, 1.0f, 1.0f, 0.5f));
        foreach (aItem item in etc)
        {
            Color itemColor = item.itemImage.color;
            itemColor.a = 1.0f;
            item.itemImage.color = itemColor;
        }
    }
    public void EquipmentButtonClick()
    {
        List<aItem> equipment = Items.FindAll(item => item.itemType2 == ItemType2.Equipment);

        Items.ForEach(item => item.itemImage.color = new Color(1.0f, 1.0f, 1.0f, 0.5f));
        foreach (aItem item in equipment)
        {
            Color itemColor = item.itemImage.color;
            itemColor.a = 1.0f;
            item.itemImage.color = itemColor;
        }
    }
    public void ExpandableButtonClick()
    {
        List<aItem> expandable = Items.FindAll(item => item.itemType2 == ItemType2.Expandable);

        Items.ForEach(item => item.itemImage.color = new Color(1.0f, 1.0f, 1.0f, 0.5f));
        foreach (aItem item in expandable)
        {
            Color itemColor = item.itemImage.color;
            itemColor.a = 1.0f;
            item.itemImage.color = itemColor;
        }
    }

    public void Additem()
    {
        var randomIndex = Random.Range(0, Items.Count);
        var item = Items[randomIndex];

        var newItem = new GameObject("Item_" + itemCount.ToString("D2"));
        itemCount++;
        newItem.transform.SetParent(ItemParent);
        newItem.AddComponent<Image>().sprite = item.itemImage.sprite;
        var itemButton = newItem.AddComponent<Button>();
        itemButton.onClick.AddListener(() => RemoveItem(newItem));
        items.Add(newItem);
    }

    private void RemoveItem(GameObject item)
    {
        items.Remove(item);
        Destroy(item);
    }
}
