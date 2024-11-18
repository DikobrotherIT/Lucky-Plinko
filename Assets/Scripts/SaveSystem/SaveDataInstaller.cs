using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif
using UnityEngine.SceneManagement;

public class SaveDataInstaller : MonoBehaviour
{
    [SerializeField] private bool _fromTheBeginning;
    private bool _showTerms = true;

    private void Start()
    {
#if UNITY_IOS
        if (!PlayerPrefs.HasKey("Onboarding"))
        {
        Device.RequestStoreReview();
        }
#endif
        InstallBindings();
    }

    private void InstallBindings()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        BindFileNames();
        BindSettings();
        BindMoney();
        LoadScene();
    }


    private void LoadScene()
    {
        if (_showTerms)
        {
            if (PlayerPrefs.HasKey("Onboarding"))
            {
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                SceneManager.LoadScene("Onboarding");
            }
        }
        else
        {
            SceneManager.LoadScene("TestScene");
        }

    }

    private void BindMoney()
    {
        {
            var money = SaveSystem.LoadData<MoneySaveData>();

#if UNITY_EDITOR
            if (_fromTheBeginning)
            {
                money = null;
            }
#endif

            if (money == null)
            {
                money = new MoneySaveData(50000);
                SaveSystem.SaveData(money);
            }
            Wallet.SetStartMoney();

        }
    }

    private void BindSettings()
    {
        {
            var settings = SaveSystem.LoadData<SettingSaveData>();

#if UNITY_EDITOR
            if (_fromTheBeginning)
            {
                settings = null;
            }
#endif

            if (settings == null)
            {
                settings = new SettingSaveData(new List<bool> { true, false, false, false, false, false, false, false}, 0, new List<bool> { true, false}, 0, new List<bool> { true, false, false, false, false, false}, 0, true, true);
                SaveSystem.SaveData(settings);
            }

        }
    }

    private void BindFileNames()
    {
        FileNamesContainer.Add(typeof(SettingSaveData), FileNames.SettingsData);
        FileNamesContainer.Add(typeof(MoneySaveData), FileNames.MoneyData);
    }

   

}
