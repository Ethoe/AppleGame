using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_game : MonoBehaviour
{
    public GameObject apple;
    public int winCon = 10;
    public int gameTime = 120;
    public timer timer;
    public score_keeper score;
    selected_dictionary selected_table;
    private float startTime;
    private GameObject[,] field;
    private int width = 17;
    private int height = 10;


    // Start is called before the first frame update
    void Start()
    {
        //Random.InitState(1111);
        startTime = Time.fixedTime;
        selected_table = GetComponent<selected_dictionary>();
        field = new GameObject[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject item = Instantiate(apple, new Vector3(0.9f * (i - (width / 2)) - .5f, 0.9f * (j - (height / 2)), 0), Quaternion.identity);
                field[i, j] = item;
                item.GetComponent<apple_value>().applevalue = Random.Range(1, 9);
            }
        }
    }

    public void Score(int count)
    {
        score.Scored(count);
    }

    // Update is called once per frame
    void Update()
    {
        float normalizedTime = (gameTime - (Time.fixedTime - startTime)) / gameTime;
        if (normalizedTime <= 0)
        {
            normalizedTime = 0;
        }
        timer.SetSize(normalizedTime);
    }
}
