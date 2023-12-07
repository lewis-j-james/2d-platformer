using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Melons = 0;
    private int CurrentMelons = 0;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void GoToLevel(string scene)
    {
        CurrentMelons = Melons;
        SceneManager.LoadScene(scene);
    }

    public void Restart()
    {
        Melons = CurrentMelons;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
