using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	public string playerName;
	public bool isHost;

	private bool socketReady;
	private TcpClient socket;
	private NetworkStream stream;
	private StreamWriter writer;
	private StreamReader reader;

	public List<GamePlayer> players = new List<GamePlayer>();

	private void Start()
	{
		DontDestroyOnLoad(gameObject);
	}



	private void Update()
	{
		if (socketReady)
		{
			if (stream.DataAvailable)
			{
				string data = reader.ReadLine();
				if (data != null)
					OnIncomingData(data);
			}
		}
	}



	// Read messages from the server
	private void OnIncomingData (string data)
	{
		Debug.Log ("Client: " + data);
		string[] aData = data.Split('|');

		switch (aData[0])
		{
			case "SWHO":
			 	for (int i = 1; i < aData.Length - 1; i++)
				 {
					 UserConnected(aData[i], false);
				 }
				 Send("CWHO|" + clientName + "|" + ((isHost) ? 1 : 0).ToString());
				break;

			case "SCNN":
				UserConnected(aData[1], false);
				break;

			case "SMOV":
				CheckerBoard.Instance.TryMove(int.Parse(aData[1]), int.Parse(aData[2]), int.Parse(aData[3]), int.Parse(aData[4]));
				break;
		}
	}

	private void UserConnected(string name, bool host)
	{
		GameClient gc = new GameClient();
		gc.name = name;

		players.Add(gc);

		if (players.Count == 2)
			GameManager.Instance.StartGame();
	}

}

public class GamePlayer
{
	public string name;
	public bool isHost;
}