using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    UnityEvent gameStart;

    [SerializeField]
    List<GameObject> startObjects = new List<GameObject>();

    [SerializeField]
    List<GameObject> endObjects = new List<GameObject>();

    private void Start()
    {
        HideEndObjects();
    }

    public void GameStart()
    {
        gameStart.Invoke();
    }

    public void ReStart()
    {
        SceneManager.LoadScene("Instatiate AppleMap");
    }

    public void HideStartObjects()
    {
        foreach (GameObject gameObject in startObjects)
        {
            gameObject.SetActive(false);
        }
    }
    public void HideEndObjects()
    {
        foreach (GameObject gameObject in endObjects)
        {
            gameObject.SetActive(false);
        }
    }
    public void ApearStartObjects()
    {
        foreach (GameObject gameObject in startObjects)
        {
            gameObject.SetActive(true);
        }
    }
    public void ApearEndObjects()
    {
        foreach (GameObject gameObject in endObjects)
        {
            gameObject.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
