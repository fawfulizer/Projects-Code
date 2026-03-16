using UnityEngine;
using static Unity.VisualScripting.Member;

public class Health : MonoBehaviour
{
    public SFXmanager source;
    public enum Type
    {
        Enemy,
        Player,


    }
    public Type Healthtype;

    public int MaxHealth;
    public int CurrentHealth;

    public bool Imortal;

    bool IFrames;
    public float ITimer;
    float it;
    #region Reviving
    public bool Revive;
    public int ReviveAmount;
    public float ReviveTimer;
    float Rtimer;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(CurrentHealth == 0) { CurrentHealth = 1; }
    }

    // Update is called once per frame
    void Update()
    {
        //dead
        if(CurrentHealth < 0 && !Revive && !Imortal)
        {
            Kill();

        }
        //Revived
        else if(CurrentHealth < MaxHealth && Revive)
        {
            Reviving();
        }

        //IFrames
        if(IFrames)
        {
            IframeTimer();


        }
        else
        {
            it = 0;

        }
    }

    private void IframeTimer()
    {
        it += Time.deltaTime;
    if(it>=ITimer)
        {

            IFrames = false;
            it = 0;
        }
    
    
    }

    public void SubHp(int Amount)
    {

        CurrentHealth -= Amount;
    }

    public void SetHp(int Amount)
    {

        CurrentHealth = Amount;
    }
    public void ResetHp()
    {

        CurrentHealth -= MaxHealth;
    }

    public void Kill()
    {
       
        if(Healthtype == Type.Player)
        {
            //creates script when it cannot be found
            #region analytics
            var AnScript = FindFirstObjectByType<Analytics>();
            if (AnScript == null)
            {
                AnScript = gameObject.AddComponent<Analytics>();


            }
            else
            {
                //logs it
                AnScript.Dead();
            }
            #endregion

        }



        Destroy(gameObject);


    }

    public void Reviving()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        #region player hit by enemy
        if (Healthtype == Type.Player)
        {
            if (other.gameObject.CompareTag("Enemy") && !IFrames)
            {
                SubHp(other.GetComponent<EnemyTpye>().HurtDamage);
                source.PlayClipAudio(2);
                Handheld.Vibrate();
                Debug.Log("AAAH HURT");
                IFrames = true;
            }

        }
        #endregion



    }
}
