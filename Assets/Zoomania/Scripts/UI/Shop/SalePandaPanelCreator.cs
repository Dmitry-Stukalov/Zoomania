using UnityEngine;

public class SalePandaPanelCreator : MonoBehaviour
{
	[SerializeField] private Barn _Barn;
	[SerializeField] private GameObject Panel;

	private void Start()
	{
		_Barn.Spawn += CreatePanel;
	}

	private void CreatePanel()
	{
		Instantiate(Panel, transform);
	}

	public void DeletePanel(GameObject panel) => Destroy(panel);
}
