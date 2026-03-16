using UnityEngine;

public class Lockpos : MonoBehaviour
{
    Vector3 startpos;
    [SerializeField]
    bool LockX;
    [SerializeField]
    bool LockY;
    [SerializeField]
    bool LockZ;
    [SerializeField]
    float Xpos;
    [SerializeField]
    float Ypos;
    [SerializeField]
    float Zpos;
    [SerializeField]
    bool LockUpdate = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startpos = transform.position;
        if (LockX) {startpos.x = Xpos;}
        if(LockY) { startpos.y = Ypos;}
        if(LockZ) { startpos.z = Zpos;}
        transform.position = startpos; 
    }

    // Update is called once per frame
    void Update()
    {
        if(LockUpdate)
        {
            startpos = transform.position;
            if (LockX) { startpos.x = Xpos; }
            if (LockY) { startpos.y = Ypos; }
            if (LockZ) { startpos.z = Zpos; }
            transform.position = startpos;

        }
    }
}
