using TMPro;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    GameObject[] Players;

    public int PlayerAMount =1;
    [SerializeField]
    string LevelTogoto;

    LevelManager levelManager;

    [SerializeField]
    bool opened;

    [SerializeField]
    GameObject OpenParticles;
    [SerializeField]
    GameObject EndLevelButton;
    [SerializeField]
    TextMeshProUGUI PlayerText;
    [SerializeField]
    GameObject LevelEndScreen;
    [SerializeField]
    int EnteredAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        Players = GameObject.FindGameObjectsWithTag("Player");

        PlayerAMount = Players.Length;

        levelManager.PlayerCount = PlayerAMount;
        LevelEndScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        #region minimum
        //open door;
        if (EnteredAmount >= levelManager.MinClearAmount && levelManager.MinClearAmount >0 && EnteredAmount > 0)
        {
            opened = true;

        }
            EndLevelButton.SetActive(opened);

            OpenParticles.SetActive(opened);
        PlayerText.gameObject.SetActive(!opened);

            PlayerText.text = $"{levelManager.MinClearAmount-EnteredAmount}";
        #endregion

        //final star
        if (PlayerAMount <= 0) {
            FindFirstObjectByType<PauseMenu>().Collected[2] = true;        
        
        }

      
        
    }

    public void EndLevel()
    {

        Debug.LogWarning("THIS IS WHERE I WOULD SAVE THE GAME");
        //Save collected stars
        //Save the level is beaten


    }
    private void OnTriggerEnter(Collider collision)
    {
        //adds player to it
        if(collision.CompareTag("Player") ) { 
        PlayerAMount--;
            EnteredAmount++;
            Destroy(collision.gameObject);
        }
        
        
    }
}
