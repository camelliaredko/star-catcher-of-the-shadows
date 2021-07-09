using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverScreen : MonoBehaviour
{
    public GameObject myPrefab;

    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void OnTriggerExit(Collider collision) {
        if(collision.CompareTag("Player"))
        {
            Destroy(myPrefab);
        }
    }
}
