﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public int Damage = 1;
	public Hurtable.Faction Faction;
	public Vector3 Offset;
	private const float LIFESPAN = 0.3f;

	void Awake()
	{
		StartCoroutine(DelayDestroy());
	}

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(LIFESPAN);
		Destroy(gameObject);
	}
}
