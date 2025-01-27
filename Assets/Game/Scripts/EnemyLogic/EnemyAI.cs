using Game.Scripts.PlayerModules.HealthModule;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Game.Scripts.EnemyLogic
{
	public class EnemyAi : MonoBehaviour
	{
		[Inject]
		private HealthComponent _playerHealth;

		[SerializeField]
		private NavMeshAgent _agent;
		[SerializeField]
		private Transform _player;
		[SerializeField]
		private LayerMask _whatIsGround;
		[SerializeField]
		private LayerMask _whatIsPlayer;
		[SerializeField]
		private float _walkPointRange;
		[SerializeField]
		private float _sightRange;
		[SerializeField]
		private float _attackRange;
		[SerializeField]
		private int _attackDamage;
		[SerializeField]
		private float _timeBetweenAttacks;

		private Vector3 _walkPoint;
		private bool _walkPointSet;
		private bool _alreadyAttacked;
		private bool _playerInSightRange, _playerInAttackRange;

		private void Awake()
		{
			_agent = GetComponent<NavMeshAgent>();
		}

		private void Update()
		{
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
				_agent.SetDestination(_walkPoint);

			Vector3 distanceToWalkPoint = transform.position - _walkPoint;

			if (distanceToWalkPoint.magnitude < 1f)
				_walkPointSet = false;
		}

		private void SearchWalkPoint()
		{
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
			_agent.SetDestination(_player.position);
		}

		private void AttackPlayer()
		{
			_agent.SetDestination(transform.position);

			transform.LookAt(_player);

			if (!_alreadyAttacked)
			{
				_playerHealth.TakeDamage(_attackDamage);

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