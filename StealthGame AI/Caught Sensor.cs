using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaughtSensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //do caught
            if (FindFirstObjectByType<GameManager>() != null)
            {
                FindFirstObjectByType<GameManager>().state = GameState.Caught;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("YOU GOT CUAHGT!");
            }
        }
    }
}
