using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
   // [SerializeField]
    bool Trigger;
   // [SerializeField]
    bool Collision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void ChangeLevel(string LevelName )
    {
       // if (LevelName == "" || SceneManager.GetSceneByName(LevelName) == null) { FindFirstObjectByType<LoadScenes>().ChangeLevel("Test level"); }
//else
        {
            SceneManager.LoadScene(LevelName);  


        }


    }
    public void ResetLevel()
    {
        //creates script when it cannot be found
        #region analytics
        var AnScript = FindFirstObjectByType<Analytics>();
        if (AnScript == null)
        {
            AnScript = gameObject.AddComponent<Analytics>();
            

        }
        else {
            //logs it
            AnScript.SaveRestart();
        }
        #endregion


        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
