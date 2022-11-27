using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [SerializeField] private float angle;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, -1), -angle);
    }
}
