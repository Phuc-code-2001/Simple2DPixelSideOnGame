using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPlayer : MonoBehaviour
{
    public PlayerInfoController playerInfoController;

    [Header("Required Objects")]
    public Text HpText;
    public Image HpFill;

    public Text MpText;
    public Image MpFill;

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
        
        HpFill.fillAmount = playerInfoController.HealthPointRate;
    }

    public void SetManaPoint()
    {
        if(MpText == null)
        {
            Debug.LogWarning("CanvasPlayer missing 'MpText'");
            return;
        }
        MpText.text = $"{(int) playerInfoController.ManaPoint}";
        MpFill.fillAmount = playerInfoController.ManaPointRate;
    }

    public void SetCoin()
    {
        if(CoinText != null) CoinText.text = playerInfoController.Coin.ToString();
    }


}
