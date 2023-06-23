using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_AmmoText : MonoBehaviour
{
    public Text m_Text;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BlinkText");       
    }


    IEnumerator BlinkText()
    {
        float oppacity=0.2f;
        while (true)
        {
            if (oppacity >= 1f)
            {
                for(int i = 0; i < 9; i++)
                {
                    oppacity -= 0.1f;
                }
                yield return new WaitForSeconds(0.1f);
                
            }
            if(oppacity <=0.1f)
            {
                for (int i = 0; i < 9; i++)
                {
                    oppacity += 0.1f;
                }
                yield return new WaitForSeconds(0.1f);
            }
            m_Text.color = new Color(255,0,0,oppacity);
        }

        yield return null;
    }
    // Update is called once per frame
}
