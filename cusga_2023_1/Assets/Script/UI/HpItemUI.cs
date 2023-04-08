using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class RectTransformEx
{
    public static void SetWidth(this RectTransform t, float width)
    {
        t.sizeDelta = new Vector2(width, t.rect.height);
    }
}

public class HpItemUI : UIBase
{

    public float maxValue;
    public float Value;
    public float AnimationSpeed = 1f;

    public RectTransform topBar;
    public RectTransform bottomBar;

    private float fullWidth;
    private float TargetWidth => Value * fullWidth / maxValue;

    private Coroutine adjustBarWidthCoroutine;

    private void Start()
    {
        fullWidth = topBar.rect.width;
    }

    //调节条形长度
    private IEnumerator AdjustBarWidth(int amount)
    {
        //当数值大于0时 底层条形快速变换 顶层条形缓慢变换(回复状态)
        //当数值小于0时 顶层条形快速变换 底层条形缓慢变换(扣除状态)
        var suddenChangeBar = amount >= 0 ? bottomBar : topBar;
        var slowChangeBar = amount >= 0 ? topBar : bottomBar;

        suddenChangeBar.SetWidth(TargetWidth);
        while (Mathf.Abs(f: suddenChangeBar.rect.width - slowChangeBar.rect.width) > 1f)
        {
            slowChangeBar.SetWidth(Mathf.Lerp(slowChangeBar.rect.width, TargetWidth, Time.deltaTime * AnimationSpeed));
            yield return null;
        }
        slowChangeBar.SetWidth(TargetWidth);
    }
    public void ChangeHpValue(int amount)
    {
        Value = Mathf.Clamp(value: Value + amount, min: 0, maxValue);
        if (adjustBarWidthCoroutine != null)
        {
            StopCoroutine(adjustBarWidthCoroutine);
        }
        adjustBarWidthCoroutine = StartCoroutine(AdjustBarWidth(amount));
    }
    
}