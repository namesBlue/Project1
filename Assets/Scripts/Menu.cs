using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool exit = false;

    private void Start()
    {
        Invoke("ExitAnim", 7f);
    }

    private void Update()
    {
        
    }
    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    public void NewStart()
    {
        SceneManager.LoadScene(4);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(2);

    }

    public void Settings()
    {
        SceneManager.LoadScene(3);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void ExitAnim()
    {
        exit = true;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   public void GoToLevel_1()
    {
        SceneManager.LoadScene(4);
    }
    public void GoToLevel_2()
    {
        SceneManager.LoadScene(10);
    }

    public void GoToLevel_3()
    {
        SceneManager.LoadScene(16);
    }

    public void GoToLevel_4()
    {
        SceneManager.LoadScene(22);
    }

    public void GoToLevel_5()
    {
        SceneManager.LoadScene(28);
    }

    public void GoToLevel_6()
    {
        SceneManager.LoadScene(34);
    }

    public void GoToLevel_7()
    {
        SceneManager.LoadScene(35);
    }

    public void GoToLevel_8()
    {
        SceneManager.LoadScene(36);
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }

}
