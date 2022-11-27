using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private static Image transitionImage;
    private static float duration;
    private void Awake()
    {
        transitionImage = GetComponent<Image>();
        transitionImage.DOFade(0, duration / 2);
    }

    public static void Start(float duration_, int sceneIndex)
    {
        duration = duration_;
        DOTween.Sequence()
            .AppendInterval(2f)
            .Append(transitionImage.DOFade(1, duration / 2))
            .OnComplete(() => SceneManager.LoadScene(sceneIndex));
    }
}
