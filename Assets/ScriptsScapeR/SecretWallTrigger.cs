using UnityEngine;
using UnityEngine.InputSystem;

public class SecretWallTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool playerInside;
    private bool boxOpen = false;

    public GameObject boxCanvas;

    public SecretWallController secretWallController;

    private void Update()
    {
        if (playerInside &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Caja abierta");

            boxCanvas.SetActive(true);
            boxOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (boxOpen &&
    Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            boxCanvas.SetActive(false);
            boxOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Debug.Log("Caja cerrada");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }
}
