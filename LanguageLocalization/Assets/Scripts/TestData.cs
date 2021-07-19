//Reference: https://www.youtube.com/watch?v=lku7f4KNFEo&ab_channel=DapperDino
//To solve the chinese font not showing problem: https://www.youtube.com/watch?v=NY1xKqCIj3c&ab_channel=Zolran
//If localization not work in build pls visit https://forum.unity.com/threads/solved-loading-localization-addressables-fails-in-android.830412/
//To import and export data to excel, pls visit https://docs.unity3d.com/Packages/com.unity.localization@0.9/manual/CSV.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class TestData : MonoBehaviour
{
    //"SmartStrings", update the text inside {}
    public string number = "1";

    public Dictionary<int, string> Languages = new Dictionary<int, string>();

    // This variable selects the language.
    // For example, if in the table your first language is English then 0 = English.
    // If the second language is Chinese then 1 = Chinese etc.
    public int Index;

    private void Awake()
    {
        StartCoroutine(SetLanguage());
    }

    public IEnumerator SetLanguage()
    {
        // Wait for the localization system to initialize, loading Locales, preloading, etc.
        yield return LocalizationSettings.InitializationOperation;

        for(int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            Debug.Log("Index: " + i + " Language: " + LocalizationSettings.AvailableLocales.Locales[i].name);
            Languages.Add(i, LocalizationSettings.AvailableLocales.Locales[i].name);
        }
    }

    public void SetEnglish()
    {
        foreach (var language in Languages)
        {
            if (language.Value == "English (en)")
            {
                Index = language.Key;
            }
        }

        // This part changes the language
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[Index];
    }

    public void SetChinese()
    {
        foreach (var language in Languages)
        {
            if (language.Value == "Chinese (Traditional) (zh-TW)")
            {
                Index = language.Key;
            }
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[Index];
    }
}
