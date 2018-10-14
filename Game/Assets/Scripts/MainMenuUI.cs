using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenuUI : MonoBehaviour {

    [SerializeField] private Button level1;
    [SerializeField] private Button level2;
    [SerializeField] private Button quit;
    [SerializeField] private GameObject menu, vidObject;

    public VideoPlayer vid;

    // Use this for initialization
    void Start () {
        level1.onClick.AddListener(Level1Click);
        level2.onClick.AddListener(Level2Click);
        quit.onClick.AddListener(QuitClick);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        vid.loopPointReached += CheckOver;
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

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        menu.SetActive(true);
        vidObject.SetActive(false);
    }
}
