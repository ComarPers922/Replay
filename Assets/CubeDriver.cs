using UnityEngine;

public class CubeDriver : MonoBehaviour
{
    [SerializeField,Range(5,20)]
    private float Speed = 5;

    private Vector3 Velocity;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Velocity * Speed * Time.deltaTime);
	}

    public void SetVelocity(Vector3 velocity)
    {
        Velocity = velocity.normalized;
    }
}
