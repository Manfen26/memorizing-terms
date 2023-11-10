using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
	public GameObject endGamePanel;
	public GameObject pauseGamePanel;

	int movesCount;

    // Start is called before the first frame update
    void Start()
    {
		endGamePanel.SetActive(false);
		pauseGamePanel.SetActive(false);
    }

	public void ActivateEndPanel()
	{
		endGamePanel.SetActive(true);
	}

	public void ActivatePausePanel()
	{
		pauseGamePanel.SetActive(true);
	}

	public void QuitToMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
