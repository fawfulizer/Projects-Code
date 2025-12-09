using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astarmanager : MonoBehaviour
{

    //allows for acces by all
    public static Astarmanager instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //genreades a path?
    public List<Node> GeneratePath(Node start, Node end)
    {
       //makes list? 
        List<Node> OpenSet = new List<Node>();

        foreach(Node n in FindObjectsOfType<Node>())
        {
            n.gScore = float.MaxValue;

        }
        //sets the starting score
        start.gScore=0;
        //sets how much distance/score between start and end (A star)
        start.hScore = Vector2.Distance(start.transform.position, end.transform.position);
        OpenSet.Add(start);

        //actual calculations
        while(OpenSet.Count > 0)
        {
            int lowerstF = default; 
            for(int i = 1; i < OpenSet.Count; i++) {

                if (OpenSet[i].FScore() < OpenSet[lowerstF].FScore())
                {
                    lowerstF = 1;

                }
            
            }
            //removes current node
Node currentNode = OpenSet[lowerstF];
            OpenSet.Remove(currentNode);

            if(currentNode == end) { 
            
            List<Node> path = new List<Node>();

                path.Insert(0, end);

                while(currentNode != start) {

                    currentNode = currentNode.Camefrom;

                    path.Add(currentNode);
                }


                path.Reverse();
                return path;


            }

            foreach(Node connectednode in currentNode.connections)
            {

                 float heldGScore = currentNode.gScore + Vector2.Distance(currentNode.transform.position, connectednode.transform.position);
                if(heldGScore < connectednode.gScore)
                {
                    connectednode.Camefrom = connectednode;
                    currentNode.gScore = heldGScore;
                    connectednode.hScore = Vector2.Distance(connectednode.transform.position, end.transform.position);


                    if (!OpenSet.Contains(connectednode)){

                        OpenSet.Add(connectednode);

                    }
                }


            }

        }

        return null;





    }

}
