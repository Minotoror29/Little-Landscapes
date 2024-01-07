using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI value;

    public void Initialize(int score)
    {
        if (score > 0)
        {
            value.text = "+" + score.ToString();
        } else
        {
            value.text = score.ToString();
        }
    }
}
