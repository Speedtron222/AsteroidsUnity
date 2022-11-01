using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    public TextMeshProUGUI gameOver;
    public Image Brake;
    public Image gear1;
    public Image gear2;
    public Image gear3;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        gear1.enabled = true;
        gear2.enabled = true;
        gear3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gears.instance.gears >= 0)
        {
            time.text = Time.time.ToString("00.00");
        }
        score.text = Gears.instance.score.ToString();

        if(Gears.instance.gears == 2)
        {
            gear3.enabled = false;
        }
        if (Gears.instance.gears == 1)
        {
            gear2.enabled = false;
        }
        if (Gears.instance.gears == 0)
        {
            gear1.enabled = false;
        }
        if (Gears.instance.gears < 0)
        {
            gameOver.enabled = true;
        }
        if (PlayerMove.PM.canBrake)
        {
            Brake.enabled = true;
        }
        else
        {
            Brake.enabled = false;
        }
    }
}
