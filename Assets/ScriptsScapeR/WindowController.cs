using UnityEngine;

public class WindowController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform windowLeft;
    public Transform windowRight;

    public float slideDistance = 1f;
    public float slideSpeed = 2f;

    private bool isOpen = false;
    private Vector3 leftTarget;
    private Vector3 rightTarget;

    public void OpenWindows()
    {
        if (isOpen) return;

        isOpen = true;

        leftTarget = windowLeft.position + new Vector3(0, 0, 1f);
        rightTarget = windowRight.position + new Vector3(0, 0, -1f);

        Debug.Log("Ventanas abiertas");
    }

    private void Update()
    {
        if (!isOpen) return;

        windowLeft.position = Vector3.MoveTowards(
            windowLeft.position,
            leftTarget,
            slideSpeed * Time.deltaTime);

        windowRight.position = Vector3.MoveTowards(
            windowRight.position,
            rightTarget,
            slideSpeed * Time.deltaTime);
    }
}
