using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class BookPuzzleManager : MonoBehaviour
{
    private string[] correctOrder =
    {
        "Rojo",
        "Verde",
        "Amarillo",
        "Azul"
    };

    public CinemachineCamera windowCamera;

    public BoxCollider windowEndingCollider;


    private int currentIndex = 0;

    public WindowController windowController;

    private void Awake()
    {
        windowCamera.Priority = 0;
    }

    public void PressBook(string color)
    {
        Debug.Log("Libro presionado: " + color);

        if (color == correctOrder[currentIndex])
        {
            currentIndex++;

            Debug.Log("Correcto. Paso: " + currentIndex);

            if (currentIndex >= correctOrder.Length)
            {
                Debug.Log("Puzzle completado");

                windowCamera.gameObject.SetActive(true);
                windowCamera.Priority = 20; 
                windowController.OpenWindows();

                windowEndingCollider.enabled = true;

                StartCoroutine(ReturnCamera());
            }
        }
        else
        {
            Debug.Log("Orden incorrecto. Reiniciando.");
            currentIndex = 0;
        }
    }

    private IEnumerator ReturnCamera()
    {
        yield return new WaitForSeconds(2f);

        windowCamera.Priority = 0;
        windowCamera.gameObject.SetActive(false);
    }
}
