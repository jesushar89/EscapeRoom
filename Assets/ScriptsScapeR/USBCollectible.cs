using UnityEngine;
using UnityEngine.InputSystem;

public class USBCollectible : MonoBehaviour
{
    private bool playerInside;
    public USBManager usbManager;
    public string usbColor;
    private bool collected = false;

    private void Update()
    {
        if (playerInside &&
            !collected &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            collected = true;

            usbManager.usbCount++;

            Debug.Log("USB recogidas: " + usbManager.usbCount);

            usbManager.collectedUSBs.Add(usbColor);

            usbManager.ShowUSB(usbColor);

            Debug.Log("Recogiste la USB: " + usbColor);

            gameObject.SetActive(false);
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
