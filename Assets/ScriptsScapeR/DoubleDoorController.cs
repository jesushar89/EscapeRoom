using UnityEngine;
using UnityEngine.InputSystem;

public class DoubleDoorController : MonoBehaviour
{
    public Transform doorLeft;
    public Transform doorRight;

    public float openDistance = 2f;
    public float openSpeed = 2f;

    private Vector3 leftClosedPos;
    private Vector3 rightClosedPos;

    private Vector3 leftOpenPos;
    private Vector3 rightOpenPos;

    private bool opening = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftClosedPos = doorLeft.position;
        rightClosedPos = doorRight.position;

        leftOpenPos = leftClosedPos + new Vector3(0, 0, -openDistance);
        rightOpenPos = rightClosedPos + new Vector3(0, 0, openDistance);
    }

    // Update is called once per frame

    public void OpenDoors()
    {
        opening = true;
    }
    void Update()
    {
        

        if (opening)
        {
            doorLeft.position = Vector3.MoveTowards(
                doorLeft.position,
                leftOpenPos,
                openSpeed * Time.deltaTime);

            doorRight.position = Vector3.MoveTowards(
                doorRight.position,
                rightOpenPos,
                openSpeed * Time.deltaTime);
        }
    }
}
