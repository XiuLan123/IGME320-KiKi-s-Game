using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBttn : MonoBehaviour
{
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
