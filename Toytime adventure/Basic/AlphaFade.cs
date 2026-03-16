using UnityEngine;

public class AlphaFade : MonoBehaviour
{
    [SerializeField]
    Material Mat;


    [SerializeField]
    float FadeSpeed;

    Vector4 Color;
    public enum Type
    {
        LineRenderer,
        SpriteRenderer,
        Meshrenderer,
        SkinnedMeshrenderer

    }
    public Type RenderType;
    [SerializeField]
    int MatIndex;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("BBBBB");

        if (RenderType == Type.LineRenderer)
        {
            Debug.LogWarning("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH");
            Mat = GetComponent<LineRenderer>().materials[MatIndex];

        }
        else if (RenderType == Type.SpriteRenderer)
        {
            Mat = GetComponent<SpriteRenderer>().materials[MatIndex];

        }
        else if (RenderType == Type.Meshrenderer)
        {
            Mat = GetComponent<MeshRenderer>().materials[MatIndex];

        }
        else
        {
            Mat = GetComponent<SkinnedMeshRenderer>().materials[MatIndex];

        }

        Color = Mat.color;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning("CCC");

        Color.w -= FadeSpeed / 100;
        Mat.color = Color;

        if (Color.w <= 0)
        {

            Destroy(gameObject);
        }

    }
}
