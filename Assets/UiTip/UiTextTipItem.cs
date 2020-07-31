using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTextTipItem : MonoBehaviour
{
    public Text txt;

    public void SetUi(string content, float offsetY = 150f, float showTime = 1f)
    {
        txt.text = content;
        float posY = transform.localPosition.y;

        transform.DOLocalMoveY(posY + offsetY, showTime).OnComplete(
                    () =>
                    {
                        Destroy(gameObject);
                    }
                    );
    }
}
