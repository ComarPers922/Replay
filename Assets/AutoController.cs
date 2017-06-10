using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoController : MonoBehaviour
{
    [SerializeField]
    private GameObject Cube;
    [SerializeField]
    private GameObject Label;
    private Queue<ActionData> Actions = new Queue<ActionData>();

    private int GameTime = 0;
    // Use this for initialization
    void Start ()
    {
        var Data = File.ReadAllText(Application.streamingAssetsPath + "/save.dat");
        var DataLines = Data.Split('\n');
        foreach (var item in DataLines)
        {
            if(string.IsNullOrEmpty(item.Trim()))
            {
                continue;
            }
            var SingleAction = item.Split(' ');
            Actions.Enqueue(new ActionData(Convert.ToSingle(SingleAction[0]),
                new Vector3(
                    Convert.ToSingle(SingleAction[1]),
                    Convert.ToSingle(SingleAction[2]),
                    Convert.ToSingle(SingleAction[3]))));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Actions.Count != 0 && GameTime == Actions.Peek().Time)
        {
            var ActionThisTime = Actions.Dequeue();
            Cube.GetComponent<CubeDriver>().SetVelocity(ActionThisTime.Velocity);
        }
        else if(Actions.Count == 0)
        {
            Label.SetActive(true);
            Cube.GetComponent<CubeDriver>().SetVelocity(Vector3.zero);
            Debug.Log("Replay Complete!");
        }
        GameTime += 1;
	}
    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
