using System.Collections;
using System.Collections.Generic;
using Game;
using dotmob;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletePanel : ShowHidable
{
    [SerializeField] private Text _toastTxt;
    [SerializeField] private Text _levelTxt;
    [SerializeField]private List<string> _toasts = new List<string>();

    public bool isNeedLevel = false;

    private void Awake()
    {
        if(isNeedLevel)
            _levelTxt.text = $" Level {LevelManager.Instance.Level.no}"; 
    }

    protected override void OnShowCompleted()
    {
        base.OnShowCompleted();
        _toastTxt.text = _toasts.GetRandom();
        _toastTxt.gameObject.SetActive(true);
        MyLevelManager.Instance.TakeScreenShot();
    }


    public void OnClickContinue()
    {
        UIManager.Instance.LoadNextLevel();
    }

    public void OnClickMainMenu()
    {
        GameManager.LoadScene("MainMenu");
        SharedUIManager.PausePanel.Hide();
    }
}