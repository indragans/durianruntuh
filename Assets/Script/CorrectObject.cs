using UnityEngine;

public class CorrectObject : MonoBehaviour
{
    public int points = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // pastikan Basket punya Tag "Basket"
        if (collision.CompareTag("Basket"))
        {
            // tandai sudah tertangkap supaya KillZone tidak -1 nyawa
            GetComponent<CorrectObjectResolvedFlag>()?.MarkCaught();

            GameManager.I?.ScoreAdd(points);
            Destroy(gameObject);
        }
    }
}
