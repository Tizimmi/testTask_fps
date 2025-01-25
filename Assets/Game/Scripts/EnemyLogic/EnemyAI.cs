using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Game.Scripts.EnemyLogic
{
	public class EnemyAi : MonoBehaviour
	{
		public NavMeshAgent agent;

		public Transform player;
		
		[SerializeField]
		private LayerMask _whatIsGround;
		[SerializeField]
		private LayerMask _whatIsPlayer;

		//Patroling
		private Vector3 _walkPoint;
		private bool _walkPointSet;

		[SerializeField]
		private float _walkPointRange;

		//Attacking
		[SerializeField]
		private float _timeBetweenAttacks;

		private bool _alreadyAttacked;

		//States
		[SerializeField]
		private float _sightRange;
		[SerializeField]
		private float _attackRange;

		private bool _playerInSightRange, _playerInAttackRange;

		private void Awake()
		{
			agent = GetComponent<NavMeshAgent>();
		}

		private void Update()
		{
			//Check for sight and attack range
			_playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
			_playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);

			if (!_playerInSightRange && !_playerInAttackRange)
				Patroling();

			if (_playerInSightRange && !_playerInAttackRange)
				ChasePlayer();

			if (_playerInAttackRange && _playerInSightRange)
				AttackPlayer();
		}

		private void Patroling()
		{
			if (!_walkPointSet)
				SearchWalkPoint();

			if (_walkPointSet)
				agent.SetDestination(_walkPoint);

			Vector3 distanceToWalkPoint = transform.position - _walkPoint;

			//Walkpoint reached
			if (distanceToWalkPoint.magnitude < 1f)
				_walkPointSet = false;
		}

		private void SearchWalkPoint()
		{
			//Calculate random point in range
			float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
			float randomX = Random.Range(-_walkPointRange, _walkPointRange);

			_walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

			if (Physics.Raycast(_walkPoint,
					-transform.up,
					2f,
					_whatIsGround))
				_walkPointSet = true;
		}

		private void ChasePlayer()
		{
			agent.SetDestination(player.position);
		}

		private void AttackPlayer()
		{
			//Make sure enemy doesn't move
			agent.SetDestination(transform.position);

			transform.LookAt(player);

			if (!_alreadyAttacked)
			{
				///Attack code here
				///End of attack code

				_alreadyAttacked = true;
				Invoke(nameof(ResetAttack), _timeBetweenAttacks);
			}
		}

		private void ResetAttack()
		{
			_alreadyAttacked = false;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, _attackRange);
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, _sightRange);
		}
	}
}