using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputfieldTest : MonoBehaviour
{
    private InputField input;

    public Text messageText;
    public Text submitText;
    public Text endText;
    private void Awake()
    {
        input = GetComponent<InputField>();

    }

    public void OnEdit(string text)
    {
        messageText.text = text;
    }

    public void OnSubmit(string text)
    {
        submitText.text = text;
    }

    public void OnEndEdit(string text) //Rich text 를 체크해야 색이 변한다.
    {
        endText.text = $"<color=red>end Edit: {text}</color>";
    }
}
