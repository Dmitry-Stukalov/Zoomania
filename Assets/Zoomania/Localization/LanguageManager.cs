using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.Localization;


public class LanguageManager : MonoBehaviour
{
	[SerializeField] private TMP_Dropdown dropdown;

	private List<Locale> locales;

	async void Start()
	{
		await LocalizationSettings.InitializationOperation.Task;

		dropdown = GetComponent<TMP_Dropdown>();

		await LocalizationSettings.InitializationOperation.Task;

		locales = LocalizationSettings.AvailableLocales.Locales.ToList();
		SetupDropdown();
		SelectSavedLanguage();
	}

	void SetupDropdown()
	{
		dropdown.ClearOptions();
		foreach (var locale in locales)
		{
			dropdown.options.Add(new TMP_Dropdown.OptionData(locale.name.ToUpper()));
		}
		dropdown.onValueChanged.AddListener(OnDropdownChanged);
		dropdown.RefreshShownValue();
	}

	void SelectSavedLanguage()
	{
		string saved = PlayerPrefs.GetString("selected-locale", "be");
		int index = locales.FindIndex(l => l.Identifier.Code == saved);
		if (index >= 0) dropdown.value = index;
	}

	void OnDropdownChanged(int index)
	{
		if (index >= 0 && index < locales.Count)
		{
			SwitchToLocale(locales[index]);
		}
	}

	void SwitchToLocale(Locale locale)
	{
		LocalizationSettings.SelectedLocale = locale;
		Debug.Log($"язык изменен на: {locale.name}");
	}
}