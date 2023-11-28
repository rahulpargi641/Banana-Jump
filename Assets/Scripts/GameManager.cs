using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    // Start is called before the first frame update
    void Awake()
    {
        if(gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("LoadGameplay", 2f);
    }
    void LoadGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }
}
