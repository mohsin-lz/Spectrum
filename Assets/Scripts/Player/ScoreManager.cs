using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    int _score;
    int _finalScore;
    public AudioSource scoreFX;
    public AudioSource collideFX;

    public GameObject player;
    public GameObject charModel;

    public GameObject mainCamera;
    public GameObject levelLoader;


    private void Start()
    {
        _score = 0;
        _finalScore = 0;
        scoreText.text = _score.ToString();
        finalScoreText.text = _finalScore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PassableGate")
        {
            scoreFX.Play();
            _score = _score + 10;
            scoreText.text = _score.ToString();

            _finalScore = _finalScore + 10;
            finalScoreText.text = _finalScore.ToString();

            PlayerMove.Instance.moveSpeed += 0.2f; // increase by 20%
            PlayerMove.Instance.leftRightSpeed += 0.2f;

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
                collideFX.Play();
                levelLoader.GetComponent<LevelLoader>().enabled = false;
                this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                // Turn Off the player movement script from inspector before player collided
                player.GetComponent<PlayerMove>().enabled = false;
                Debug.Log("Blocked Gate Detected!!!");
                charModel.GetComponent<Animator>().Play("Stumble Backwards");
                mainCamera.GetComponent<Animator>().enabled = true;
                levelLoader.GetComponent<GameOver>().enabled = true;
                
            }
        }
    }
}
