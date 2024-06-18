using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public Animator anim;
    public void Interact()
    {
        anim.SetBool("isOpen", true);
    }
}
