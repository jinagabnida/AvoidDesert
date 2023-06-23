using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class P_PostProcessing : MonoBehaviour
{
    public PostProcessVolume m_Volume;
    public static float bloody;
    // Start is called before the first frame update
    void Start()
    {

        bloody = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
        if (P_Manager.health >= 90)
        {
            bloody = 0;
        }
        else
        {
            bloody = 1f - P_Manager.health / 400;
        }
        
        m_Volume.weight = bloody;
    }

    
}
