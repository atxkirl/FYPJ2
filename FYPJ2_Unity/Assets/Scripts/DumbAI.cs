using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAI : MonoBehaviour {

    public GameObject player;
    private Vector3[] path;
    private FSMSystem sm;

    public void SetTransition(Transition t) { sm.PerformTransition(t); }

    // Use this for initialization
    void Start ()
    {
        path = new[] { new Vector3(transform.position.x - 10.0f, transform.position.y, transform.position.z + 10.0f), new Vector3(transform.position.x - 10.0f, transform.position.y, transform.position.z - 10f), new Vector3(transform.position.x + 10.0f, transform.position.y, transform.position.z - 10f), new Vector3(transform.position.x + 10.0f, transform.position.y, transform.position.z + 10f) };

        MakeFSM();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sm.CurrentState.Reason(player, gameObject);
        sm.CurrentState.Act(player, gameObject);
    }

    private void MakeFSM()
    {
        FollowPathState follow = new FollowPathState(path);
        follow.AddTransition(Transition.SawPlayer, StateID.ChasePlayer);

        ChasePlayerState chase = new ChasePlayerState();
        chase.AddTransition(Transition.LostPlayer, StateID.FollowPath);
        chase.AddTransition(Transition.NearPlayer, StateID.AttackPlayer);

        AttackPlayerState attack = new AttackPlayerState();
        attack.AddTransition(Transition.SawPlayer, StateID.ChasePlayer);

        sm = new FSMSystem();
        sm.AddState(follow);
        sm.AddState(chase);
        sm.AddState(attack);
    }
}

public class FollowPathState : FSMState
{
    private int currentWayPoint;
    private Vector3[] waypoints;

    public FollowPathState(Vector3[] wp)
    {
        waypoints = wp;
        currentWayPoint = 0;
        stateID = StateID.FollowPath;
    }

    public override void Act(GameObject player, GameObject npc)
    {
        const float moveSpeed = 10.0f;
        const float rotateSpeed = 2.5f;

        Vector3 vel = npc.GetComponent<Rigidbody>().velocity;

        Vector3 moveDir = waypoints[currentWayPoint] - npc.transform.position;

        if (moveDir.magnitude < 0.1)
        {
            currentWayPoint++;
            if (currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        else
        {
            vel = moveDir.normalized * moveSpeed;

            npc.transform.forward = Vector3.Lerp(npc.transform.forward, moveDir.normalized, rotateSpeed * Time.deltaTime);
        }

        npc.GetComponent<Rigidbody>().velocity = vel;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        RaycastHit hitInfo;
        Vector3 dir = (player.transform.position - npc.transform.position).normalized;
        if (Vector3.Distance(npc.transform.position, player.transform.position) < 100 && Physics.Raycast(npc.transform.position, dir, out hitInfo ))
        {
            float angle = Vector3.Angle(npc.transform.forward, player.transform.position);
            if (hitInfo.transform.tag == "Player" &&  angle < 30 && angle > -30)
                npc.GetComponent<DumbAI>().SetTransition(Transition.SawPlayer);
        }
    }
}

public class ChasePlayerState : FSMState
{
    public ChasePlayerState()
    {
        stateID = StateID.ChasePlayer;
    }

    public override void Act(GameObject player, GameObject npc)
    {
        const float moveSpeed = 10.0f;
        const float rotateSpeed = 2.5f;

        Vector3 moveDir = player.transform.position - npc.transform.position;

        Vector3 vel = moveDir.normalized * moveSpeed;

        npc.transform.forward = Vector3.Lerp(npc.transform.forward, moveDir.normalized, rotateSpeed * Time.deltaTime);

        npc.GetComponent<Rigidbody>().velocity = vel;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 10)
        {
            npc.GetComponent<DumbAI>().SetTransition(Transition.LostPlayer);
        }
        else if (Vector3.Distance(npc.transform.position, player.transform.position) < 2)
        {
            npc.GetComponent<DumbAI>().SetTransition(Transition.NearPlayer);
        }
    }
}

public class AttackPlayerState : FSMState
{
    const float rotateSpeed = 2.5f;
    private float damageValue = -1.0f;

    float attackDelay = 1.0f;
    float elapsedTime;

    public AttackPlayerState()
    {
        stateID = StateID.AttackPlayer;
    }

    public override void OnEnter()
    {
        elapsedTime = 0.0f;
    }

    public override void Act(GameObject player, GameObject npc)
    {

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= attackDelay)
        {
            //player.SendMessage("ModifyHp", damageValue);
            elapsedTime = 0.0f;
        }

        Vector3 moveDir = player.transform.position - npc.transform.position;

        npc.transform.forward = Vector3.Lerp(npc.transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 2)
        {
            npc.GetComponent<DumbAI>().SetTransition(Transition.SawPlayer);
        }
    }
}