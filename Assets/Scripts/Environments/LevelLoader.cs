/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGO;
    public GameObject fadeIn;

    public GameObject scoreGO;
    public GameObject distanceGO;

    public AudioSource readyFX;
    public AudioSource goFX;

    public TMP_Text disDisplay;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.35f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(countSequence());
    }



    void Update()
    {
        if (addingDis == false)
        {
            if (distanceGO.activeSelf == true)
            {
                addingDis = true;
                StartCoroutine(AddingDis());
            }
            
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.text = disRun.ToString() + "m";
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
    IEnumerator countSequence()
    {
        // 3
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        readyFX.Play();

        //2
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        readyFX.Play();

        //1
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        readyFX.Play();

        //Go
        yield return new WaitForSeconds(1f);
        countDownGO.SetActive(true);
        goFX.Play();

        yield return new WaitForSeconds(0.5f);
        scoreGO.SetActive(true);
        distanceGO.SetActive(true);
    }
}
*/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGO;

    public GameObject fadeIn;

    public GameObject scoreGO;
    public GameObject distanceGO;

    public AudioSource readyFX;
    public AudioSource goFX;

    public TMP_Text disDisplay;
    public TMP_Text finalDisplay;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.35f;

    void Start()
    {
        StartCoroutine(countSequence());
    }

    void Update()
    {
        if (addingDis == false)
        {
            if (distanceGO.activeSelf == true)
            {
                addingDis = true;
                StartCoroutine(AddingDis());
            }
        }

        // Stop goFX when countDownGO is disabled
        if (!countDownGO.activeSelf && goFX.isPlaying)
        {
            goFX.Stop();
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.text = disRun.ToString() + "m";
        finalDisplay.text = disRun.ToString() + "m";
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }

    IEnumerator countSequence()
    {
        // 3
        yield return new WaitForSeconds(1f);
        countDown3.SetActive(true);
        if (countDown3.activeSelf) readyFX.Play();

        // 2
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        if (countDown2.activeSelf) readyFX.Play();

        // 1
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        if (countDown1.activeSelf) readyFX.Play();

        // Go
        yield return new WaitForSeconds(1f);
        countDownGO.SetActive(true);
        if (countDownGO.activeSelf) goFX.Play();

        yield return new WaitForSeconds(0.5f);
        scoreGO.SetActive(true);
        distanceGO.SetActive(true);

        PlayerMove.canPlayerMove = true;
    }
}
