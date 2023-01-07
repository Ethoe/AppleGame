using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_keeper : MonoBehaviour
{
    int score;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = score.ToString();
    }

    public void Scored(int count)
    {
        score += count;
        text.text = score.ToString();
    }

    public void Restart()
    {
        score = 0;
        text.text = score.ToString();
    }
}
