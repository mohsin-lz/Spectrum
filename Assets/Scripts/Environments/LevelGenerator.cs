using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;

    [Header("Array Of Sections")]
    public GameObject[] section;

    [Header("Section Vector POS")]
    public int zPos = 55;    // To generate each section at end of another section. Multiple of *55*

    public bool isGenerating = false;
    public int sectionID;

    // Update is called once per frame
    void Update()
    {
        if (isGenerating == false)
        {
            isGenerating = true;
            StartCoroutine(generateSection());
        }
    }

    IEnumerator generateSection()
    {
        sectionID = Random.Range(0, 3);
        Instantiate(section[sectionID], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 55;
        yield return new WaitForSeconds(2);
        isGenerating = false;
    }
}
