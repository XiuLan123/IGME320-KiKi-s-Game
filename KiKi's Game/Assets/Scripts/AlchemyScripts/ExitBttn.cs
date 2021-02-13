using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBttn : MonoBehaviour
{
    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        SceneManager.LoadScene(0);
        #else
         Application.Quit();
        #endif
    }
}
