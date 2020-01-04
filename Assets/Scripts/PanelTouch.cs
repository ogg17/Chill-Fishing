using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTouch : MonoBehaviour, IPointerClickHandler
{
    public Image characImage;
    public int CurentPanelIndex { get; set; }
    public int CurentPanel { get; set; }
    public int CurentPack { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        CommonVariables.CurrentIndexPanel = CurentPanelIndex;
        CommonVariables.CurrentPanel = CurentPanel;
        CommonVariables.CurrentPack = CurentPack;
        CommonVariables.OnClickPanel = true;
        SoundCenter.sounds.PlayCrack();
    }
}
