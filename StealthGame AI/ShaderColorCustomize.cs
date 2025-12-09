using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class ShaderColorCustomize : MonoBehaviour
{



    MeshRenderer Renderer;
    Material material;
    //the image texture
    Texture MatTexture;
    [SerializeField,Tooltip("The color used for the material")] Color CarColor;
    //textures stuff
    [Tooltip("The list of textures the material can have")]
    public List<Texture2D> TextureList;
    [Tooltip("The ID from the list used")]
    public int TextureId;
    #region Shader
    [Tooltip("Is the texture moving")]
    public bool MoveTex;
    [Tooltip("Is the texture used")]
    public bool UseTex;
    [Tooltip("Texture tile size")]
    public Vector2 TexSize;
    [Tooltip("Movement speed of the tex")]
    public Vector2 TexSpeed;
    #endregion

    #region color
    [Tooltip("The list of colors the material can have")]
    public List<Color> ColorList;
    [Tooltip("The ID from the list used")]
    public int ColorId;
    #endregion
    #region Fresnel
    [Tooltip("Is a fresnel Used")]
    public bool UseFresnel;
    [Tooltip("The power/size of the fresnel")]
    public float FresnelPower;
    [Tooltip("The color of the fresnel")]
    public Color FresnelColor;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        //gets the material
        material = Renderer.material;
        //gets the image
        MatTexture = material.GetTexture("_ImageTexture");

       
    }

    // Update is called once per frame
    void Update()
    {
      
        material.SetColor("_ImageColor", CarColor);
        //debug
        if (Input.GetKeyDown(KeyCode.D)){
            
            updateTexture();
        }
        material.SetTexture("_ImageTexture", MatTexture);

        #region textures
        //access Moving textures bool
        material.SetFloat("_MoveTexture", System.Convert.ToSingle(MoveTex));
        //access the Use the texture bool
        material.SetFloat("_UseTexture", System.Convert.ToSingle(UseTex));
        //sets the texture tile size
        material.SetVector("_TextureSize", TexSize);
        //sets the texture move speed 
        material.SetVector("_TextureMoveSpeed", TexSpeed);
        #endregion

        #region Fresnel
        // access Fresnel bool
        material.SetFloat("_UseFresnel", System.Convert.ToSingle(UseFresnel));
        //access the Fresnel power float
        material.SetFloat("_FresnelPower", FresnelPower);
        //sets the texture tile size
        material.SetColor("_FresnelColor", FresnelColor);
 
        #endregion

    }

    public void updateTexture()
    {
        //when the texture id is in between the list
        if (TextureId < TextureList.Count + 1&& TextureId>=0)
        {
           
            //change the texture
            MatTexture = TextureList[TextureId];
        }
    }
    public void updateColor()
    {
        CarColor = ColorList[ColorId];

    }

}
