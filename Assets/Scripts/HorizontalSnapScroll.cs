using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class HorizontalSnapScroll : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public UnityEvent changedPanel;
    
    public GameObject panel;
    public int spacePanel = 2;
    public float speedStep;
    public Color colorUnActivePanel;
    public Color colorActivePanel;
    public GameObject[] panels = new GameObject[CommonVariables.CharacterCount];
    public Vector3 scalePanel;

    private bool _isScroll;
    private float[] _panelPos = new float[CommonVariables.CharacterCount];
    private Image[] _panelsImage = new Image[CommonVariables.CharacterCount];
    private RectTransform _contentTransform;
    private Vector2 _contentPos = Vector2.zero;
    private readonly Vector3 _normalPanelScale = new Vector3(1, 1, 1);

    private void Start()
    {
        _contentTransform = GetComponent<ScrollRect>().content.GetComponent<RectTransform>();

        var panelWight = panel.GetComponent<RectTransform>().sizeDelta.x;
        _contentTransform.sizeDelta= new Vector2(135 + (panelWight + spacePanel) * (CommonVariables.CharacterCount - 1), _contentTransform.sizeDelta.y);
        for (var i = 0; i < CommonVariables.CharacterCount; i++)
        {
            panels[i] = Instantiate(panel, _contentTransform.transform, false);
            _panelsImage[i] = panels[i].GetComponent<Image>();
            _panelPos[i] = (panelWight + spacePanel) * i;
            panels[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(_panelPos[i] + 67.5f, 0);
        }

        StartCoroutine(Initialized());
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        for (var i = 0; i < CommonVariables.CharacterCount; i++)
        {
            _panelsImage[i].sprite = GameSprites.gameSprites.scrollPanelsSprite[i];
        }
    }

    private void LateUpdate()
    {
        var distance = float.MaxValue;
        var currentPanel = 0;

        for (var i = 0; i < CommonVariables.CharacterCount; i++)
        {
            if (Math.Abs(panels[i].transform.position.x) < distance)
            {
                distance = Math.Abs(panels[i].transform.position.x);
                currentPanel = i;
            }

            if (i == CommonVariables.CurrentPanel)
            {
                panels[i].transform.localScale = scalePanel;
                _panelsImage[i].color = colorActivePanel;
            }
            else
            {
                panels[i].transform.localScale = _normalPanelScale;
                _panelsImage[i].color = colorUnActivePanel;
            }
        }

        if (CommonVariables.CurrentPanel != currentPanel)
        {
            CommonVariables.CurrentPanel = currentPanel;
            changedPanel.Invoke();
        }
        
        if (_isScroll) return;
        _contentPos.x = Mathf.SmoothStep(_contentTransform.anchoredPosition.x, -_panelPos[currentPanel], speedStep * Time.deltaTime);
        _contentTransform.anchoredPosition = _contentPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        _isScroll = false;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        _isScroll = true;
    }
}
