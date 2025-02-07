﻿using Game.Scripts.PlayerModules.HealthModule;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Game.Scripts.EnemyLogic
{
	public class EnemyAi : MonoBehaviour
	{
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
		private bool _alreadyAttacked;
		[Inject]
		private HealthComponent _playerHealth;
		private bool _playerInSightRange, _playerInAttackRange;

		private Vector3 _walkPoint;
		private bool _walkPointSet;

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

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, _attackRange);
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, _sightRange);
		}

		private void Patroling()
		{
			if (!_walkPointSet)
				SearchWalkPoint();

			if (_walkPointSet)
				_agent.SetDestination(_walkPoint);

			var distanceToWalkPoint = transform.position - _walkPoint;

			if (distanceToWalkPoint.magnitude < 1f)
				_walkPointSet = false;
		}

		private void SearchWalkPoint()
		{
			var randomZ = Random.Range(-_walkPointRange, _walkPointRange);
			var randomX = Random.Range(-_walkPointRange, _walkPointRange);

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
			var rotation = transform.rotation;
			rotation = new Quaternion(0f,
				rotation.y,
				0f,
				rotation.w);

			transform.rotation = rotation;

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
	}
}