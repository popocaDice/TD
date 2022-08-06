using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public GameObject pauseUI, pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) Pause();
    }

	public void Pause()
	{
		Time.timeScale = 0;
		pauseButton.SetActive(false);
		pauseUI.SetActive(true);
	}

	public void Unpause()
	{
		Time.timeScale = 1;
		pauseButton.SetActive(true);
		pauseUI.SetActive(false);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
