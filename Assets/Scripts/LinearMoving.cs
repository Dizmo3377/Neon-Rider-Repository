using UnityEngine;

public class LinearMoving : MonoBehaviour
{
    [SerializeField] private Vector3 targetPoint;
    [SerializeField] private float speed;
    private Vector3 startPosition;
    private int movePhase = 0;

    private void Awake()
    {
        startPosition = transform.position;
        targetPoint = transform.position + targetPoint;
    }

    private void FixedUpdate()
    {
        var step = speed * Time.deltaTime;
        if (movePhase == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
            if (transform.position == targetPoint) { movePhase = 1; }
        }
        else if (movePhase == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
            if (transform.position == startPosition) { movePhase = 0; }
        }
    }
}