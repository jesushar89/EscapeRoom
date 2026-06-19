using UnityEngine;
using System.Collections;

public class EndingTrigger : MonoBehaviour
{
    
    public GameObject endPanel;
    public CanvasGroup endCanvasGroup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            Time.timeScale = 0f;

            endPanel.SetActive(true);
            StartCoroutine(FadeIn());

            Debug.Log("Panel final mostrado");
        }
    }

    private IEnumerator FadeIn()
    {
        float tiempo = 0f;

        while (tiempo < 1f)
        {
            tiempo += Time.unscaledDeltaTime;
            endCanvasGroup.alpha = tiempo;
            yield return null;
        }

        endCanvasGroup.alpha = 1f;
    }
}
