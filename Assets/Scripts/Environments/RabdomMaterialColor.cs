using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class RandomGateColor : MonoBehaviour
{
    public static RandomGateColor Instance;
    public Renderer[] gates; // Array to store all gate renderers
    public GameObject[] entries; // Array to store corresponding game objects for entries
    public List<Color> possibleColors; // List of possible colors
    public TMP_Text colorText; // TMP text to display one chosen color name
    public Animator playerAnimator;


    private Dictionary<Color, string> colorNameMap = new Dictionary<Color, string>();
    private Color chosenColor; // Store the chosen color for easy reference

    public bool temp = false;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        InitializeColorNames();
        AssignRandomColors();

        // Iterate through entries to check for MeshColliders
        foreach (GameObject ent in entries)
        {
            if (ent.GetComponent<MeshCollider>() != null)
            {
                temp = true;
                Debug.Log("Mesh Collider is attached");
                break;
            }
        }
    }

    void InitializeColorNames()
    {
        string[] colorNames = { "Red", "Green", "Blue", "White", "Yellow", "Pink", "Orange" };
        for (int i = 0; i < possibleColors.Count && i < colorNames.Length; i++)
        {
            colorNameMap[possibleColors[i]] = colorNames[i];
        }
    }

    void AssignRandomColors()
    {
        if (gates.Length == 0 || possibleColors.Count < gates.Length)
        {
            Debug.LogError("Not enough colors or gates are missing!");
            return;
        }

        List<Color> availableColors = new List<Color>(possibleColors);
        List<Color> selectedColors = new List<Color>();

        // Select 4 unique random colors
        for (int i = 0; i < Mathf.Min(4, gates.Length, availableColors.Count); i++)
        {
            int randomIndex = Random.Range(0, availableColors.Count);
            selectedColors.Add(availableColors[randomIndex]);
            availableColors.RemoveAt(randomIndex);
        }

        Renderer passableGateRenderer = null; // Store the renderer of the passable gate

        // Assign colors to the gates
        for (int i = 0; i < selectedColors.Count; i++)
        {
            if (gates[i] != null)
            {
                Material[] gateMaterials = gates[i].materials;
                foreach (Material mat in gateMaterials)
                {
                    mat.color = selectedColors[i];
                }
                gates[i].gameObject.tag = "BlockedGate"; // Default all gates to blocked
            }
        }

        // Pick one random color from the 4 selected and display its name
        if (colorText != null && selectedColors.Count > 0)
        {
            chosenColor = selectedColors[Random.Range(0, selectedColors.Count)];

            if (colorNameMap.ContainsKey(chosenColor))
            {
                colorText.text = colorNameMap[chosenColor]; // Display one random color name
            }

            // Find the gate that has this chosen color and tag it as "PassableGate"
            foreach (Renderer gate in gates)
            {
                if (gate != null && gate.material.color == chosenColor)
                {
                    gate.gameObject.tag = "PassableGate"; // Assign only this gate as passable
                    passableGateRenderer = gate;
                    break; // Stop after finding the first matching gate
                }
            }
        }

        // Debugging
        Debug.Log("Passable Gate: " + (passableGateRenderer != null ? passableGateRenderer.gameObject.name : "None"));

        // Now we need to enable isTrigger on the corresponding entries' MeshColliders
        for (int i = 0; i < gates.Length; i++)
        {
            // Check if the gate is passable
            if (gates[i].gameObject.tag == "PassableGate")
            {
                // Find the corresponding entry
                GameObject entry = entries[i];
                if (entry != null)
                {
                    MeshCollider meshCollider = entry.GetComponent<MeshCollider>();
                    if (meshCollider != null)
                    {
                        meshCollider.isTrigger = true; // Enable isTrigger on the MeshCollider
                        Debug.Log("Enabled isTrigger on MeshCollider for " + entry.name);
                    }
                }
            }
        }
    }

    public void DestroyGate()
    {
        Debug.Log("Destroying gate: " + gameObject.name);
        Destroy(gameObject); // Destroy the GameObject this script is attached to
    }

}



