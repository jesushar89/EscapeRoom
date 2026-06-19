using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NavKeypad { 
public class KeypadInteractionFPV : MonoBehaviour
{
    private Camera cam;
    private void Awake() => cam = Camera.main;

    private void Start()
    {
        Debug.Log("KeypadInteractionFPV iniciado");
    }
    private void Update()
    {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                var ray = cam.ScreenPointToRay(
                    Mouse.current.position.ReadValue());

                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.TryGetComponent(
                        out KeypadButton keypadButton))
                    {
                        keypadButton.PressButton();
                    }
                }
            }
    }

    }
}