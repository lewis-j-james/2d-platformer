using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoints : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            anim.SetTrigger("Win");
            collision.gameObject.GetComponent<Checkpoint>().Activate();
        }
    }
}
