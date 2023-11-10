using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	public GameObject playMenuPanel;

	void Awake()
	{
		playMenuPanel.SetActive(true);
	}

	void Start()
	{
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
