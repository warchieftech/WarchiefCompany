using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScean : MonoBehaviour
{
    public string nextScean;

    public void NextScean()
    {
        SceneManager.LoadScene(nextScean);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
