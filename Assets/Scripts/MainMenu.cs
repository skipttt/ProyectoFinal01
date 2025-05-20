using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "GameScene";
    public GameObject controlsPanel;

    public void PlayGame()
    {
        // Reiniciar dificultad antes de cargar la escena
        if (DifficultyManager.Instance != null)
            DifficultyManager.Instance.ResetDifficulty();

        SceneManager.LoadScene(sceneToLoad);
    }

    public void ShowControls()
    {
        if (controlsPanel != null)
            controlsPanel.SetActive(true);
    }

    public void HideControls()
    {
        if (controlsPanel != null)
            controlsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
