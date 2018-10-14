using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

    [SerializeField] private Button level1;
    [SerializeField] private Button level2;
    [SerializeField] private Button quit;

    // Use this for initialization
    void Start () {
        level1.onClick.AddListener(Level1Click);
        level2.onClick.AddListener(Level2Click);
        quit.onClick.AddListener(QuitClick);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Level1Click()
    {
        SceneManager.LoadScene(1);
    }

    private void Level2Click()
    {
        SceneManager.LoadScene(2);
    }

    private void QuitClick()
    {
        Application.Quit();
    }
}
