using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    [SerializeField] private float rotate;
    [SerializeField] private AnimationCurve rotateVelocity;
    private bool isRotated = false;
    private float activatedTime = 0f;

    private void FixedUpdate()
    {
        if (isRotated)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotate * rotateVelocity.Evaluate(Time.time - activatedTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isRotated)
        {
            activatedTime = Time.time;
            isRotated = true;
        }
    }
}
