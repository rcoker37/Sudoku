﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hurtable : MonoBehaviour {

	public enum Faction
	{
		GOOD,
		BAD
	}

	public Material NormalMaterial;
	public Material HurtMaterial;

	public Faction faction;
	protected int health;
	protected SpriteRenderer sr;

	private bool hurt = false;

	private const float HURT_TIME = 0.4f;

	protected virtual void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	public virtual void Damage(int damage)
	{
		if (!hurt)
		{
			health -= damage;
			if (health <= 0)
			{
				Die();
			}
			hurt = true;
			sr.material = HurtMaterial;
			StartCoroutine(HurtTime());
		}
	}

	private IEnumerator HurtTime()
	{
		yield return new WaitForSeconds(HURT_TIME);
		hurt = false;
		sr.material = NormalMaterial;
	}

	protected abstract void Die();
}
