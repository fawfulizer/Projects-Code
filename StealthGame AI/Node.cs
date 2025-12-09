using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node Camefrom;
    public List<Node> connections;

    public float gScore;
    public float hScore;
    // Start is called before the first frame update
   public float FScore()
    {

        return gScore + hScore;
    }


    //debug
   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (connections.Count > 0)
        {

            for(int i=0; i<connections.Count; i++)
            {
                Gizmos.DrawLine(transform.position, connections[i].transform.position);


            }

        }
    }
   */

}
