using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance { set; get; }

	public GameObject mainMenu;

	private void Start () 
	{
		Instance = this;
		
		DontDestroyOnLoad (gameObject);
	}
	

	public void StartGame()
	{
		SceneManager.LoadScene ("Game");
	}
}