using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; // ����Ʈ���μ��� �ϱ� ���� ���

public class PostProcessingTest : MonoBehaviour
{
    public PostProcessVolume volume; // ����Ʈ���μ��� ����

    [Range(0, 1)]
    public float caIntencity = 0.0f; // ���� ����

    ChromaticAberration ca; // ����

    private void Start()
    {
        if (volume.profile.TryGetSettings(out ca)) // ���� ���� ��������
        {
            print("�� ���� ���� ������");
        }
        else
        {
            print("�� ���� ���� �������� ����");
        }
    }

    private void Update()
    {
        if (ca == null)
        {
            return;
        }
        ca.intensity.value = caIntencity; // ���� ���� ����
    }
}
