using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text gamePointsText;
    [SerializeField] private Text extraPointsText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Button playButton;
    [SerializeField] private Image textGroup;
    [SerializeField] private Image buttonsGroup;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject uiCanvas;

    private void Awake()
    {
        gameCanvas.SetActive(false);
        scoreText.text = PlayerPrefs.GetInt("lastScore").ToString();
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();

        Data.onExtraScore += ExtraScoreAnimation;
        Data.onScore += ScoreAnimation;
    }
    private void Update()
    {
        coinsText.text = Data.coins.ToString();
    }

    private void ExtraScoreAnimation(int score)
    {
        extraPointsText.text = "+ " + score;
        Vector3 startPos = extraPointsText.rectTransform.position;
        extraPointsText.rectTransform.DOLocalMoveX(0, 0.7f);
        extraPointsText.DOFade(0, 0.7f);
        DOTween.Sequence()
            .AppendInterval(0.7f)
            .OnComplete(() => RestoreExtraScore(startPos, score));
    }


    private void RestoreExtraScore(Vector3 startPos, int score)
    {
        ScoreAnimation();
        extraPointsText.text = "";
        extraPointsText.rectTransform.DOLocalMoveX(270, 0f);
        extraPointsText.DOFade(1, 0f);
    }

    private void ScoreAnimation()
    {
        gamePointsText.text = Data.gamePoints.ToString();
        this?.gamePointsText.transform.DOKill(true);
        this?.gamePointsText.transform.DOPunchScale(new Vector3(1.5f, 1.5f, 1), 0.5f, 2);
    }

    public void GameStartAnimation()
    {
        buttonsGroup.rectTransform.DOLocalMoveY(-2000, 3f);
        textGroup.rectTransform.DOLocalMoveY(2000, 3f);
        DOTween.Sequence()
            .Append(canvasGroup.DOFade(0, 0.5f))
            .OnComplete(() => ChangeCanvas());
    }

    private void ChangeCanvas()
    {
        uiCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        Data.onExtraScore -= ExtraScoreAnimation;
        Data.onScore -= ScoreAnimation;
    }
}
