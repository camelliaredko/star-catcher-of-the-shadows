using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;

    private Vector2 mousePos;

    private void Start()
    {
        particles.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            particles.SetActive(false);
            particles.SetActive(true);
            particles.transform.position = new Vector3(mousePos.x, mousePos.y, 0f); ;
        }
        if (Input.GetMouseButtonDown(1))
        {
            particles.SetActive(false);
        }
    }
}
