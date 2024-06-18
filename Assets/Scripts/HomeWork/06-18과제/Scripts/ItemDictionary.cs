using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ItemDictionary : MonoBehaviour
{
    public Text text;
    public List<ItemData> itemDatas;
    public Transform imageParent;
    public Transform TextParent;
    public Sprite[] image;
    public GameObject textModel;
    public GameObject itemModel;
    private void Start()
    {
        foreach (ItemData data in itemDatas)
        {
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            string json = File.ReadAllText(path);
            ItemData loadedData = JsonUtility.FromJson<ItemData>(json);

            StringBuilder sb = new StringBuilder();

            sb.Append("이름: ");
            sb.AppendLine(loadedData.name);

            sb.Append("설명: ");
            sb.AppendLine(loadedData.description);

            sb.Append("가격: ");
            sb.Append(loadedData.price);
            sb.AppendLine();

            sb.Append("갯수: ");
            sb.Append(loadedData.count);
            sb.AppendLine();

            var newItem = Instantiate(itemModel);
            newItem.transform.SetParent(imageParent);
            newItem.name = loadedData.name;
            newItem.GetComponent<Image>().sprite = image[loadedData.id];
            var newText = Instantiate(textModel);
            newText.transform.SetParent(TextParent);
            newText.name = loadedData.name;
            newText.GetComponent<Text>().text = sb.ToString();
        }
    }

    public void Save()
    {
        foreach (ItemData data in itemDatas)
        {
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }
    }
}

[Serializable]
public class ItemData
{
    public string name;
    public int id;
    public string description;
    public int price;
    public int count;
}
