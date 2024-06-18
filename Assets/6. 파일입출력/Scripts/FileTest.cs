using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


public class FileTest : MonoBehaviour
{
    public Text text;

    public List<PlayerData> playerDatas;
    public List<PlayerData> readFromJson = new List<PlayerData>();

    private void Start()
    {

        StringBuilder sb = new StringBuilder();

        sb.Append("Data Path: ");
        sb.AppendLine(Application.dataPath);
        sb.Append("Pers data path: ");
        sb.AppendLine(Application.persistentDataPath);
        sb.Append("Str data path: ");
        sb.AppendLine(Application.streamingAssetsPath);

        // �޸𸮸� ��� ����ϱ� ������ �̷� ���� ����ϸ� �ȵȴ�.
        //string path = Application.dataPath;
        //path += "\n";
        //path += Application.persistentDataPath;
        //path += "\n";
        //path += Application.streamingAssetsPath;

        //text.text = path;
        //text.text = sb.ToString();
        
        print(JsonUtility.ToJson(new PlayerData()));

       
    }

    public void Save()
    {
        foreach (PlayerData data in playerDatas)
        {
            // �ؽ�Ʈ ������ ����� ��� (���ϸ�, Ȯ���� ����)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData �� Json ���ڿ��� ��ȯ
            string json = JsonConvert.SerializeObject(data);  //JsonUtility.ToJson(data);
            // ���� ��� (���, ����)
            File.WriteAllText(path, json);
        }
    }
    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "����", "����" };
        
        // StreamingAssets ������ �ִ� Json ������ ��� �о
        // readFromJson ����Ʈ�� Add �Ͻÿ� 
        // ��Ʈ 

        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // ��ȿ�� �˻�
            if (File.Exists(path))
            {
                //���Ϸ� ���� Json�������� ���ڿ��� �����´�.
                string json = File.ReadAllText(path);
                // json ������ �����͸� �Ľ��Ͽ� PlayerData �ν��Ͻ� ���� �� �� �Ҵ�.
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);  // newtonsoft.json ����ϴ� ���
                //JsonUtility.FromJson<PlayerData>(json); -> ������� -> ������ü�� �̰��� �� ������ ����� �����ϴ�.
                readFromJson.Add(data);
            }
        }
    }

}

// �ٸ� ���·� �����͸� ����ϱ� ���ؼ� ����ȭ ������ �ʿ��ϴ�.
[Serializable] // �� ������� ����ȭ ���� -> �̰� �ٿ��� �ν����� â���� ������ �����ϴ�. -> ȣȯ���� �ö󰡴� ��� ���ȼ��� ��������.(������������)
public class PlayerData // ������ ȣȯ���� �ʿ��� ������ ��ü�̱� ������ ����ȭ ��.
{
    public string name;
    public int level;
    public float exp;
    public int hp;
    public int attack;
    public int[] items;
    public List<SkillData> skills;
}
[Serializable]
public class SkillData
{
    public int id;
    public int level;
    public UpgradeType upgrade;
}

public enum UpgradeType
{
    Attack,
    Defence,
    Speed,
    HP
}

