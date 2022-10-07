using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPlayer : MonoBehaviour
{
    public PlayerInfoController playerInfoController;

    [Header("Required Objects")]
    public Text HpText;
    public RectTransform HpFill;

    public Text MpText;
    public RectTransform MpFill;

    public Text CoinText;

    private void Start()
    {
        playerInfoController = PlayerController.Instance.playerInfoController;
    }

    private void FixedUpdate()
    {
        if(playerInfoController?.ReloadDisplay == true)
        {
            SetHealth();
            SetManaPoint();
            SetCoin();
            playerInfoController.ReloadDisplay = false;
        }
    }

    public void SetHealth()
    {
        if (MpText == null)
        {
            Debug.LogWarning("CanvasPlayer missing 'HpText'");
            return;
        }
        HpText.text = $"{(int) playerInfoController.HealthPoint}";
        Vector2 amax = HpFill.anchorMax;
        amax.x = playerInfoController.HealthPointRate;
        HpFill.anchorMax = amax;
    }

    public void SetManaPoint()
    {
        if(MpText == null)
        {
            Debug.LogWarning("CanvasPlayer missing 'MpText'");
            return;
        }
        MpText.text = $"{(int) playerInfoController.ManaPoint}";
        Vector2 amax = MpFill.anchorMax;
        amax.x = playerInfoController.ManaPointRate;
        MpFill.anchorMax = amax;
    }

    public void SetCoin()
    {
        if(CoinText != null) CoinText.text = playerInfoController.Coin.ToString();
    }


}
