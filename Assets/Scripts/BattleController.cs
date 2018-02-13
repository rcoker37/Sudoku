﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

	public GameObject Player;
	public GameObject Pause;
	public GameObject Tower1;
	public GameObject Tower2;
	public GameObject Tower3;
	public GameObject Tower4;
	public GameObject Tower5;
	public GameObject Tower6;
	public GameObject Tower7;
	public GameObject Tower8;
	public GameObject Tower9;

	private GameObject[] towers;

	private SudokuController sudoku;
	private bool paused = false;
	
	public void InitializeGame(SquareController square, SudokuController sudoku)
	{
		GameObject[] towers = {
			Tower1, 
			Tower2, 
			Tower3,
			Tower4,
			Tower5,
			Tower6,
			Tower7,
			Tower8,
			Tower9
		};

		this.towers = towers;

		this.sudoku = sudoku;
		for (int i = 0; i < 9; i++)
		{
			if (!square.notes[i])
			{
				Destroy(towers[i]);
			}
		}
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;
			Pause.SetActive(paused);
			if (paused)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}

	public void DestroyTower(GameObject tower)
	{
		Destroy(tower);
		//TODO: Fix
		if (true || GameObject.FindGameObjectsWithTag("Tower").Length == 0)
		{
			Win();
		}
	}

	public void Win()
	{
		sudoku.gameObject.transform.parent.gameObject.SetActive(true);
		sudoku.SetCorrectNumber();
		sudoku.ReturnToNormal(this);
	}

	public void Lose()
	{
		sudoku.gameObject.transform.parent.gameObject.SetActive(true);
		sudoku.SetLostBattle();
		sudoku.ReturnToNormal(this);
	}
}
