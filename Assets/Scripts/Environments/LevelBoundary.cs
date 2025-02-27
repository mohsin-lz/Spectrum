using System.Runtime.Remoting.Messaging;
using UnityEngine;
public class LevelBoundary : MonoBehaviour
{
    public static LevelBoundary Instance;
    [Header("Level Settings")]
    public static float leftSide = -4.0f;
    public static float rightSide = 3.4f;

    public float internalLeft;
    public float internalRight;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
