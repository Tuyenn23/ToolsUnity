using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimCoin : MonoBehaviour
{
    public List<CoinElement> L_coin;

    public int _coinPerElement;

    Coroutine C_Coin;

    private void OnEnable()
    {
        ActiveAllElement();
        InitCoinPerElement();
        C_Coin = StartCoroutine(IE_animCoin());
    }

    private void ActiveAllElement()
    {
        for (int i = 0; i < L_coin.Count; i++)
        {
            L_coin[i].gameObject.SetActive(true);
        }
    }

    private void InitCoinPerElement()
    {
        int reward = PrefabStorage.Instance.CurrentEnemy._reWard * 5;
        _coinPerElement = reward / 10;
    }

    IEnumerator IE_animCoin()
    {
        for (int i = 0; i < L_coin.Count; i++)
        {
            L_coin[i].Move();
            yield return new WaitForSeconds(0.15f);
        }

        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(C_Coin);
    }

}
