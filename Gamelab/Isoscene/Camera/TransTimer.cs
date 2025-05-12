using UnityEngine;

public class TransTimer : MonoBehaviour
{
    [SerializeField]
    float MaxTimer;
    float Timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= MaxTimer)
        {
            gameObject.SetActive(false);
            Timer = 0;

        }
    }
}
