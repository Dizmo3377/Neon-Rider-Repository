using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Transform player;
    [SerializeField] private float scrollSpeed;

    private void Awake()
    {
        if (material == null) { material = GetComponent<Material>(); }
        if (player == null) { player = FindObjectOfType<Motorcycle>().GetComponent<Transform>(); }
    }

    private void FixedUpdate()
    {
        if (material != null && player != null)
        {
            material.SetTextureOffset("_MainTex", new Vector2(player.position.x * Time.deltaTime * scrollSpeed, 0));
        }
    }
}
