using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public void LoadCharacterPosition()
    {
        if (GameManager.Instance?.SelectedRecord == null) return;
        if (PlayerController.Instance == null) return;

        float px = GameManager.Instance.SelectedRecord.PositionX;
        float py = GameManager.Instance.SelectedRecord.PositionY;
        Vector2 pos = new Vector2(px, py);
        PlayerController.Instance.rb.position = pos;

    }

}
