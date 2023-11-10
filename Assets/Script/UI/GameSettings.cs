using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private LevelSettings _levelSettings = null;

    public void SetDifficult(int difficulty)
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    public void SetTheme(string name)
    {
        _levelSettings.ThemeName = name;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
