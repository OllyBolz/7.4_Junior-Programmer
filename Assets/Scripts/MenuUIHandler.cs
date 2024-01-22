using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker colorPicker;

    public void NewColorSelected(Color color)
    {
        MainManager.mainManager.TeamColor = color;
		colorPicker.SelectColor(color);
	}

    
    private void Start()
    {
		//colorPicker = GameObject.Find("/Canvas/Container/StartContainer/ColorPicker").GetComponent<ColorPicker>();

		colorPicker.Init();
		colorPicker.SelectColor(MainManager.mainManager.TeamColor);
		colorPicker.onColorChanged += NewColorSelected;
	}

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManager.mainManager.SaveColor();
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
	}

    public void SaveColorClicked()
    {
		MainManager.mainManager.SaveColor();
	}

    public void LoadColorClicked() 
    {
		MainManager.mainManager.LoadColor();
		colorPicker.SelectColor(MainManager.mainManager.TeamColor);
	}
}

