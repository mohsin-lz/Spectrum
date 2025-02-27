using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject charModel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        // Turn Off the player movement script from inspector before player collided
        player.GetComponent<PlayerMove>().enabled = false;
        
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
    }
}
