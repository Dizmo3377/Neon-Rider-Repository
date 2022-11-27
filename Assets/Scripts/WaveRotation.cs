using UnityEngine;
using DG.Tweening;

public class WaveRotation : MonoBehaviour
{
    [SerializeField] private float angle;
    private void Start()
    {
        transform.eulerAngles = new Vector3 (0, 0, angle);
        DOTween.Sequence()
            .Append(transform.DOLocalRotate(new Vector3(0, 0, -angle), 1f))
            .AppendInterval(0.5f)
            .Append(transform.DOLocalRotate(new Vector3(0, 0, angle), 1f))
            .AppendInterval(0.5f)
            .SetLoops(-1);
    }
}
