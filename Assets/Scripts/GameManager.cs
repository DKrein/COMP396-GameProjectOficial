using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public int currentScore;
    //public int highScore;
    static int currentLevel = 1;
    public int unlockedLevel;

    public GameObject deathParent;
    public static int keyCount = 0;
    public static int totalKeyCount = 0;
    public static int numPlayerInExit;
    public static GameObject[] players;  

    public GUISkin skin;
    public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        if (currentLevel != 1)
        {
            Network.Instantiate(playerPrefab, new Vector3(20f, .5f, -22f), Quaternion.identity, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        players = GameObject.FindGameObjectsWithTag("Player");
	}

    public void CompleteLevel()
    {
        currentLevel += 1;
        Application.LoadLevel(currentLevel);
       // NetworkLevelLoader.Instance.LoadLevel("Level 2", currentLevel);
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(20, 20, 200, 200), "Total Keys Collect: " + keyCount.ToString() + "/" + totalKeyCount.ToString());
    }
}
