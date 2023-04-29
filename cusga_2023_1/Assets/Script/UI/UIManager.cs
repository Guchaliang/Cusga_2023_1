using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;

public class UIManager : Singleton<UIManager>
{
    public Transform CanvasTransform;
    public Transform EventSys;

    public float HorizontalAxis;
    public float VerticalAxis;

    //用dictionary可能更好
    private List<UIBase> uiList;
    private void OnEnable()
    {
        CanvasTransform = GameObject.Find("UICanvas").GetComponent<Transform>();
        EventSys = GameObject.Find("EventSystem").GetComponent<Transform>();
        DontDestroyOnLoad(CanvasTransform.gameObject);
        DontDestroyOnLoad(EventSys.gameObject);
        uiList = new List<UIBase>();
    }

    public Transform GetCanvas()
    {
        return CanvasTransform;
    }




    //显示ui
    public UIBase ShowUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = FindUI(uiName);
        if (ui == null)
        {
            GameObject newUiobj = GameObject.Instantiate(Resources.Load("UI/" + uiName), CanvasTransform) as GameObject;

            newUiobj.name = uiName;

            ui = newUiobj.GetComponent<UIBase>();

            uiList.Add(ui);
        }
        else
        {
            ui.Show();
        }
        return ui;
    }

    //建立但不显示ui
    public UIBase CreateUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = FindUI(uiName);
        if (ui == null)
        {
            GameObject newUiobj = GameObject.Instantiate(Resources.Load("UI/" + uiName), CanvasTransform) as GameObject;

            newUiobj.name = uiName;

            ui = newUiobj.GetComponent<UIBase>();

            uiList.Add(ui);

            ui.Hide();
        }
        else
        {
            Debug.Log(uiName + "已经创建过了");
        }
        return ui;
    }


    //查找ui
    public UIBase FindUI(string uiName)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
            {
                return uiList[i];
            }
        }

        return null;
    }

    //UI是否存在且可见
    public bool ActiveExistUI(string uiName)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
            {
                if (uiList[i].gameObject.activeInHierarchy)
                {
                    return true;

                }
            }
        }

        return false;
    }

    //UI是否存在
    public bool ExistUI(string uiName)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
            {

                return true;


            }
        }

        return false;
    }

    //销毁所有ui
    public void CloseAllUI()
    {
        for (int i = uiList.Count - 1; i >= 0; i--)
        {

            GameObject.Destroy(uiList[i]);

        }
        uiList.Clear();
    }

    //隐藏ui
    public void HideUI(string uiName)
    {
        UIBase ui = FindUI(uiName);
        if (ui != null)
        {
            ui.Hide();
        }
        else
        {
            Debug.Log("uiList cannot find" + uiName);
        }
    }

    //销毁ui
    public void CloseUI(string uiName)
    {
        UIBase ui = FindUI(uiName);
        if (ui != null)
        {
            Debug.Log("取消ui" + uiName);

            Destroy(ui.gameObject);
            uiList.Remove(ui);
        }
        else
        {
            Debug.Log("uiList 里找不到" + uiName);
        }
    }

    //获取某个界面的脚本
    public T GetUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = FindUI(uiName);
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }
        return null;
    }



    //创建敌人血量条
   // public GameObject CreateHpItem(float MaxHp,float CurHp,Transform transform)
   // {
   //     GameObject obj = Instantiate(Resources.Load("UI/HpItem"),transform) as GameObject;
   //     //设置为父级的第一位
   //     obj.transform.SetAsFirstSibling();
   //     obj.GetComponent<HpItemUI>().maxValue = MaxHp;
   //     obj.GetComponent<HpItemUI>().Value = CurHp;
   //
   //     return obj;
   // }

    //提示界面
    public void ShowTip(string msg, Color color, System.Action callback = null)
    {
        GameObject obj = Instantiate(Resources.Load("UI/Tips"), CanvasTransform) as GameObject;
        Text text = obj.transform.Find("bg/Text").GetComponent<Text>();
        text.color = color;
        text.text = msg;
        Tween scale1 = obj.transform.Find("bg").DOScaleY(1, 0.4f);
        Tween scale2 = obj.transform.Find("bg").DOScaleY(0, 0.4f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate ()
        {
            if (callback != null)
            {
                callback();
            }
        });
        MonoBehaviour.Destroy(obj, 2);
    }
    public void BiggerAndReturn(GameObject gameObject, Vector3 initScale)
    {
        gameObject.transform.DOScale(new Vector3(initScale.x * 1.5f, initScale.y * 1.5f, initScale.z * 1.5f), 0.2f).OnComplete(() =>
        {
            gameObject.transform.DOScale(new Vector3(initScale.x, initScale.y, initScale.z), 0.2f);
        });
    }

}
