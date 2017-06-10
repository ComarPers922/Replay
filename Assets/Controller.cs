using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;

public struct ActionData
{
    public float Time;
    public Vector3 Velocity;
    public ActionData(float time,Vector3 velocity)
    {
        Time = time;
        Velocity = velocity;
    }
}

public class Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject Cube;
    private Queue<ActionData> Actions = new Queue<ActionData>();
    private int GameTime = 0;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool IsGottenInput = false;
        Vector3 ResultVelocity = Vector3.zero;
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            ResultVelocity += new Vector3(0,0,1);
            IsGottenInput = true;
        }
        else if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            ResultVelocity += new Vector3(0, 0, -1);
            IsGottenInput = true;
        }
        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            ResultVelocity += new Vector3(-1, 0, 0);
            IsGottenInput = true;
        }
        else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            ResultVelocity += new Vector3(1, 0, 0);
            IsGottenInput = true;
        }
        if (IsGottenInput)
        {
            Actions.Enqueue(new ActionData(GameTime, ResultVelocity));
        }
        Cube.GetComponent<CubeDriver>().SetVelocity(ResultVelocity);
        GameTime += 1;
    }

    public void SaveAndBack()
    {
        StringBuilder builder = new StringBuilder();
        foreach (var item in Actions)
        {
            builder.AppendFormat("{0} {1} {2} {3}\n", item.Time, item.Velocity.x, item.Velocity.y, item.Velocity.z);
        }
        File.WriteAllText(Application.streamingAssetsPath + "/save.dat",builder.ToString());
        SceneManager.LoadSceneAsync(0);
    }
}
