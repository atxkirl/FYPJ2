using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject player;
	public List<string> NPCDialogue;

	private Vector3 path;
    private FSMSystem sm;

    private bool interacting = false;

    public void SetTransition(Transition t) { sm.PerformTransition(t); }

    // Use this for initialization
    void Start()
    {
        path = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z + Random.Range(-10, 10));

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
        MovementState movement = new MovementState(path);
        movement.AddTransition(Transition.NearNPC, StateID.TrackNPC);
        movement.AddTransition(Transition.AngryNPC, StateID.AggroNPC);


        PlayerNearState track = new PlayerNearState();
        track.AddTransition(Transition.RoamNPC, StateID.MovementNPC);
        track.AddTransition(Transition.InteractNPC, StateID.InteractionNPC);
		track.AddDialogue(NPCDialogue);

        InteractionState interact = new InteractionState();
        interact.AddTransition(Transition.NearNPC, StateID.TrackNPC);

        AggroState aggro = new AggroState();
        aggro.AddTransition(Transition.RoamNPC, StateID.MovementNPC);
        aggro.AddTransition(Transition.AttackNPC, StateID.DamageNPC);

        AttackState attack = new AttackState();
        attack.AddTransition(Transition.AngryNPC, StateID.AggroNPC);


        sm = new FSMSystem();
        sm.AddState(movement);
        sm.AddState(track);
        sm.AddState(interact);
        sm.AddState(aggro);
        sm.AddState(attack);
    }

    private void ChangeInteracting(bool interaction)
    {
        interacting = interaction;
    }

    public bool GetInteracting()
    {
        return interacting;
    }
}

public class MovementState : FSMState
{
    private Vector3 path;

    public MovementState(Vector3 wp)
    {
        path = wp;
        stateID = StateID.MovementNPC;
    }

    public override void Act(GameObject player, GameObject npc)
    {
        const float moveSpeed = 1.0f;
        const float rotateSpeed = 2.5f;

        Vector3 vel = npc.GetComponent<Rigidbody>().velocity;

        Vector3 moveDir = path - npc.transform.position;

        RaycastHit hitInfo;

        if (moveDir.magnitude < 0.1 || (Physics.Raycast(npc.transform.position, moveDir, out hitInfo) && hitInfo.transform.tag != "Player"))
        {
            path = new Vector3(npc.transform.position.x + Random.Range(-10, 10), npc.transform.position.y, npc.transform.position.z + Random.Range(-10, 10));
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
        if (Vector3.Distance(npc.transform.position, player.transform.position) < 10)
        {
            npc.GetComponent<NPC>().SetTransition(Transition.NearNPC);
        }
    }
}

public class PlayerNearState : FSMState
{
	List<string> npcDialogue;

    public PlayerNearState()
    {
        stateID = StateID.TrackNPC;
    }

	public void AddDialogue(List<string> dialogue)
	{
		npcDialogue = new List<string>();
		npcDialogue = dialogue;
	}

	public override void Act(GameObject player, GameObject npc)
    {
        const float rotateSpeed = 2.5f;

        npc.GetComponent<Rigidbody>().velocity.Set(0, 0, 0);

        Vector3 moveDir = player.transform.position - npc.transform.position;

        npc.transform.forward = Vector3.Lerp(npc.transform.forward, moveDir.normalized, rotateSpeed * Time.deltaTime);
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 10)
            npc.GetComponent<NPC>().SetTransition(Transition.RoamNPC);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            npc.GetComponent<NPC>().SendMessage("ChangeInteracting", true);
            npc.GetComponent<NPC>().SetTransition(Transition.InteractNPC);

            //string[] test = { "TDJ buay song", "Daniel worst student SIDM", "Victor Wee no reply email" };
            //DialogueManager.instance.SendMessage("ShowDialogue", test);
            //DialogueManager.instance.SendMessage("AttachNPC", npc);

			DialogueManager.instance.SendMessage("ShowDialogue", npcDialogue);
			DialogueManager.instance.SendMessage("AttachNPC", npc);
		}
    }
}

public class InteractionState : FSMState
{
    public InteractionState()
    {
        stateID = StateID.InteractionNPC;
    }
    public override void Act(GameObject player, GameObject npc)
    {
        //const float moveSpeed = 1.0f;
        //const float rotateSpeed = 2.5f;

        //Vector3 moveDir = player.transform.position - npc.transform.position;

        //Vector3 vel = moveDir.normalized * moveSpeed;

        //npc.transform.forward = Vector3.Lerp(npc.transform.forward, moveDir.normalized, rotateSpeed * Time.deltaTime);

        //npc.GetComponent<Rigidbody>().velocity = vel;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if (!npc.GetComponent<NPC>().GetInteracting())
        {
            npc.GetComponent<NPC>().SetTransition(Transition.NearNPC);
        }
    }
}

public class AggroState : FSMState
{
    public AggroState()
    {
        stateID = StateID.AggroNPC;
    }
    public override void Act(GameObject player, GameObject npc)
    {
        const float moveSpeed = 1.0f;
        const float rotateSpeed = 2.5f;

        Vector3 moveDir = player.transform.position - npc.transform.position;

        Vector3 vel = moveDir.normalized * moveSpeed;

        npc.transform.forward = Vector3.Lerp(npc.transform.forward, moveDir.normalized, rotateSpeed * Time.deltaTime);

        npc.GetComponent<Rigidbody>().velocity = vel;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 100)
        {
            npc.GetComponent<NPC>().SetTransition(Transition.RoamNPC);
        }
        else if (Vector3.Distance(npc.transform.position, player.transform.position) < 10)
        {
            npc.GetComponent<NPC>().SetTransition(Transition.AttackNPC);
        }
    }
}

public class AttackState : FSMState
{
    const float rotateSpeed = 2.5f;
    private float damageValue = -1.0f;

    float attackDelay = 1.0f;
    float elapsedTime;

    public AttackState()
    {
        stateID = StateID.DamageNPC;
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
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 10)
        {
            npc.GetComponent<NPC>().SetTransition(Transition.SawPlayer);
        }
    }
}
