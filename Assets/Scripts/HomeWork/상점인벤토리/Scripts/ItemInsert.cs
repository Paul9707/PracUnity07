using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInsert : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    public Transform ItemParent;
    private int itemCount = 0;

    public void Additem()
    {
        var item = new GameObject("Item_" + itemCount.ToString("D2"));
        itemCount++;
        item.transform.SetParent(ItemParent);
        item.AddComponent<Image>();
        var itemButton = item.AddComponent<Button>();
        itemButton.onClick.AddListener(() => RemoveItem(item));
        items.Add(item);
    }

    private void RemoveItem(GameObject item)
    {
        items.Remove(item);
        Destroy(item);
    }
}
