using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public enum PopUpType
{
    Damage,
    HealthHp,
    HealMp,
}

[Serializable]
public struct PopUpColorDefine
{
    [SerializeField] public PopUpType Type;
    [SerializeField] public Color Color;
}

public class PopUp : MonoBehaviour
{
    [SerializeField] TextMeshPro mText;
    [SerializeField] List<PopUpColorDefine> mPopUpColorDefine;

    public void SetUp(Vector2 position, string text, PopUpType type)
    {
        transform.position = position;
        mText.text = text;
        // mText.color = mPopUpColorDefine.FirstOrDefault(e => e.Type == type).Color;
        mText.material.color = mPopUpColorDefine.FirstOrDefault(e => e.Type == type).Color;
    }

    [SerializeField] float timeExist = 0.5f;
    [SerializeField] float speedMove = 2f;

    private void OnEnable()
    {
        StartCoroutine(Handle());
    }

    IEnumerator Handle()
    {
        yield return new WaitForSeconds(timeExist);
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(gameObject.activeInHierarchy)
        {
            Vector2 target = (Vector2.up + Vector2.right * UnityEngine.Random.Range(-1, 2))
                + (Vector2) transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, speedMove * Time.fixedDeltaTime);
        }
    }

}
