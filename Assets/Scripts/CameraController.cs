using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D target;

    private void FixedUpdate()
    {
        transform.position = (Vector3)Vector2.Lerp(transform.position, target.position + target.velocity / 20f, 1f - Mathf.Pow(0.05f, Time.deltaTime)) + new Vector3(0, 0, -10);
    }
}
