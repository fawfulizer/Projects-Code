using UnityEngine;

public class NessieActive : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localPosition = new Vector3(transform.position.x, 8.87299f, transform.position.z); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,-5)*Time.deltaTime);
    }
}
