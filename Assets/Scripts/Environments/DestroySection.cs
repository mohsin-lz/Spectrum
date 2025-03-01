using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DestroySection : MonoBehaviour
{
    public string parentName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        parentName = transform.name;
        StartCoroutine(destroyClone());
    }

    IEnumerator destroyClone()
    {
        yield return new WaitForSeconds(40);

        if(parentName == "Section1(Clone)")
        {
            Destroy(gameObject);
            yield return new WaitForSeconds(15);
        }

        if (parentName == "Section2(Clone)")
        {
            Destroy(gameObject);
            yield return new WaitForSeconds(15);
        }

        if (parentName == "Section3(Clone)")
        {
            Destroy(gameObject);
            yield return new WaitForSeconds(15);
        }
    }
}
