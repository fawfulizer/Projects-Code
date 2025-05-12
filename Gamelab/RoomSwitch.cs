using SharpCompress.Compressors.Xz;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject Manager;
    public enum tpye
    {
        Decrement,
        Increment

    }
    public tpye RoomType;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void CheckType() {
       
            if (RoomType == tpye.Decrement)
            {
                Manager.GetComponent<RoomManager>().DecrementRoom();



            }
            else
            {

                Manager.GetComponent<RoomManager>().IncrementRoom();
            }
        
    }
   /* private void OnMouseDown()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH");
    }
   */


}
