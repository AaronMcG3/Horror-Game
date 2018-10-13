using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    [SerializeField] private Button level1;
    [SerializeField] private Button level2;
    [SerializeField] private Button end;

    // Use this for initialization
    void Start () {
        level1.onClick.AddListener(Level1Click);
        level2.onClick.AddListener(Level2Click);
        end.onClick.AddListener(EndClick);
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void Level1Click()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    private void Level2Click()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    private void EndClick()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
