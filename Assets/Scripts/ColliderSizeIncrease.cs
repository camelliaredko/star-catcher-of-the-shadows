using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSizeIncrease : MonoBehaviour
{
    [SerializeField]
    private GameObject collider;
    private Vector2 mousePos;
    private Vector3 scaleChange, positionChange;
    private Vector3 originalScale;

    private void Start()
    {
        collider.SetActive(false);
        originalScale = transform.localScale;
        scaleChange = new Vector3(0.0f, 0.0035f, 0.0f);
        positionChange = new Vector3(0.0f, 0.0026f, 0.0f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            collider.SetActive(false);
            collider.SetActive(true);
            collider.transform.localScale = originalScale;
            collider.transform.position = new Vector3(mousePos.x, mousePos.y - 1.5f, 0f); ;
        }
        if (Input.GetMouseButtonDown(1))
        {
            collider.SetActive(false);
        }
        collider.transform.localScale += scaleChange;
        collider.transform.position += positionChange;
    }
}