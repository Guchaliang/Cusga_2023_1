using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpItemUI : UIBase
{
    
    public float maxValue;
    public float Value;
    public float AnimationSpeed = 1f;

    public RectTransform topBar;
    public RectTransform bottomBar;
    public Text nameText;

    private float fullWidth;
    private float TargetWidth => Value * fullWidth / maxValue;

    private Coroutine adjustBarWidthCoroutine;

    private void Start()
    {
        fullWidth = topBar.rect.width;
    }


    //设置怪物名称
    public void SetName(string str)
    {
        nameText.text = str;
    }

    //设置怪物最大血量
    public void SetMax(int value)
    {
        maxValue = value;
        ChangeHpValue(maxValue);
    }

    

    //调节条形长度
    private IEnumerator AdjustBarWidth(float amount)
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
    public void ChangeHpValue(float amount)
    {
        Value = Mathf.Clamp(value: Value + amount, min: 0, maxValue);
        if (adjustBarWidthCoroutine != null)
        {
            StopCoroutine(adjustBarWidthCoroutine);
        }
        adjustBarWidthCoroutine = StartCoroutine(AdjustBarWidth(amount));
    }
    
}