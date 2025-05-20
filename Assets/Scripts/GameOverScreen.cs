using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    public Animator feedbackAnimator;
    public TextMeshProUGUI feedbackText;

    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            feedbackText.text = "¡Nuevo récord!";
        }
        else
        {
            feedbackText.text = GetRandomMessage();
        }

        currentScoreText.text = "Puntaje: " + currentScore;
        highScoreText.text = "Top Score: " + highScore;

        feedbackAnimator.SetTrigger("Show");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    string GetRandomMessage()
    {
        string[] frases = {
            "¡Buen intento!",
            "¡Vas mejorando!",
            "¡Sigue así!",
            "¡No te rindas!"
        };
        return frases[Random.Range(0, frases.Length)];
    }
}
