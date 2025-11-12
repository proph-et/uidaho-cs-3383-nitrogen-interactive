using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public float lifeDuration = 3.0f; 
    void Start()
    {
        Destroy(gameObject, lifeDuration);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
