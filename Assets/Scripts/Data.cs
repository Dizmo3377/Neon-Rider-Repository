using UnityEngine;

public class Data : MonoBehaviour
{
    public static int gamePoints = 0;
    public static int coins;

    public delegate void OnExtraScore(int value);
    public static event OnExtraScore onExtraScore;

    public delegate void OnScore();
    public static event OnScore onScore;

    public static bool gameStarted = false;

    private void Awake()
    {
        gamePoints = 0;
        coins = PlayerPrefs.GetInt("coins");
    }

    public static void CoinPickUp()
    {
        coins++;
        PlayerPrefs.SetInt("coins", coins);
    }

    public static void ChangeScore(int value, bool isExtra)
    {
        gamePoints += value;
        if (isExtra) { onExtraScore(value); }
        else if(!isExtra) { onScore(); }
    }

    public static void NewScore()
    {
        PlayerPrefs.SetInt("lastScore", gamePoints);
        if (gamePoints > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", gamePoints);
        }
    }

    public static void StartGame()
    {
        gameStarted = true;
    }
}
