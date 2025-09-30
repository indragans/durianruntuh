using UnityEngine;

public class WrongObject : MonoBehaviour
{
    private GameManager GM;

    void Start()
    {
        GM = FindObjectOfType<GameManager>(); // otomatis cari GameManager di scene
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah tabrakan dengan Basket
        if (collision.CompareTag("Basket"))
        {
            // Kurangi 1 nyawa, bukan langsung Game Over
            if (GM != null)
                GM.LoseLife(1);

            Destroy(gameObject);
        }
    }
}
