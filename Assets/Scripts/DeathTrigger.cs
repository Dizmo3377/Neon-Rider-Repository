using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private Motorcycle motorcycle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        motorcycle.Die();
    }
}
