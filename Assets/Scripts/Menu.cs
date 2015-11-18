using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{
    public Canvas insMenu;
    public Button startButton;
    public Button exitButton;
    public Button insButton;

    public GUISkin skin;

    void OnGUI()
    {
       
        GUI.skin = skin;

		/*
		GUIStyle guiStyle = new GUIStyle ();

		guiStyle.normal.textColor = Color.yellow;
		guiStyle.fontSize = 30;

		GUI.Label(new Rect(320, 10, 600, 100), "Random Game Name",guiStyle);
        if (GUI.Button(new Rect(500, 50, 200, 100), "Start"))
        {
            Application.LoadLevel(0);

        }

        if (GUI.Button(new Rect(500, 120, 200, 100), "Quit"))
        {
            Application.Quit();
        }*/
    }

    // Use this for initialization
    void Start()
    {
        insMenu = insMenu.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        insButton = insButton.GetComponent<Button>();
        insMenu.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstructionPress()
    {
        insMenu.enabled = true;
        startButton.enabled = false;
        exitButton.enabled = false;
        insButton.enabled = false;
    }
    public void ContinuePress()
    {
        insMenu.enabled = false;
        startButton.enabled = true;
        exitButton.enabled = true;
        insButton.enabled = true;
    }

    public void ExitPress()
    {
        Application.Quit();
    }

    public void PlayPress()
    {
        Application.LoadLevel(1);
    }
}
