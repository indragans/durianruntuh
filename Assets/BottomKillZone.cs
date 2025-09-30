using UnityEngine;

public class BottomKillZone : MonoBehaviour
{
    public string correctTag = "DurianBiasa";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(correctTag)) return;

        var flag = other.GetComponent<CorrectObjectResolvedFlag>();
        // -1 life hanya jika buah BELUM tertangkap
        if (flag == null || !flag.IsResolved)
            GameManager.I?.LoseLife(1);

        Destroy(other.gameObject);
    }
}
