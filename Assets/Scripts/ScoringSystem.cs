using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static int score;

    // Start is called before the first frame update
    void Update()
    {
        scoreText.GetComponent<Text>().text = score + "/10";
    }
}
