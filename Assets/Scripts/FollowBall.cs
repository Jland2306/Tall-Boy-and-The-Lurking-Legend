using UnityEngine;
using UnityEngine.UIElements;

public class FollowBall : MonoBehaviour
{

    public GameObject objectToFollow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, -500);
    }
}
