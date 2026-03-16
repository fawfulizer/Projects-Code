using UnityEngine;

public class Wallcheck : MonoBehaviour
{    //wall detection
    public LayerMask WallMask;
    public LayerMask GroundMask;
    public float walldistance;
    public bool HitsWall;

    public GameObject Transfomer;
    public float RaycastOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WallCheck();

    }

    public void WallCheck()
    {
        // Get the current y-rotation of the GameObject (ignore pitch and roll)
        Quaternion rotation = Quaternion.Euler(0f, Transfomer.transform.eulerAngles.y+ RaycastOffset, 0f);

        // Calculate the direction of the ray in world space
        Vector3 Funity = rotation * Vector3.forward; // Forward direction with only y-rotation


        //creates raycasgt
        Ray ray = new Ray(transform.position, Funity);
        RaycastHit hitA;
        
        //multiple layers?
        int masks = WallMask | GroundMask;
        //if raycast hits the ground
        if (Physics.Raycast(ray, out hitA, walldistance, masks))
        {

            // Check if the hit distance is shorter than the checkDistance
            if (hitA.distance < walldistance)
            {
                Debug.Log("WALL!WALL!WALL!");
                if (!HitsWall)
                    HitsWall = true;
            }
        }
        else
        {
            Debug.Log("No walls detected within distance.");
            if (HitsWall)
                HitsWall = false;
        }

        // Optional: Draw the ray in the Scene view
        Debug.DrawRay(transform.position, Funity * walldistance, Color.blue);

    }


}
