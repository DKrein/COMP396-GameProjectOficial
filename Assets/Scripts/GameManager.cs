using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int currentScore;
    public int highScore;
    public int currentLevel = 0;
    public int unlockedLevel;

    public GameObject keyParent;
    public GameObject deathParent;
    public int keyCount;
    public int deathCount;
    private int totalKeyCount;

    public GUISkin skin;

	// Use this for initialization
	void Start () {

        totalKeyCount = keyParent.transform.childCount;
        DontDestroyOnLoad(gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CompleteLevel()
    {
        currentLevel += 1;
        Application.LoadLevel(currentLevel);
        
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(20, 20, 200, 200), "Keys Collect: " + keyCount.ToString() + "/" + totalKeyCount.ToString());
        GUI.Label(new Rect(20, 40, 200, 200), "Deaths: " + deathCount.ToString());
    }
}
