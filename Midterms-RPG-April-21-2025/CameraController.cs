using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float rayDistance;
    public Transform headPosition;
    public MenuManager menuManager;
    public GameObject dialoguePanel;
    public GameObject ClickToTalkText;
    public GameObject ClickToCollectText;
    public Vector3 cameraOffSet;
    public int sensitivity;
    public float mouseX;
    public float mouseY;

    public float maxYAngle = 80f;
    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void SetUpStartingPosition()
    {
        transform.position = headPosition.position + cameraOffSet;
    }
    void Update()
    {
        if (menuManager.pausePanel.activeSelf != true && dialoguePanel.activeSelf != true)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

            transform.rotation = Quaternion.Euler(rotationX, headPosition.rotation.eulerAngles.y, 0f);
            transform.parent.Rotate(Vector3.up * mouseX);
            PerformRaycast();
        }

    }

    void PerformRaycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.CompareTag("NPC") == true)
            {
                ClickToTalkText.SetActive(true);
                if (Input.GetMouseButtonDown(0) && menuManager.pausePanel.activeSelf != true)
                {
                    Debug.Log($"Hit {hit.collider.name}");
                    hit.collider.GetComponent<NPC>().Talk();
                    if (dialoguePanel.activeSelf == true)
                    {
                        ClickToTalkText.SetActive(false);
                    }
                }
            }
            else
            {
                ClickToCollectText.SetActive(false);
                ClickToTalkText.SetActive(false);
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
    }
}

