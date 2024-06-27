using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; // 포스트프로세싱 하기 위해 사용

public class PostProcessingTest : MonoBehaviour
{
    public PostProcessVolume volume; // 포스트프로세싱 볼륨

    [Range(0, 1)]
    public float caIntencity = 0.0f; // 색차 강도

    ChromaticAberration ca; // 색차

    private void Start()
    {
        if (volume.profile.TryGetSettings(out ca)) // 색차 설정 가져오기
        {
            print("색 수차 세팅 존재함");
        }
        else
        {
            print("색 수차 세팅 존재하지 않음");
        }
    }

    private void Update()
    {
        if (ca == null)
        {
            return;
        }
        ca.intensity.value = caIntencity; // 색차 강도 설정
    }
}
