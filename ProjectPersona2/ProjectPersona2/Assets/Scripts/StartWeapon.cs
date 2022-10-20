using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWeapon : WeaponBase
{
   [SerializeField] GameObject leftWhipObject;
   [SerializeField] GameObject rightWhipObject;

	PlayerController playerController;
	[SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

	private void Awake()
	{
		playerController = GetComponentInParent<PlayerController>();
	}

	private void ApplyDamage(Collider2D[] colliders) 
	{
		for (int i = 0; i < colliders.Length; i++)
		{
			Enemy e = colliders[i].GetComponent<Enemy>();
			if (e != null)
			{
				e.TakeDamage(weaponStats.damage);
			}
		}
	}

	public override void Attack()
	{
		if (playerController.lastHorizonVector > 0)
		{
			rightWhipObject.SetActive(true);
			Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
			ApplyDamage(colliders);
		}
		else
		{
			leftWhipObject.SetActive(true);
			Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
			ApplyDamage(colliders);
		}
	}
}	
