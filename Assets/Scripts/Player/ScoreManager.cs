using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    
    public TMP_Text scoreText;
    int _score;
    public AudioSource scoreFX;

    public GameObject player;
    public GameObject charModel;

    private void Start()
    {
        _score = 0;
        scoreText.text = _score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PassableGate")
        {
            scoreFX.Play();
            _score = _score + 10;
            scoreText.text = _score.ToString();
            PlayerMove.Instance.moveSpeed += 0.2f; // increase by 20%

            RandomGateColor gateScript = other.GetComponent<RandomGateColor>();
            if (gateScript != null)
            {
                Debug.Log("Passable gate found: " + other.gameObject.name);
                gateScript.DestroyGate();
            }
            else
            {
                Debug.LogError("RandomGateColor script not found on: " + other.gameObject.name);
                Destroy(other.gameObject); // As a fallback, destroy the object directly
            }
        }

        else
        {
            if (other.gameObject.tag == "BlockedGate")
            {
                this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                // Turn Off the player movement script from inspector before player collided
                player.GetComponent<PlayerMove>().enabled = false;
                Debug.Log("Blocked Gate Detected!!!");
                charModel.GetComponent<Animator>().Play("Stumble Backwards");
            }
        }
    }
}
