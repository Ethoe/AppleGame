using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_component : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().material.color = Color.black;
    }

    private void OnDestroy()
    {
        GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
