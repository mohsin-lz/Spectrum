using UnityEngine;

public class ColorMatch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        string materialName = this.GetComponent<MeshRenderer>().materials[0].name;
        if (materialName == "blue")
        {

        Debug.Log("materialName");
        }
        else { 
        }
        Debug.Log(materialName);
    }
}
