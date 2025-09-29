using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene1 : MonoBehaviour
{
    // Pindah scene pakai index
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Pindah scene pakai nama
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
