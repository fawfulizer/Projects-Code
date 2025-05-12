
using UnityEngine;

public class NessieEasteregg : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
     int Random_number;

    [SerializeField, Tooltip("The time to randomize number")]
    float RandomizeTimer;
    [SerializeField]
    float TTimer
; void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Randomization();
        CheckRandom();
    }

    private void CheckRandom()
    {
        if (Random_number == 1)
        {
            NessieActive ness = gameObject.GetComponent<NessieActive>();
            ness.enabled = true;

        }
    }

    private void Randomization()
    {
        TTimer += Time.deltaTime;
        if (TTimer >= RandomizeTimer)
        {
            
            Random_number = Random.RandomRange(1, 1);
            TTimer = 0;
        }
    }
}
