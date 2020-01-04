using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class PackPanels
{
    public List<GameObject> Panels { get; set; } = new List<GameObject>(3);
    public List<RectTransform> PanelsRect { get; set; } = new List<RectTransform>(3);
    public List<float> PanelPos { get; set; } = new List<float>(3);
    public List<Image> PanelsImage { get; set; } = new List<Image>(3);
    public List<Image> CharacImage { get; set; } = new List<Image>(3); 
    public GameObject TextPack { get; set; } = new GameObject();
}

public class HorizontalSnapScroll : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    //public UnityEvent changedPanel = new UnityEvent();
    
    [SerializeField] private GameObject defaultPanel;
    [SerializeField] private GameObject packText;
    [SerializeField] private Sprite lockedPanelImage;
    [SerializeField] private int spacePanel = 2;
    [SerializeField] private float speedStep;
    [SerializeField] private float packNamesPose;
    [SerializeField] private float inertiaMin = 0.01f;
    [SerializeField] private float panelOffsetY = 2f;
    [SerializeField] private float panelOffsetX = 60f;
    [SerializeField] private Color colorUnActivePanel;
    [SerializeField] private Color colorActivePanel;
    [SerializeField] private Color offsetColorPanel;
    [SerializeField] private Vector3 scaleActivePanel;
    
    private bool isScroll;
    private int currentPack;
    private int currentPanel;

    private PackPanels[] packsPanels = new PackPanels[CommonVariables.PacksCount];
    private RectTransform contentTransform;
    private ScrollRect scrollRect;
    private Vector2 contentPos = Vector2.zero;
    private Vector3 variableScale = Vector3.zero;
    private Vector2 panelPos = Vector2.zero;
    private readonly Vector3 scaleUnActivePanel = new Vector3(1, 1, 1);

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        contentTransform = scrollRect.content.GetComponent<RectTransform>();
        var panelWight = defaultPanel.GetComponent<RectTransform>().sizeDelta.x;
        var indexCounter = 0;
        for (var i = 0; i < packsPanels.Length; i++)
        {
            packsPanels[i] = new PackPanels();
            packsPanels[i].TextPack = Instantiate(packText, contentTransform, false); 
            for (var j = 0; j < CommonVariables.CharacterPacks[i]; j++)
            {
                
                packsPanels[i].Panels.Add(Instantiate(defaultPanel, contentTransform.transform, false));
                packsPanels[i].PanelsImage.Add(packsPanels[i].Panels[j].GetComponent<Image>());
                packsPanels[i].PanelPos.Add((panelWight + spacePanel) * indexCounter + i * spacePanel);
                packsPanels[i].PanelsRect.Add(packsPanels[i].Panels[j].GetComponent<RectTransform>());
                
                panelPos = new Vector2(packsPanels[i].PanelPos[j] + 60f, panelOffsetY);
                packsPanels[i].PanelsRect[j].anchoredPosition = panelPos;
                var panelTouch = packsPanels[i].Panels[j].GetComponent<PanelTouch>();
                packsPanels[i].CharacImage.Add(panelTouch.characImage);
                
                panelTouch.CurentPanelIndex = indexCounter;
                panelTouch.CurentPack = i;
                panelTouch.CurentPanel = j;
                indexCounter++;
            }
            packsPanels[i].TextPack.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(packsPanels[i].PanelPos[1] + panelOffsetX, packNamesPose);
        }

        contentTransform.sizeDelta = new Vector2(panelOffsetX*2 + (panelWight + spacePanel) * (indexCounter - 1) + 
                                                 spacePanel * (packsPanels.Length - 1), contentTransform.sizeDelta.y);
        contentPos.y = contentTransform.anchoredPosition.y;
        
        InvokeRepeating("UpdatePanel",0,0.1f);
        StartCoroutine(Initialized());
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        
        for (var i = 0; i < packsPanels.Length; i++)
        {
            packsPanels[i].TextPack.GetComponent<Text>().text = GameString.gameString.stringPacks.packs[i].packName;
        }

        UpdateImagePanel();
        EventController.GameEvents.updatePanel.Invoke();
    }

    private void UpdatePanel()
    {
        var distance = float.MaxValue;
        var indexCounter = 0;
        var currentIndex = 0;
        for (var i = 0; i < packsPanels.Length; i++)
        {
            for (var j = 0; j < CommonVariables.CharacterPacks[i]; j++)
            {
                var absPosPanels = Mathf.Abs(packsPanels[i].Panels[j].transform.position.x);
                if (absPosPanels < distance)
                {
                    distance = absPosPanels;
                    currentPack = i;
                    currentPanel = j;
                    currentIndex = indexCounter;
                }

                if (indexCounter == CommonVariables.CurrentIndexPanel)
                {
                    packsPanels[i].Panels[j].transform.localScale = scaleActivePanel;
                    panelPos.x = packsPanels[i].PanelPos[j] + panelOffsetX;
                    panelPos.y = panelOffsetY + 1;
                    packsPanels[i].PanelsRect[j].anchoredPosition = panelPos;
                    if (CommonVariables.CharacterShops[indexCounter].BuyCharacter == true)
                    {
                        packsPanels[i].PanelsImage[j].color = GameSprites.gameSprites.characterSprites[indexCounter]
                            .characterBackgroundShopColor - offsetColorPanel;
                        packsPanels[i].CharacImage[j].color = Color.white;
                    }
                    else packsPanels[i].PanelsImage[j].color = Color.grey - offsetColorPanel;
                }
                else
                {
                    variableScale = scaleUnActivePanel;
                    variableScale.x = Mathf.Lerp(variableScale.x, 
                        Mathf.Clamp(Mathf.Abs((packsPanels[i].Panels[j].transform.position.x * 
                                  scrollRect.velocity.x))+1000,1000,2000)/1000, 1*Time.deltaTime);
                    packsPanels[i].Panels[j].transform.localScale = variableScale;
                    panelPos.y = panelOffsetY;
                    panelPos.x = packsPanels[i].PanelPos[j] + panelOffsetX;
                    packsPanels[i].PanelsRect[j].anchoredPosition = panelPos;

                    if (CommonVariables.CharacterShops[indexCounter].BuyCharacter == true)
                    {
                        packsPanels[i].PanelsImage[j].color =
                            GameSprites.gameSprites.characterSprites[indexCounter].characterBackgroundShopColor -
                            colorUnActivePanel - offsetColorPanel;
                        packsPanels[i].CharacImage[j].color = Color.white - colorUnActivePanel;
                    }
                    else packsPanels[i].PanelsImage[j].color = Color.grey - colorUnActivePanel - offsetColorPanel;
                }
                indexCounter++;
            }
        }

        if (CommonVariables.CurrentIndexPanel != currentIndex && !CommonVariables.OnClickPanel)
        {
            CommonVariables.CurrentIndexPanel = currentIndex;
            CommonVariables.CurrentPanel = currentPanel;
            CommonVariables.CurrentPack = currentPack;
            SoundCenter.sounds.PlayCrack();
            EventController.GameEvents.updatePanel.Invoke();
        }else if (CommonVariables.OnClickPanel && CommonVariables.CurrentIndexPanel == currentIndex)
        {
            CommonVariables.OnClickPanel = false;
            EventController.GameEvents.updatePanel.Invoke();
        }
    }

    private void LateUpdate()
    {
        //Debug.Log(Input.touches[0].deltaPosition);
        if(isScroll) return;
        if (Mathf.Abs(scrollRect.velocity.x) > inertiaMin)
        {
            return;
        }
        scrollRect.velocity = Vector2.zero;
        contentPos.x = Mathf.Lerp(contentTransform.anchoredPosition.x, 
            -packsPanels[CommonVariables.CurrentPack].PanelPos[CommonVariables.CurrentPanel],speedStep * Time.deltaTime);
        contentTransform.anchoredPosition = contentPos;
    }

    public void UpdateImagePanel()
    {
        var indexCounter = 0;
        for (var i = 0; i < packsPanels.Length; i++)
        {
            for (var j = 0; j < CommonVariables.CharacterPacks[i]; j++)
            {
                if (CommonVariables.CharacterShops[indexCounter].BuyCharacter == true)
                    packsPanels[i].CharacImage[j].sprite =
                        GameSprites.gameSprites.characterSprites[indexCounter].characterShopSprite;
                else packsPanels[i].CharacImage[j].sprite = lockedPanelImage;
                indexCounter++;
            }
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        isScroll = false;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        isScroll = true;
    }
}
