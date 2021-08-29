using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    int state = 0;
    int tempCount = 0;
    public void changeState(int orderState)
    {
        state = orderState;
        Debug.Log(state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerCharacter>() != null)
        {
            GameMode.instance.ScoreUp();
        }
    }

    void Update()
    {
        if (state == 1)
        {
            if (tempCount == 0)
            {
                //transform.position = new Vector2(transform.position.x + 0, transform.position.y + 1f);
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + 0, transform.position.y + 0.5f), Time.deltaTime * 5f);
                tempCount++;
            }
            else if(tempCount == 60)
            {
                //transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + 0, transform.position.y - 2f), Time.deltaTime * 2f);
                tempCount = 0;
            }
            else
            {
                tempCount++;
            }
        }
    }
}
