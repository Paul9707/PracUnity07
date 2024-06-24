using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEasyToggleTest : MonoBehaviour
{

    public Color changeColor;

    public Image targetImage;
    // �� �Լ��� toggle�� On Value Change �̺�Ʈ�� ȣ�� �Ұ̴ϴ�.
    public void OnToggleValueChange(bool isOn)
    {
        if (isOn)
        {
            targetImage.color = changeColor;
        }
        else
        {
            print($"{name} toggle is off");
        }
    }
    


}
