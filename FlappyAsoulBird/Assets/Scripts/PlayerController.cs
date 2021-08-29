using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {   if (!character.isAlive) return;
        if (Input.GetMouseButtonDown(0))
        {
            character.Up();
        }
    }
}
