using UnityEngine;

public class SecretWallController : MonoBehaviour
{
    public float rotationSpeed = 90f;

    private bool isOpen = false;
    private Quaternion targetRotation;

    private void Update()
    {
        if (!isOpen)
            return;

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    public void OpenWall()
    {
        if (isOpen)
            return;

        isOpen = true;

        targetRotation = Quaternion.Euler(0, 270, 0);

        Debug.Log("La pared está girando");
    }
}
