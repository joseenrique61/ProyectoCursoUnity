using UnityEngine;
using UnityEngine.AI;

public class PlayerFollower : MonoBehaviour
{
	private NavMeshAgent NavMeshAgent;
	private Transform Player;

	public float distanceToPlayer;

	void Start()
	{
		NavMeshAgent = GetComponent<NavMeshAgent>();
		Player = GameObject.FindWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 direction = Player.position - transform.position;
		Vector2 dest = new Vector2(Player.position.x, Player.position.y) - distanceToPlayer *  direction.normalized;
		NavMeshAgent.SetDestination(dest);
	}
}
