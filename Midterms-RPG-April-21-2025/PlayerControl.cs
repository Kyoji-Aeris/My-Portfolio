using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController characterController;
    public MenuManager menuManager;
    public int rotationSpeed = 5;
    public int movementSpeed = 5;
    public float gravity = 9.81f;
    public Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }
    void Update()
    {
        if (menuManager.pausePanel.activeSelf != true)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(move * movementSpeed * Time.deltaTime);
    }

   

}
