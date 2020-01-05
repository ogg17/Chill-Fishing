using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum SwimmingType
{
    Standard,
    Transition
}

public class SwimmingFish : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer fishRenderer;
    [SerializeField] private DisappearTextGameScript disText;
    [SerializeField] private ParticleSystem goldParticle;
    [SerializeField] private ParticleSystem bubbles;
    [SerializeField] private ParticleSystem bubbleBurst;
    
    [Space(10)]
    [SerializeField] private int minCost = 2;
    [SerializeField] private int maxCost = 5;
    [SerializeField] private int probablyGoldFish = 1;
    [SerializeField] private int probablyBubbleFish = 1;

    [Space(10)]
    [SerializeField] private List<Sprite> paintFish = new List<Sprite>();
    [SerializeField] private Sprite goldFishSprite;

    [Space(10)]
    [SerializeField] private float speedSwimmingMax;
    [SerializeField] private float speedSwimmingMin;
    [SerializeField] private float scaleMax = 1.3f;
    [SerializeField] private float scaleMin = 0.7f;
    [SerializeField] private float board;

    private bool direction; // 0 - right, 1 - left
    private bool fishActive = true;
    private bool reloadFish;
    private bool isGold;
    private bool isBubble;
    private bool isPartBonus;
    private bool isGoldBonus;
    
    private int cost;
    private int timeMoving;
    private int timeNow;

    private Vector3 move = Vector3.zero;
    private float speedSwimming;
    private Animator animator;
    private SwimmingType swimmingType;
    private Image image;
    private DateTime goldBonusTime;
    private DateTime partBonusTime;
    private Sprite ownSprite;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        image = GetComponent<Image>();
        image.raycastTarget = false;
        UpdateFish();
        InvokeRepeating("InvokeFish", 0, 0.1f);
        StartCoroutine(Initialized());
    }
    private void UpdateFish()
    {
        isGold = false;
        isBubble = false;
        bubbles.Stop();
        ownSprite = paintFish[Random.Range(0, paintFish.Count)];
        int randomFish = Random.Range(0, 1000);
        if (randomFish < probablyGoldFish)
        {
            fishRenderer.sprite = goldFishSprite;
            isGold = true;
            image.raycastTarget = true;
        }
        else if (randomFish < probablyBubbleFish)
        {
            bubbles.Play();
            isBubble = true;
            image.raycastTarget = true;
            fishRenderer.sprite = ownSprite;
        }
        else
        {
            fishRenderer.sprite = ownSprite;
        }
        
        if (isGoldBonus)
        {
            fishRenderer.sprite = goldFishSprite;
            isGoldBonus = true;
            image.raycastTarget = true; 
        }
        

        timeMoving = Random.Range(10, 50);
        swimmingType = (SwimmingType)Random.Range(0, 2);
        
        animator.SetFloat("offset", Random.Range(0f, 1f));
        speedSwimming = Random.Range(speedSwimmingMin, speedSwimmingMax);
        var randomPos = Random.Range(6, 25);
        transform.position = Random.Range(0, 2) == 0 ? 
            new Vector3(-board + 0.01f, CommonVariables.DepthHook - 0.2f * randomPos, 0) : 
            new Vector3(board - 0.01f, CommonVariables.DepthHook - 0.2f * randomPos, 0);
        var randomScale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(randomScale, randomScale, 1);
        
        //Debug.Log("Update!" + DateTime.Now);
    }

    private void ReloadFish()
    {
        reloadFish = true;
        if (isGoldBonus) EndGoldBonus();
        if (isPartBonus)
        {
            isPartBonus = false;
            GameObjects.gameObjects.bonusPart.SetActive(false);
        }
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(ReloadFish);
        EventController.GameEvents.goldFishBonus.AddListener(OnGoldBonus);
        EventController.GameEvents.partFishBonus.AddListener(OnPartBonus);
    }

    private void EndGoldBonus()
    {
        fishRenderer.sprite = ownSprite;
        isGoldBonus = false;
        GameObjects.gameObjects.goldFish.SetActive(false);
        
        if (isBubble) image.raycastTarget = true;
        else image.raycastTarget = false;
    }

    private void Update()
    {
        move.x = direction ? -speedSwimming * Time.deltaTime : speedSwimming * Time.deltaTime;
        transform.Translate(move);

        if (isGoldBonus && DateTime.Now > goldBonusTime + TimeSpan.FromSeconds(5)) EndGoldBonus();
        if (isPartBonus && DateTime.Now > partBonusTime + TimeSpan.FromSeconds(5))
        {
            isPartBonus = false;
            GameObjects.gameObjects.bonusPart.SetActive(false);
        }
    }

    private void InvokeFish()
    {
        if (transform.position.x > board + 0.01f && !isPartBonus)
        {
            direction = true;
            fishRenderer.flipX = true;
            if (transform.position.y > CommonVariables.DepthHook)
                UpdateFish();
        }
        else if (transform.position.x < -board - 0.01f && !isPartBonus)
        {
            direction = false;
            fishRenderer.flipX = false;
            if (transform.position.y > CommonVariables.DepthHook)
                UpdateFish();
        }
        if (swimmingType == SwimmingType.Transition && timeNow >= timeMoving && !isPartBonus)
        {
            timeMoving = Random.Range(10, 50);
            direction = !direction;
            fishRenderer.flipX = !fishRenderer.flipX;
            timeNow = 0;
        }
        if (transform.position.y > CommonVariables.DepthHook + CommonVariables.CameraSize * 2)
            UpdateFish();
        timeNow++;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(CommonVariables.GamePlaying)
            if (isGold || isGoldBonus) 
            { 
                cost = Random.Range(minCost, maxCost);
                isGold = false;
                isGoldBonus = false;
                GoldFishChange();
            }
            else if (isBubble)
            {
                isBubble = false;
                bubbles.Stop();
                bubbleBurst.Play();
                SoundCenter.sounds.PlayBubble();
                Instantiate(GameObjects.gameObjects.bubble, transform.position, 
                    transform.rotation, GameObjects.gameObjects.bubbleGenerator.transform);
            }
    }

    private void GoldFishChange()
    {
        int nowCost = cost * CommonVariables.bonusX2 * CommonVariables.bonusX3;
        CommonVariables.Gold += nowCost;
        CommonVariables.GoldSession += nowCost;
        disText.SetGoldText(nowCost);
        goldParticle.Play();
        SoundCenter.sounds.PlayCoin();
        fishRenderer.sprite = ownSprite;
        image.raycastTarget = false;

        if (isBubble) image.raycastTarget = true;
        else image.raycastTarget = false;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hook"))
        {
            Debug.Log( isGold + ":" + isGoldBonus);
            if (isGold || isGoldBonus)
            {
                cost = Random.Range(minCost*5, maxCost*4);
                GoldFishChange();
            }
            EventController.GameEvents.gameOver.Invoke();
        }
    }

    private void OnPartBonus()
    {
        if (transform.position.x > 0)
        {
            direction = false;
            fishRenderer.flipX = false;
        }
        else
        {
            direction = true;
            fishRenderer.flipX = true;
        }
        partBonusTime = DateTime.Now;
        isPartBonus = true;
    }

    private void OnGoldBonus()
    {
        goldBonusTime = DateTime.Now;
        fishRenderer.sprite = goldFishSprite;
        isGoldBonus = true;
        image.raycastTarget = true;
    }

    private void DestroyFish()
    {
        Destroy(gameObject);
    }
}
