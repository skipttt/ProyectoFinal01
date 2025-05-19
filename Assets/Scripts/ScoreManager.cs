using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public TMP_Text tmpScoreText;

    public float pointsPerSecond = 10f; // Puntos que ganas por cada segundo sobrevivido
    private float score = 0f;

    void Update()
    {
        score += pointsPerSecond * Time.deltaTime;

        int displayScore = Mathf.FloorToInt(score);

        if (scoreText != null)
            scoreText.text = displayScore + " M";

        if (tmpScoreText != null)
            tmpScoreText.text = displayScore + " M";
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }
}
