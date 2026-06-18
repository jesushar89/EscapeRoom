using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class USBManager : MonoBehaviour
{
    public GameObject usbBlueUI;
    public GameObject usbWhiteUI;
    public GameObject usbRedUI;
    public GameObject usbYellowUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int usbCount = 0;

    public List<string> collectedUSBs = new List<string>();

    public void ShowUSB(string color)
    {
        if (color == "Azul")
            usbBlueUI.SetActive(true);

        else if (color == "Blanco")
            usbWhiteUI.SetActive(true);

        else if (color == "Rojo")
            usbRedUI.SetActive(true);

        else if (color == "Amarillo")
            usbYellowUI.SetActive(true);
    }
}
