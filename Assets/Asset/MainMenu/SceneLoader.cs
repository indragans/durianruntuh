using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LanjutScene()
    {
        SceneManager.LoadScene(1); // angka 1 = scene index ke-1 di Build Settings
    }
}
