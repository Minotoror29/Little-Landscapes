using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator _animator;
    private float _triggerTime;

    public void Initialize(Sprite sprite, float triggerTime)
    {
        spriteRenderer.sprite = sprite;
        _triggerTime = triggerTime + 0.1f;

        StartCoroutine(TriggerAnimation());
    }

    private IEnumerator TriggerAnimation()
    {
        yield return new WaitForSeconds(_triggerTime);

        _animator.SetTrigger("Trigger");
    }
}