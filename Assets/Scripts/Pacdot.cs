using UnityEngine;
using System.Collections;
using System;

public class Pacdot : MonoBehaviour {

    public bool active = true;

	void OnTriggerEnter2D(Collider2D other)
	{
        if (!active)
            return;
		if(other.name == "pacman")
		{
			GameManager.score += 10;
            gameObject.tag = "deadpacdot";
            GameObject[] pacdots = GameObject.FindGameObjectsWithTag("pacdot");
            active = false;
            GetComponent<SpriteRenderer>().enabled = false;



            if (pacdots.Length == 1)
		    {
		        FindObjectOfType<GameGUINavigation>().LoadLevel();
		    }
		}
	}

    public void enable()
    {
        active = true;
        GetComponent<SpriteRenderer>().enabled = true;
        gameObject.tag = "pacdot";
    }
}
