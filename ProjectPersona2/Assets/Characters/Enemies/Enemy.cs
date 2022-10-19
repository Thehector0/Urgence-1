using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform targetDestination;
	GameObject targetGameObject;
	Health TargetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rb;


	[SerializeField] int hp = 4;
	[SerializeField] int damage = 1;


	private void Awake()
	{
		rb = GetComponent <Rigidbody2D>();
	}

	public void SetTarget(GameObject target) 
	{
		targetGameObject = target;
		targetDestination = target.transform;
	}

	private void FixedUpdate()
	{
		Vector3 direction = (targetDestination.position - transform.position).normalized;
		rb.velocity = direction * speed;
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject == targetGameObject)
		{
			Attack();
		}
	}
	private void Attack()
	{
		if (TargetCharacter == null)
		{
			TargetCharacter = targetGameObject.GetComponent<Health>();
		}
		TargetCharacter.TakeDamage(damage);
	}

	public void TakeDamage(int damage) 
	{
		hp -= damage;

		if (hp < 1)
		{
			Destroy(gameObject);
		}
	}

}