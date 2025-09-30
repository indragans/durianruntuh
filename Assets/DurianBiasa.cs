using UnityEngine;  // <- WAJIB

public class DurianBiasa : MonoBehaviour  // <- nama class harus sama dengan NAMA FILE
{
    // contoh isi minimal (opsional)
    public int points = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket"))
        {
            GameManager.I?.ScoreAdd(points);
            other.GetComponent<CorrectObjectResolvedFlag>()?.MarkCaught();
            Destroy(gameObject);
        }
    }
}
