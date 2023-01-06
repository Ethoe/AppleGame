using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class apple_value : MonoBehaviour
{
    private int _value;
    public int applevalue
    {
        get { return _value; }
        set
        {
            if (text == null)
            {
                text = GetComponentInChildren<TextMeshProUGUI>();
            }
            text.text = value.ToString();
            _value = value;
        }
    }
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Scored()
    {
        Destroy(gameObject);
    }
}
