using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Data.CoinPickUp();
            ParticleManager.Create("Coin", this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
