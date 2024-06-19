using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
    Renderer render;
    [Range(0, 1)]
    public float colorAmount;

    private void Awake()
    {
        render = GetComponent<Renderer>();  
    }

    private void Update()
    {
        // 같은 Material을 가진 객체들이 런타임에 색상을 변경해야 할 경우 인스턴스화 시켜서 코드로 제어해야 한다.
        render.material.SetFloat("_colorAmount", colorAmount);
        //render.material.SetColor("_MainTex", Color.white);
    }
}
