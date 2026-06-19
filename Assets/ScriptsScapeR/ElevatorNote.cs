using UnityEngine;
using UnityEngine.InputSystem;


public class ElevatorNote : MonoBehaviour
{
    private bool playerInside;
    private bool noteOpen = false;

    public GameObject noteCanvas;

    private void Update()
    {
        if (playerInside &&
            !noteOpen &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            noteCanvas.SetActive(true);
            noteOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("Hoja abierta");
        }

        if (noteOpen &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            noteCanvas.SetActive(false);
            noteOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Debug.Log("Hoja cerrada");
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
