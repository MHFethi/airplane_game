using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour
{

    public GameObject textDisplay;
    public static int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "Score " + scoreValue;
    }

    void Update()
    {
        textDisplay.GetComponent<Text>().text = "Score " + scoreValue;
    }
}
