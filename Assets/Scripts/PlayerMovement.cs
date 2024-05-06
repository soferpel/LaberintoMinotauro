using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform camTransform;
    public AudioSource audioSource;
    public AudioClip footstepSound;
    private bool isMoving = false;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 camForward = Vector3.Scale(camTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = (verticalInput * camForward + horizontalInput * camTransform.right).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (movement.magnitude > 0)
        {
            if (!isMoving)
            {
                isMoving = true;
                audioSource.clip = footstepSound;
                audioSource.Play();
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                audioSource.Stop();
            }
        }
    }
}
