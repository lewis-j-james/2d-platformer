using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public string NextScene;

    private bool Activated = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Activate()
    {
        if (Activated) return;
        Activated = true;
        Debug.Log("Activated");
        anim.SetTrigger("Activate");
    }

    public void Win()
    {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene(NextScene);
    }
}
