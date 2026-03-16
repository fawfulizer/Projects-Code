using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class EnemyTpye : MonoBehaviour
{
    public int HurtDamage;
    public enum ENemyType
    {
        Basic,
        Spikeball,
        Spikes


    }
    public ENemyType Type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        #region Spikeball
        EnemyMovement move = GetComponent<EnemyMovement>();
        //if spikeball and moving
        if (Type == ENemyType.Spikeball && move != null && move.Walking)
        {
            //if touching enemy or player
            if (other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("Player")) {
                other.GetComponent<Health>().SubHp(HurtDamage);
                other.GetComponent<Health>().source.PlayClipAudio(2);
                Handheld.Vibrate();



            }
          
        }

        #endregion


        #region Spikes
        move = GetComponent<EnemyMovement>();
        //if spikeball and moving
        if (Type == ENemyType.Spikes )
        {
            //if touching enemy or player
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<Health>().SubHp(HurtDamage);
                other.GetComponent<Health>().source.PlayClipAudio(2);
                Handheld.Vibrate();



            }

        }

        #endregion
    }
}
