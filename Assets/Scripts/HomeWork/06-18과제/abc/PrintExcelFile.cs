using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintExcelFile : MonoBehaviour
{
   public Item_01 item_01;

    private void Start()
    {
        for (int i = 0; i < item_01.Sheet1.Count; i++)
        {
            Debug.Log(item_01.Sheet1[i].ID);
            Debug.Log(item_01.Sheet1[i].Name);
            Debug.Log(item_01.Sheet1[i].price);
            Debug.Log(item_01.Sheet1[i].description);
        }
    }
    
}
