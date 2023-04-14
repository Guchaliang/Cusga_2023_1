using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoginUI : UIBase
{
    private void Awake()
    {
        Register("Btns/startBtn").onClick = OnStartBtn;      
        Register("Btns/collectionBtn").onClick = OnCollectionBtn;      
        Register("Btns/settingBtn").onClick = OnSettingBtn;      
        Register("Btns/quitBtn").onClick = OnQuitBtn;      
    }

    private void OnStartBtn(GameObject obj, PointerEventData data)
    {
        Close();
        Time.timeScale = 1;
        UIManager.Instance.ShowUI<HpItemUI>("HpItemUI");
        UIManager.Instance.CreateUI<BagUI>("BagUI");
        SceneManager.LoadScene("Game1.0");
    }

    private void OnCollectionBtn(GameObject obj, PointerEventData data)
    {
        UIManager.Instance.ShowUI<CollectionUI>("CollectionUI");
    }

    private void OnSettingBtn(GameObject obj, PointerEventData data)
    {
        UIManager.Instance.ShowUI<SettingUI>("SettingUI");
    }
    private void OnQuitBtn(GameObject obj, PointerEventData data)
    {
        Application.Quit();
    }
}
