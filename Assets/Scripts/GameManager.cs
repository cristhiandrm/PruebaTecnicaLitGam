using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Scenes")]
    public string nextEscene;

    [Header("Player Reference")]
    public GameObject player;

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextEscene);
        player.transform.position=new Vector3(-0.026f, 0.03f, -19.98f);
    }
}
