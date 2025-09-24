using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string sceneName;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip clickSound;
   // [SerializeField] private AudioSource audioSource;

    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Mainkan audio kalau ada
           /*if (audioSource != null && clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
            }*/

            // Pindah scene setelah suara (atau langsung kalau tidak perlu delay)
            SceneManager.LoadScene(sceneName);
        }
    }
}
