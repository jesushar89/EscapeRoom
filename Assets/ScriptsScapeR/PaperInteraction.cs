using UnityEngine;
using UnityEngine.InputSystem;

public class PaperInteraction : MonoBehaviour
{

    private bool playerInside;
    private bool readingPaper = false;
    public GameObject paperPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Jugador cerca de la hoja");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("Jugador se alejó de la hoja");

        }
    }

    private void Update()
    {
        if (playerInside &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            readingPaper = true;

            paperPanel.SetActive(true);

            Debug.Log("Cursor activado");
        }

        if (readingPaper &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            paperPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            readingPaper = false;

            Debug.Log("Hoja cerrada");
        }
    }
}
