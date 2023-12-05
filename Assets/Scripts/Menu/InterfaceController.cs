using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }
}
