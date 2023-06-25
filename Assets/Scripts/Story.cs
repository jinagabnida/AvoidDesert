using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public List<Sprite> sprites;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        img.sprite = sprites[0];
        StartCoroutine("SpriteChange");
    }

    IEnumerator SpriteChange()
    {
        for(int i = 0; i < 3; i++)
        {
            img.sprite =sprites[i];
            yield return new WaitForSeconds(2f);
        }
    }

}
