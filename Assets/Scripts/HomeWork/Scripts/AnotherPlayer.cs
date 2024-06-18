using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnotherPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CharacterController playerController;
    public Transform playerModel;
    public Text interact;
    Vector3 move;
    private void Start()
    {
        interact.enabled = false;
    }
    void Update()
    {
        if (playerController.isGrounded)
        {
            Move(10f);
        }
        else
        {
            move.y -= 15f * Time.deltaTime;
        }
        playerController.Move(move * Time.deltaTime);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
           interact.enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            other.GetComponent<IInteractable>().Interact();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            interact.enabled = false;
        }
    }


    public void Move(float rate)
    {
        move.y = 0;
        Vector3 inputMoveXZ = new Vector3
            (
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")
            );
        inputMoveXZ = gameObject.transform.rotation * inputMoveXZ;
        inputMoveXZ.y = 0;
        float inputMoveXZMagnitude = inputMoveXZ.sqrMagnitude;

        if (inputMoveXZMagnitude <= 1)
        {
            inputMoveXZ *= moveSpeed;
        }
        else
        {
            inputMoveXZ = inputMoveXZ.normalized * moveSpeed;
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {

            Quaternion characterRotation = Quaternion.LookRotation(inputMoveXZ);
            characterRotation.x = characterRotation.z = 0;
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, characterRotation, 10 * Time.deltaTime);

            move = Vector3.MoveTowards(move, inputMoveXZ, moveSpeed * rate);

        }
        else
        {
            move = Vector3.MoveTowards(move, Vector3.zero, moveSpeed * rate);
        }

    }
}
