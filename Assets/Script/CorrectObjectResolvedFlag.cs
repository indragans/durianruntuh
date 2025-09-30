using UnityEngine;

public class CorrectObjectResolvedFlag : MonoBehaviour
{
    // tanda apakah objek sudah tertangkap (supaya tidak -1 nyawa lagi saat jatuh)
    public bool IsResolved { get; private set; }

    // panggil ini di Basket saat buah tertangkap
    public void MarkCaught()
    {
        IsResolved = true;
    }
}
