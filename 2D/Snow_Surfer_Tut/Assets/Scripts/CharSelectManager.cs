using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject SpinoSprite;
    [SerializeField] GameObject TRexSprite;
    void Start()
    {
        Time.timeScale = 0f;
    }

   void BeginGame()
    {
        Time.timeScale = 1f;
        ScoreText.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ChooseSpino()
    {
        SpinoSprite.SetActive(true);
        BeginGame();
    }
    public void ChooseTRex()
    {
        TRexSprite.SetActive(true);
        BeginGame();
    }
}
