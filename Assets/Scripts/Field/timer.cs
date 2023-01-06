using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    Transform bar;
    Transform appleCat;
    SpriteRenderer barSprite;
    float timerWidth;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        appleCat = transform.Find("AppleCat");
        barSprite = bar.GetComponentInChildren<SpriteRenderer>();
    }

    public void SetSize(float sizeNormalized)
    {
        timerWidth = barSprite.sprite.bounds.size.x * barSprite.transform.lossyScale.x;
        appleCat.localPosition = new Vector2(barSprite.transform.position.x - (timerWidth / 2), bar.transform.localPosition.y);
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
