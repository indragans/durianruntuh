using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("Drag 3 image ikon basket di sini (kiri ke kanan)")]
    public Image[] lifeIcons;          // 3 slot

    [Header("(Opsional) Kosongkan kalau tidak pakai sprite kosong")]
    public Sprite fullIcon;            // ikon penuh
    public Sprite emptyIcon;           // ikon kosong (opsional)

    // panggil ini setiap kali nyawa berubah
    public void SetLives(int current, int max)
    {
        // Pastikan array lifeIcons punya >= max slot
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            bool slotAktif = i < max;
            if (lifeIcons[i] != null)
            {
                lifeIcons[i].gameObject.SetActive(slotAktif);      // sembunyikan slot ekstra
                if (slotAktif)
                {
                    // Jika punya 2 sprite, ganti penuh/kosong. Kalau tidak, pakai enable/disable
                    if (fullIcon != null && emptyIcon != null)
                        lifeIcons[i].sprite = (i < current) ? fullIcon : emptyIcon;
                    else
                        lifeIcons[i].enabled = (i < current);       // tanpa sprite kosong
                }
            }
        }
    }
}
