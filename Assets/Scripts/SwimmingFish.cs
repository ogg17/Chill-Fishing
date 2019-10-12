using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SwimmingFish : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fishRenderer;
    [SerializeField] private float speedSwimmingMax;
    [SerializeField] private float speedSwimmingMin;
    [SerializeField] private float board;

    private bool _direction; // 0 - right, 1 - left
    private bool _fishActive = true;
    private float _speedSwimming;
    private bool reloadFish;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        UpdateFish();
        StartCoroutine(Initialized());
    }
    private void UpdateFish()
    {
        animator.SetFloat("offset", Random.Range(0f, 1f));
        _speedSwimming = Random.Range(speedSwimmingMin, speedSwimmingMax);
        var randomPos = Random.Range(2, 9);
        transform.position = Random.Range(0, 2) == 0 ? 
            new Vector3(-board, CommonVariables.DepthHook - 0.2f * randomPos, 0) : 
            new Vector3(board, CommonVariables.DepthHook - 0.2f * randomPos, 0);
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
        transform.Translate(new Vector3(Time.deltaTime * (_direction ? -_speedSwimming : _speedSwimming), 0, 0));

        if (transform.position.y > CommonVariables.DepthHook)
        {
            if (_fishActive)
            {
                _fishActive = false;
                // CommonVariables.FishNumber--;
            }
            if (transform.position.y > CommonVariables.DepthHook + 0.2f) ReloadFish();
        }

        if (transform.position.x > board)
        {
            _direction = true;
            fishRenderer.flipX = true;
            if (reloadFish)
            {
                UpdateFish();
                reloadFish = false;
            }
        }
        else if (transform.position.x < -board)
        {
            _direction = false;
            fishRenderer.flipX = false;
            if (reloadFish)
            {
                UpdateFish();
                reloadFish = false;
            }
        }
    }

    private void DestroyFish()
    {
        Destroy(gameObject);
    }
}
