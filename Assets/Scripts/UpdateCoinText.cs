using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoinText : MonoBehaviour
{
    private Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(Initialized());
    }
    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(ZeroText);
    }

    public void UpdateText()
    {
        if(CommonVariables.GamePlaying)
            if (CommonVariables.DepthHook - CommonVariables.CoinPos >= 0)
                text.text = ((CommonVariables.DepthHook - CommonVariables.CoinPos) * 5).ToString("F0") + "m";
            else text.text = "0m";
    }
    private void ZeroText() => text.text = "";
}
