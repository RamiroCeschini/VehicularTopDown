using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image inmunityRender;
    public Image powerUpRender;
    public Image playerLifeBar;
    public Image enemyLifeBar;
    void Start()
    {
        ChangeOpacity(false, inmunityRender);
        ChangeOpacity(false, powerUpRender);
    }


    public void ChangeOpacity(bool toVisible, Image image)
    {
        if (toVisible)
        {
            image.color += new Color(0f, 0f, 0f, 0.5f);
        }
        else
        {
            image.color -= new Color(0f, 0f, 0f, 0.5f);
        }

    }

    public void UpdateLife(Image lifeBar,float curretLife, float maxLife)
    {
        lifeBar.fillAmount = curretLife / maxLife;
    }
}
