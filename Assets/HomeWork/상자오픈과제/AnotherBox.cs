using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherBox : MonoBehaviour, IInteractable
{
    public void Interact()
    {
      gameObject.SetActive(false);
    }
}
