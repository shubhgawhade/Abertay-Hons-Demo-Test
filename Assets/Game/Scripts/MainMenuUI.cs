using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public static bool done;

    [SerializeField] private GameObject prologue;
    
    public void PlayButton()
    {
        if (!done)
        {
            prologue.SetActive(true);
            done = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
