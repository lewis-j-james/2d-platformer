using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Animator anim;

    private bool Dead = false;

    [SerializeField] private AudioSource deathSound;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Dead) return;
        if (transform.position.y < -9)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        Dead = true;
        anim.SetTrigger("Death");
        deathSound.Play();
    }

    private void RestartLevel()
    {
        GameManager.Instance.Restart();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
