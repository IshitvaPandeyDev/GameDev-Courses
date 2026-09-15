using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    int score=0;
   
    public void AddScore(int AdditionalScore)
    {
        score += AdditionalScore;
        ScoreText.text = "Score: " + score;
    }
}
