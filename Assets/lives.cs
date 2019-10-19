using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lives : MonoBehaviour
{
    public GameObject[] livesUI;

    public void SetLives(int amount)
    {
        foreach(var live in livesUI)
        {
            live.SetActive(false);
        }

        for(int i=0; i< amount; i++)
        {
            livesUI[i].SetActive(true);
        }

    }
}
