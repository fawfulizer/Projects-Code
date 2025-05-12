using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField]
    float moveX;
    [SerializeField]
    float moveY;
    //repeating background
    Vector3 startpos;
    [SerializeField]
    float repeatNumberX;
    [SerializeField]
    float repeatNumberY;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Shmoving = new Vector2(moveX, moveY);
        transform.Translate(Shmoving * Time.deltaTime);

        #region repeating background
        //xpos
        if (transform.position.x < startpos.x - repeatNumberX || transform.position.x > startpos.x + repeatNumberX)
        {
            transform.position = startpos;

        }
        //ypos
        if (transform.position.y < startpos.y - repeatNumberY || transform.position.y > startpos.y + repeatNumberY)
        {
            transform.position = startpos;

        }
        #endregion
    }
}