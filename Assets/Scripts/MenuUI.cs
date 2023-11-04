using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;


    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(Play);
        exitButton.onClick.AddListener(Exit);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);

    }

    private void Exit()
    {
        Application.Quit();
    }
}
