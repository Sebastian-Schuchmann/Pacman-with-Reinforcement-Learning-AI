using UnityEngine;
using MLAgents;

public class PacmanAgent: Agent
{
    public PlayerController pc;
    public GameManager gm;

    public GhostMove ghost0;
    public GhostMove ghost1;
    public GhostMove ghost2;
    public GhostMove ghost3;



    public override void CollectObservations()
    {
        SetReward((float)GameManager.score / 1000000f);

        AddVectorObs(ghost0.direction);
        AddVectorObs(ghost1.direction);
        AddVectorObs(ghost2.direction);
        AddVectorObs(ghost3.direction);

        AddVectorObs(gm._timeToCalm);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {

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
