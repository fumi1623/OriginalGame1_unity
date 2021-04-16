using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "score : " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
