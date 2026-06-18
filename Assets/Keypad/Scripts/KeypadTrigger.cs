using StarterAssets;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


public class KeypadTrigger : MonoBehaviour
{
    public GameObject interactText;
    public CinemachineCamera keypadCamera;
    public ThirdPersonController playerController;

    private bool playerInside;
    private bool usingKeypad = false;

    private void Awake()
    {
        keypadCamera.Priority = 0;
        keypadCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInside &&
            !usingKeypad &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            keypadCamera.gameObject.SetActive(true);
            keypadCamera.Priority = 20;
            playerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            usingKeypad = true;
        }

        if (usingKeypad &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            keypadCamera.Priority = 0;
            keypadCamera.gameObject.SetActive(false);
            playerController.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            usingKeypad = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            interactText.SetActive(false);
        }
    }
}