using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CopyGameButton : MonoBehaviour
{
	[field: SerializeField] private GameObject GameButton;
	private RectTransform GameButtonTransform { get; set; }
	private RectTransform ThisTransform { get; set; }
	private Image image { get; set; }

	private void Start()
	{
		image = GetComponent<Image>();

		if (GameButton.GetComponent<Image>() != null) image.sprite = GameButton.GetComponent<Image>().sprite;
		else image.sprite = GameButton.GetComponent<SpriteRenderer>().sprite;

		//transform.position = GameButton.transform.position;
		Debug.Log(GameButton.transform.position);
		transform.localScale = GameButton.transform.localScale;
	}
}
