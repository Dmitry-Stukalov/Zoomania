using UnityEngine;

public class ToggleObject : MonoBehaviour
{
	public GameObject targetObject;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			/*Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

			if (hit.collider != null)
			{
				if (hit.collider.CompareTag("Barn"))
				{
					targetObject.SetActive(false);
				}
				else if (hit.collider.CompareTag("Back"))
				{
					targetObject.SetActive(true);
				}
			}*/
		}
	}
}
