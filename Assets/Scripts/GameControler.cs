using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _restartMenu;
    [SerializeField] private GameObject _panelControl;

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void StatGame()
    {
        _startMenu.SetActive(false);
        _panelControl.SetActive(true);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); 

    }
    public void StopGame()
    {
        _panelControl.SetActive(false);
        _restartMenu.SetActive(true);
    }
}
