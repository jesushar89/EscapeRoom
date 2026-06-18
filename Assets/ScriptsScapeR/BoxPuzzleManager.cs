using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class BoxPuzzleManager : MonoBehaviour
{
    public USBManager usbManager;
    public GameObject slotBlue;
    public GameObject slotWhite;
    public GameObject slotRed;
    public GameObject slotYellow;
    public Button blueButton;
    public Button whiteButton;
    public Button redButton;
    public Button yellowButton;


    private List<string> playerOrder = new List<string>();

    private string[] correctOrder =
    {
        "Azul",
        "Blanco",
        "Rojo",
        "Amarillo"
    };

    public SecretWallController secretWallController;

    public void PressBlue()
    {
        if (usbManager.collectedUSBs.Contains("Azul"))
        {
            slotBlue.SetActive(true);

            playerOrder.Add("Azul");
            Debug.Log("Orden actual: " + playerOrder.Count);

            if (playerOrder.Count == 4)
            {
                CheckPuzzle();
                return;
            }

            Debug.Log("USB Azul colocada");

            blueButton.interactable = false;
        }
        else
        {
            Debug.Log("No tienes la USB Azul");
        }
    }

    public void PressWhite()
    {
        if (usbManager.collectedUSBs.Contains("Blanco"))
        {
            slotWhite.SetActive(true);

            playerOrder.Add("Blanco");
            Debug.Log("Orden actual: " + playerOrder.Count);

            if (playerOrder.Count == 4)
            {
                CheckPuzzle();
                return;
            }

            Debug.Log("USB Blanca colocada");
            whiteButton.interactable = false;
        }

        else
        {
            Debug.Log("No tienes la USB Blanca");
        }
            
    }

    public void PressRed()
    {
        if (usbManager.collectedUSBs.Contains("Rojo"))
        {
            slotRed.SetActive(true);

            playerOrder.Add("Rojo");
            Debug.Log("Orden actual: " + playerOrder.Count);
            
            if (playerOrder.Count == 4)
            {
                CheckPuzzle();
                return;
            }

            Debug.Log("USB Roja colocada");
            redButton.interactable = false;
        }

        else
        {
            Debug.Log("No tienes la USB Roja");
        }
            
    }

    public void PressYellow()
    {
        if (usbManager.collectedUSBs.Contains("Amarillo"))
        {
            slotYellow.SetActive(true);

            playerOrder.Add("Amarillo");
            Debug.Log("Orden actual: " + playerOrder.Count);

            if (playerOrder.Count == 4)
            {
                CheckPuzzle();
                return;
            }

            Debug.Log("USB Amarilla colocada");
            yellowButton.interactable = false;
        }

        else
        {
            Debug.Log("No tienes la USB Amarilla");
        }
            
    }

    private void CheckPuzzle()
    {
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (playerOrder[i] != correctOrder[i])
            {
                Debug.Log("Puzzle incorrecto");

                ResetPuzzle();

                return;
            }
        }

        Debug.Log("Puzzle completado");

        secretWallController.OpenWall();
    }

    private void ResetPuzzle()
    {
        playerOrder.Clear();

        slotBlue.SetActive(false);
        slotWhite.SetActive(false);
        slotRed.SetActive(false);
        slotYellow.SetActive(false);

        blueButton.interactable = true;
        whiteButton.interactable = true;
        redButton.interactable = true;
        yellowButton.interactable = true;

        Debug.Log("Puzzle reiniciado");
    }
}
