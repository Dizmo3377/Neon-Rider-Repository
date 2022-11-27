using UnityEngine;

public class Prop : MonoBehaviour
{
    [SerializeField] private float offset;
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            Level levelCreator = GameObject.FindObjectOfType<Level>();
            levelCreator.CreateProp(offset - 5);
            Data.ChangeScore(1, false);
            isActivated = true;
        }
    }
}
