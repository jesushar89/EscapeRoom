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

    private void Start()
    {
        keypadCamera.Priority = 0;
    }

    private void Update()
    {
        if (playerInside && UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame)
        {
            keypadCamera.Priority = 20;
            playerController.enabled = false;
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