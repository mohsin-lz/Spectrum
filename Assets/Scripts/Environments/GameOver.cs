using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject liveScoreGO;
    public GameObject liveDistanceGO;
    public GameObject gameOverScreen;
    public GameObject fadeOut;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(gameOverSequence());
    }

    IEnumerator gameOverSequence()
    {
        yield return new WaitForSeconds(5);
        liveScoreGO.SetActive(false);
        liveDistanceGO.SetActive(false);
        gameOverScreen.SetActive(true);

        yield return new WaitForSeconds(5);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
