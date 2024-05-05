using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipController : MonoBehaviour
{
    public GameObject tip;
    public bool isTip;
    public Text tipText;
    private bool isRandomTip = true;
    public string[] tips = {
    "Upgrade your character to increase strength!",
    "Use pets to assist in tough battles.",
    "Don't forget to gather materials for crafting.",
    "Explore new areas to earn additional rewards.",
    "Upgrade your weapons for more effective combat.",
    "Learn new skills to deal with stronger enemies."
    };
    public Toggle tipToggle;
    void Start()
    {
        if (tipToggle != null)
        {
            tipToggle.onValueChanged.AddListener(OnTipToggleChanged);
        }
    }

    void OnTipToggleChanged(bool isOn)
    {
        if (!isOn)
        {
            isTip = false;
            tip.SetActive(false);
        }
        else
        {
            isTip = true;
            tip.SetActive(true);
            ShowRandomTip();
        }
    }

    public void ShowRandomTip()
    {
        if (isRandomTip)
        {
            int randomIndex = Random.Range(0, tips.Length);
            string randomTip = tips[randomIndex];
            tipText.text = ":" + randomTip;
            isRandomTip = false;
        }
    }
    public void ResetRandomTip()
    {
        isRandomTip = true;
    }
}
