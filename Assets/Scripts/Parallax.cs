using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private new Transform camera;

    [SerializeField] private float parallaxDistance;

    private Vector2 pos;

    private void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        transform.position = (Vector3)pos + new Vector3(camera.position.x * parallaxDistance, camera.position.y * parallaxDistance, transform.position.z);
    }
}
