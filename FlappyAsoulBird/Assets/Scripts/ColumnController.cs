using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{   
    GameObject[] columns;
    int currentColumn = 0;
    //create relative column
    int previousColumn;

    public GameObject columnPrefab;
    public GameObject Player;
    public int columnMax = 9;
    public float spawnRate = 10f;
    public float yMin = -2f;
    public float yMax = 3.5f;
    public float xPos = 5f;
    public float xPosStart = 20f;
    public float xPosGap = 5f;
    float timeSinceLastSpawned;
    float totalTime;
    Vector2 originalPos;


    void Start()
    {
        totalTime = 0f;
        columns = new GameObject[columnMax];
        
        for(int i=0;i<columnMax;i++)
        {
            originalPos = new Vector2(xPosStart+i*xPosGap, Random.Range(yMin, yMax));
            columns[i] = Instantiate(columnPrefab, originalPos, Quaternion.identity);
        }
    }
    

    void Update()
    {
        if (GameMode.instance.gameOver == false)
        {
            if (columns[currentColumn].transform.position.x < Player.transform.position.x+11f)
            {
                ColumnReuse();
            }
        }
    }

    void ColumnReuse()
    {
        previousColumn = currentColumn - 1;
        if (previousColumn == -1)
        {
            previousColumn = columnMax - 1;
        }


        float yPos = Random.Range(yMin, yMax);
        columns[currentColumn].transform.position = new Vector2(columns[previousColumn].transform.position.x + xPosGap + BeHard(totalTime), yPos);


        currentColumn++;
        if (currentColumn >= columnMax)
        {
            currentColumn = 0;
        }
    }

    float BeHard(float totalTime)
    {
        float temp = totalTime / spawnRate / 10;
        if (temp > xPosGap - 1)
            return -xPosGap + 1;
        else
            return -temp;
    }

    public void BellaSkill()
    {
        for(int i=0;i<2;i++)
            ColumnReuse();
    }

    public void CarolSkill()
    {
        foreach (GameObject column in columns)
        {
            column.transform.position= new Vector2(column.transform.position.x,1.2f - column.transform.position.y);
        }
    }
}
