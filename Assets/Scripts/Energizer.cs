using UnityEngine;
using System.Collections;

public class Energizer : MonoBehaviour {

    public bool active = true;

    private GameManager gm;

	// Use this for initialization
	void Start ()
	{
	    gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if( gm == null )    Debug.Log("Energizer did not find Game Manager!");
	}

    void OnTriggerEnter2D(Collider2D col)
    {
//        Debug.Log("Trigger");
          if (!active)
            return;
   
          

        if(col.name == "pacman")
        {
                //    Debug.Log("Trigger PAC");

                     
                    gameObject.tag = "deadpacdot";
            active = false;
            GetComponent<SpriteRenderer>().enabled = false;


            gm.ScareGhosts();


        }
    }


    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Trigger");
          if (!active)
            return;
   
          

        if(col.name == "pacman")
        {
                    Debug.Log("Trigger PAC");

                     
                    gameObject.tag = "deadpacdot";
            active = false;
            GetComponent<SpriteRenderer>().enabled = false;


            gm.ScareGhosts();


        }
    }

        public void enable()
    {
        active = true;
        GetComponent<SpriteRenderer>().enabled = true;
        gameObject.tag = "pacdot";
    }
}
