using UnityEngine;
using UnityEngine.UI;

public class CopyAnimalSprite : MonoBehaviour
{
	[field: SerializeField] private Barn _barn;
	[field: SerializeField] private Image _image;

	private void Start()
	{
		_barn.Spawn += CopySprite;
		CopySprite();
	}

	private void CopySprite()
	{
		_image.sprite = _barn.Animals[_barn.Animals.Count - 1].GetComponent<Animals>().CurrentLevel.View;
	}
}
