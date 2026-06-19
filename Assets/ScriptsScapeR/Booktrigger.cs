using UnityEngine;
using UnityEngine.InputSystem;

public class Booktrigger : MonoBehaviour
{


    private bool playerInside;
    public string bookColor;
    public BookPuzzleManager puzzleManager;

    private void Update()
    {
        if (playerInside &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {

            Debug.Log("Libro activado");
            puzzleManager.PressBook(bookColor);
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
