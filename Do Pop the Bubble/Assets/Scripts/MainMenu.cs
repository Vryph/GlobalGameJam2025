using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*void Start(){
    FindObjectOfType<SAudioManager>().Play("wind");
    }*/

    public void PlayGame()
    {
        SceneManager.LoadScene("WaterBubblesMinigame");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    void Update()
    {

    }
}
