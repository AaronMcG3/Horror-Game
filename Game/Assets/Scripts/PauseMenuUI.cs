using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour {

    [SerializeField] private Button mainMenu;
    [SerializeField] private Button resume;
    [SerializeField] private Button quit;

    // Use this for initialization
    void Start () {
        mainMenu.onClick.AddListener(MainMenuClick);
        resume.onClick.AddListener(ResumeClick);
        quit.onClick.AddListener(QuitClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void MainMenuClick()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private void ResumeClick()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    private void QuitClick()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

}
