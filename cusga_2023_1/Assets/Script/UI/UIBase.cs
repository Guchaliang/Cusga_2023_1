using System;
using UnityEngine;
using UnityEngine.UI;


public class UIBase : MonoBehaviour
{
    //×¢²áÊÂ¼þ
    public UIEventTrigger Register(string name)
    {
        Transform tf = transform.Find(name);
        return UIEventTrigger.Get(tf.gameObject);
    }


    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);

    }
}