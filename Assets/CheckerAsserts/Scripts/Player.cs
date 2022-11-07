using UnityEngine;
using System;
using System.IO;

using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	public string playerName;
	public bool isHost;

	
	public List<GamePlayer> players = new List<GamePlayer>();

	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		GamePlayer p1 = new GamePlayer();
		p1.name = name;
		players.Add(p1);

		GamePlayer p2 = new GamePlayer();
		p2.name = name;
		players.Add(p2);

		GameManager.Instance.StartGame();
	}


	private void Update()
	{
		
	}

}

public class GamePlayer
{
	public string name;
	public bool isHost;
}