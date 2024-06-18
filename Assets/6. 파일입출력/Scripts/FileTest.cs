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

        // 메모리를 계속 사용하기 때문에 이런 경우는 사용하면 안된다.
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
            // 텍스트 파일을 출력할 경로 (파일명, 확장자 포함)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData 를 Json 문자열로 변환
            string json = JsonConvert.SerializeObject(data);  //JsonUtility.ToJson(data);
            // 파일 출력 (경로, 내용)
            File.WriteAllText(path, json);
        }
    }
    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "도적", "전사" };
        
        // StreamingAssets 폴더에 있는 Json 파일을 모두 읽어서
        // readFromJson 리스트에 Add 하시오 
        // 힌트 

        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // 유효성 검사
            if (File.Exists(path))
            {
                //파일로 부터 Json포맷으로 문자열을 가져온다.
                string json = File.ReadAllText(path);
                // json 포맷의 데이터를 파싱하여 PlayerData 인스턴스 생성 후 값 할당.
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);  // newtonsoft.json 사용하는 방법
                //JsonUtility.FromJson<PlayerData>(json); -> 기존방법 -> 성능자체는 이것이 더 좋으나 기능이 부족하다.
                readFromJson.Add(data);
            }
        }
    }

}

// 다른 형태로 데이터를 취급하기 위해선 직렬화 과정이 필요하다.
[Serializable] // 이 방법으로 직렬화 가능 -> 이걸 붙여야 인스펙터 창에서 수정이 가능하다. -> 호환성이 올라가는 대신 보안성이 떨어진다.(남발하지마라)
public class PlayerData // 데이터 호환성이 필요한 데이터 객체이기 때문에 직렬화 함.
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

