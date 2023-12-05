using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWind : MonoBehaviour
{
    private WindRegion wind;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            wind = collision.GetComponent<WindRegion>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wind"))
        {
            wind = null;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!wind) return;
        rb.velocity += wind.Force * Time.deltaTime;
    }
}
