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
    
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject packNames;
    [SerializeField] private Sprite lockedPanelImage;
    [SerializeField] private int spacePanel = 2;
    [SerializeField] private float speedStep;
    [SerializeField] private float packNamesPose;
    [SerializeField] private Color colorUnActivePanel;
    [SerializeField] private Color colorActivePanel;
    
    [SerializeField] private Vector3 scalePanel;

    private GameObject[] _panels = new GameObject[CommonVariables.CharacterCount];
    private GameObject[] _packNames = new GameObject[CommonVariables.PacksCount];
    private bool _isScroll;
    private float[] _panelPos = new float[CommonVariables.CharacterCount];
    private Image[] _panelsImage = new Image[CommonVariables.CharacterCount];
    //private Text[] _packTexts = new Text[CommonVariables.PacksCount];
    private RectTransform _contentTransform;
    private Vector2 _contentPos = Vector2.zero;
    private readonly Vector3 _normalPanelScale = new Vector3(1, 1, 1);

    private void Awake()
    {
        _contentTransform = GetComponent<ScrollRect>().content.GetComponent<RectTransform>();

        var panelWight = panel.GetComponent<RectTransform>().sizeDelta.x;
        _contentTransform.sizeDelta= new Vector2(165 + (panelWight + spacePanel) * (CommonVariables.CharacterCount - 1), _contentTransform.sizeDelta.y);
        for (var i = 0; i < CommonVariables.CharacterCount; i++)
        {
            _panels[i] = Instantiate(panel, _contentTransform.transform, false);
            _panelsImage[i] = _panels[i].GetComponent<Image>();
            _panelPos[i] = ((panelWight + spacePanel) * i) + ((i / 3) * 3);
            _panels[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(_panelPos[i] + 67.5f, 0);

            if (i % 3 == 1)
            {
                _packNames[i / 3] = Instantiate(packNames, _contentTransform, false);
                _packNames[i / 3].GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(_panelPos[i] + 67.5f, packNamesPose);
            }
        }

        StartCoroutine(Initialized());
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        for (int i = 0; i < CommonVariables.PacksCount; i++)
        {
            _packNames[i].GetComponent<Text>().text = GameString.gameString.packs[i].english;
        }
        UpdateImagePanel();
        changedPanel.Invoke();
    }

    private void LateUpdate()
    {
        var distance = float.MaxValue;
        var currentPanel = 0;

        for (var i = 0; i < CommonVariables.CharacterCount; i++)
        {
            if (Math.Abs(_panels[i].transform.position.x) < distance)
            {
                distance = Math.Abs(_panels[i].transform.position.x);
                currentPanel = i;
            }

            if (i == CommonVariables.CurrentPanel)
            {
                _panels[i].transform.localScale = scalePanel;
                _panelsImage[i].color = colorActivePanel;
            }
            else
            {
                _panels[i].transform.localScale = _normalPanelScale;
                _panelsImage[i].color = colorUnActivePanel;
            }
        }

        if (CommonVariables.CurrentPanel != currentPanel)
        {
            CommonVariables.CurrentPanel = currentPanel;
            UpdateImagePanel();
            changedPanel.Invoke();
        }
        
        if (_isScroll) return;
        _contentPos.x = Mathf.SmoothStep(_contentTransform.anchoredPosition.x, -_panelPos[currentPanel], speedStep * Time.deltaTime);
        _contentTransform.anchoredPosition = _contentPos;
    }

    public void UpdateImagePanel()
    {
        for (var i = 0; i < CommonVariables.CharacterCount; i++)
        {
            if (CommonVariables.CharacterShop[i][7] == 1)
                _panelsImage[i].sprite = GameSprites.gameSprites.characterSprites[i].scrollPanelSprite;
            else _panelsImage[i].sprite = lockedPanelImage;
        }
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
