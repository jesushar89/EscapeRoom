using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject storyCanvas;
    public GameObject player;

    private void Start()
    {
        menuCanvas.SetActive(true);
        storyCanvas.SetActive(false);
        player.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        menuCanvas.SetActive(false);
        storyCanvas.SetActive(true);
    }

    public void StartAdventure()
    {
        storyCanvas.SetActive(false);
        player.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
