using UnityEngine;
using MLAgents;

public class PacmanAgent: Agent
{
    public PlayerController pc;
    public GameManager gm;



    public override void CollectObservations()
    {
        SetReward((float)GameManager.score / 10000f);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        Debug.Log(vectorAction[0]);
        Debug.Log(vectorAction.Length);

        switch (vectorAction[0])
        {
            case 0:
                break;
            case 1:
                pc._nextDir = Vector2.up;
                break;
            case 2:
                pc._nextDir = -Vector2.up;
                break;
            case 3:
                pc._nextDir = -Vector2.right;
                break;
            case 4:
                pc._nextDir = Vector2.right;
                break;

        }
    }

    public override void AgentReset()
    {
    }

    public override void AgentOnDone()
    {
    }
}
