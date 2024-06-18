using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArray<T>
{
    public T[] array;
    public SafeArray(int a)
    {
        array = new T[a];
    }

    public T this[int index]
    {
        get
        {
            return array[index];
        }
        set
        {
            array[index] = value;
        }
    }
}
public class SafeArrayTester : MonoBehaviour
{
    public SafeArray<int> safeArray;


    public void Start()
    {
            safeArray = new SafeArray<int>(5);
    }

        private void Set(int a, int Value)
        {
            safeArray.array[a] = Value;

            if (safeArray.array.Length < a)
            {
                Debug.Log("a is greater than the length of the array");
            }
        }
}
