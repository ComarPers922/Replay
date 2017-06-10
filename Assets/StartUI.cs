using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
    public void LoadMainScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadReplayScene()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
