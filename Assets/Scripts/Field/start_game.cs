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
    private bool gameInProgress;


    // Start is called before the first frame update
    void Start()
    {
        selected_table = GetComponent<selected_dictionary>();
        StartGame();
    }

    public void StartGameWithSeed(int seed)
    {
        Random.InitState(seed);
        StartGame();
    }

    public void StartGame()
    {
        startTime = Time.fixedTime;
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
        score.Restart();
        gameInProgress = true;
    }

    public void GameOver()
    {
        gameInProgress = false;
        for (int i = 0; i <= field.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= field.GetUpperBound(1); j++)
            {
                if (field[i, j] != null)
                {
                    Destroy(field[i, j]);
                }
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
        if (gameInProgress)
        {
            float normalizedTime = (gameTime - (Time.fixedTime - startTime)) / gameTime;
            if (normalizedTime <= 0)
            {
                normalizedTime = 0;
                GameOver();
            }
            timer.SetSize(normalizedTime);
        }
    }
}
