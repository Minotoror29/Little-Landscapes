using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void Initialize(int score)
    {
        if (score > 0)
        {
            scoreText.text = "+" + score;
        } else
        {
            scoreText.text = score.ToString();
        }
    }
}
