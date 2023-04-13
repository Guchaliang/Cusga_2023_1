using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntry : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            UIManager.Instance.ShowUI<EquipmentUI>("EquipmentUI");
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UIManager.Instance.GetUI<HpItemUI>("HpItemUI").ChangeHpValue(-10);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            UIManager.Instance.GetUI<HpItemUI>("HpItemUI").ChangeHpValue(10);
        }

    }
}
