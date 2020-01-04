using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

enum ItemType
{
    Gold,
    Gold2,
    Gold5,
    BonusX2,
    BonusX3,
    GoldFish,
    Part
}
public class ItemScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float speed = 0.5f;
    
    [Space(10)]
    [SerializeField] private int probablyGoldFish = 20;
    [SerializeField] private int probablyBonusX3 = 50;
    [SerializeField] private int probablyPart = 100;
    [SerializeField] private int probablyBonusX2 = 200;
    [SerializeField] private int probablyGold5 = 300;
    [SerializeField] private int probablyGold2 = 500;
    
    [Space(10)]
    [SerializeField] private int cost = 1;

    [Space(10)]
    [SerializeField] private ParticleSystem baubles;
    [SerializeField] private GameObject core;
    [SerializeField] private Image itemImage;
    [SerializeField] private DisappearTextScript disText;
    
    [Space(10)]
    [SerializeField] private List<Sprite> itemSprites = new List<Sprite>();

    private Vector3 move = Vector3.zero;
    private Image image;
    private ItemType itemType;

    private bool pickUp = true;
    private float boostSpeed;

    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(Initialized());
        SpawningCoin();
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(ZeroCoin);
    }
    private void SpawningCoin()
    {
        int randomType = Random.Range(0, 1000);
        if (randomType < probablyGoldFish) itemType = ItemType.GoldFish;
        else if (randomType < probablyBonusX3) itemType = ItemType.BonusX3;
        else if (randomType < probablyPart) itemType = ItemType.Part;
        else if (randomType < probablyBonusX2) itemType = ItemType.BonusX2;
        else if (randomType < probablyGold5) itemType = ItemType.Gold5;
        else if (randomType < probablyGold2) itemType = ItemType.Gold2;
        else itemType = ItemType.Gold;

        itemImage.sprite = itemSprites[(int)itemType];
        boostSpeed = speed;
        core.SetActive(true);
        pickUp = false;
        image.raycastTarget = true;
    }

    private void Update()
    {
        if (!pickUp && CommonVariables.GamePlaying)
        {
            move.y = boostSpeed * Time.deltaTime;
            transform.Translate(move);
            if (transform.position.y > CommonVariables.DepthHook + CommonVariables.CameraSize + 0.2f) pickUp = true;
            //forseSpeed += 0.001f;
        }
    }

    private void ZeroCoin()
    {
        image.raycastTarget = false;
        core.SetActive(false);
        pickUp = true;
        //SpawningCoin();
        Destroy(this.gameObject);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CommonVariables.GamePlaying && !pickUp)
        {
            baubles.Play();
            core.SetActive(false);
            SoundCenter.sounds.PlayBubble();
            pickUp = true;
            image.raycastTarget = false;

            if (itemType == ItemType.Gold)
            {
                int nowCost = cost * CommonVariables.bonusX2 * CommonVariables.bonusX3;
                CommonVariables.Gold += nowCost;
                CommonVariables.GoldSession += nowCost;
                disText.SetGoldText(nowCost);
                EventController.GameEvents.pickUpCoin.Invoke();
            }
            else if (itemType == ItemType.Gold2)
            {
                int nowCost = cost * 2 * CommonVariables.bonusX2 * CommonVariables.bonusX3;
                CommonVariables.Gold += nowCost;
                CommonVariables.GoldSession += nowCost;
                disText.SetGoldText(nowCost);
                EventController.GameEvents.pickUpCoin.Invoke();
            }
            else if (itemType == ItemType.Gold5)
            {
                int nowCost = cost * 5 * CommonVariables.bonusX2 * CommonVariables.bonusX3;
                CommonVariables.Gold += nowCost;
                CommonVariables.GoldSession += nowCost;
                disText.SetGoldText(nowCost);
                EventController.GameEvents.pickUpCoin.Invoke();
            }
            else if (itemType == ItemType.BonusX2)
            {
                CommonVariables.bonusX2 = 2;
                CommonVariables.isBonusX2 = true;
                CommonVariables.timeBonusX2 = DateTime.Now;
                GameObjects.gameObjects.bonusX2.SetActive(true);
                // disabled bonusX3
                CommonVariables.bonusX3 = 1;
                CommonVariables.isBonusX3 = false;
                GameObjects.gameObjects.bonusX3.SetActive(false);
            }
            else if (itemType == ItemType.BonusX3)
            {
                CommonVariables.bonusX3 = 3;
                CommonVariables.isBonusX3 = true;
                CommonVariables.timeBonusX3 = DateTime.Now;
                GameObjects.gameObjects.bonusX3.SetActive(true);
                // disabled bonusX2
                CommonVariables.bonusX2 = 1;
                CommonVariables.isBonusX2 = false;
                GameObjects.gameObjects.bonusX2.SetActive(false);
            }
            else if (itemType == ItemType.GoldFish)
            {
                EventController.GameEvents.goldFishBonus.Invoke();
                GameObjects.gameObjects.goldFish.SetActive(true);
            }
            else if (itemType == ItemType.Part)
            {
                EventController.GameEvents.partFishBonus.Invoke();
                GameObjects.gameObjects.bonusPart.SetActive(true);
            }

            StartCoroutine(DestroyFish());
        }
    }

    private IEnumerator DestroyFish()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
