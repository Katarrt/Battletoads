using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue() {

        canvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


}
