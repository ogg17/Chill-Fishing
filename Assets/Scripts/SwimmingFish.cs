using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public enum SwimmingType
{
    Standard,
    Turn,
    Transition,
    Jerky
}

public class SwimmingFish : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fishRenderer;
    [SerializeField] private DisappearTextGameScript disText;
    [SerializeField] private ParticleSystem goldParticle;
    
    [Space(10)]
    [SerializeField] private int minCost = 2;
    [SerializeField] private int maxCost = 5;
    [SerializeField] private int probably = 1;

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
    
    private int cost;
    private int timeMoving;
    private int timeNow;

    private Vector3 move = Vector3.zero;
    private float speedSwimming;
    private Animator animator;
    private SwimmingType swimmingType;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        UpdateFish();
        InvokeRepeating("InvokeFish", 0, 0.1f);
        StartCoroutine(Initialized());
    }
    private void UpdateFish()
    {
        if (Random.Range(0, 1000) < probably)
        {
            fishRenderer.sprite = goldFishSprite;
            isGold = true;
        }
        else fishRenderer.sprite = paintFish[Random.Range(0, paintFish.Count)];

        timeMoving = Random.Range(20, 50);
        swimmingType = (SwimmingType)Random.Range(0, 4);
        
        animator.SetFloat("offset", Random.Range(0f, 1f));
        speedSwimming = Random.Range(speedSwimmingMin, speedSwimmingMax);
        speedSwimming /= 10;
        var randomPos = Random.Range(6, 25);
        transform.position = Random.Range(0, 2) == 0 ? 
            new Vector3(-board, CommonVariables.DepthHook - 0.2f * randomPos, 0) : 
            new Vector3(board, CommonVariables.DepthHook - 0.2f * randomPos, 0);
        var randomScale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(randomScale, randomScale, 1);
        move = transform.position;
    }

    private void ReloadFish()
    {
        reloadFish = true;
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(ReloadFish);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, move, Time.deltaTime * 5);
    }

    private void InvokeFish()
    {
        if (transform.position.y > CommonVariables.DepthHook)
        {
            if (fishActive)
            {
                fishActive = false;
                // CommonVariables.FishNumber--;
            }
            if (transform.position.y > CommonVariables.DepthHook + 0.2f) ReloadFish();
        }

        if (transform.position.x > board)
        {
            direction = true;
            fishRenderer.flipX = true;
            if (reloadFish)
            {
                UpdateFish();
                reloadFish = false;
            }
        }
        else if (transform.position.x < -board)
        {
            direction = false;
            fishRenderer.flipX = false;
            if (reloadFish)
            {
                UpdateFish();
                reloadFish = false;
            }
        }

        
        if (swimmingType == SwimmingType.Transition && timeNow >= timeMoving)
        {
            direction = !direction;
            fishRenderer.flipX = !fishRenderer.flipX;
            timeNow = 0;
        }
        else if (swimmingType == SwimmingType.Turn && timeNow >= timeMoving * 2)
        {
            move.y += Random.Range(0, 2) == 0 ? 0.2f : -0.2f;
            timeNow = 0;
        }
        else if (swimmingType == SwimmingType.Jerky && timeNow >= timeMoving / 5)
        {
            move.x += direction ? -speedSwimming*4 : speedSwimming*4;
            timeNow = 0;
        }
        timeNow++;
        move.x += direction ? -speedSwimming : speedSwimming;
    }

    private void OnMouseDown()
    {
        if (isGold) 
        { 
            cost = Random.Range(minCost, maxCost);
            GoldFishChange();
        }
    }

    private void GoldFishChange()
    {
        CommonVariables.Gold += cost;
        CommonVariables.GoldSession += cost;
        disText.SetGoldText(cost);
        goldParticle.Play();
        SoundScript.sounds.PlaySound(SoundType.Coin);
        isGold = false;
        fishRenderer.sprite = paintFish[Random.Range(0, paintFish.Count)];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hook"))
        {
            if (isGold)
            {
                cost = Random.Range(minCost*5, maxCost*4);
                GoldFishChange();
            }
            EventController.GameEvents.gameOver.Invoke();
        }
    }
    private void DestroyFish()
    {
        Destroy(gameObject);
    }
}
