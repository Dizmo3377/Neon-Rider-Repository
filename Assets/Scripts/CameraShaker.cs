using UnityEngine;
using DG.Tweening;

public class CameraShaker : MonoBehaviour
{
    [SerializeField]
    private static Camera camera_;

    private void Awake()
    {
        camera_ = Camera.main;
    }

    public static void Shake(float duration, float strength, int  vibrato)
    {
        camera_.DOShakePosition(duration, strength, vibrato);
    }
}
