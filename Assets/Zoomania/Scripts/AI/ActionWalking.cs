using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ActionWalking
{
	public GameObject MoveArea { get; set; }
	public Camera MainCamera { get; set; }
    public Vector2 ScreenBounds { get; private set; }
	public Vector2 RandomPosition { get; private set; }
	public Vector2 AnimalPosition { get; set; }
	public bool IsMoving { get; set; }
	public float Speed { get; private set; } = 0.01f;

    public Timer WalkingTime = new Timer(0);

    public ActionWalking(GameObject _MoveArea)
    {
        MoveArea = _MoveArea;
    }


    public Vector2 GetRandomPointWithinBounds()                                             //Задается рандомная точка в пределах объекта MoveArea
	{
        float randomX = UnityEngine.Random.Range(MoveArea.transform.position.x - MoveArea.transform.localScale.x / 2, MoveArea.transform.position.x + MoveArea.transform.localScale.x / 2);
		float randomY = UnityEngine.Random.Range(MoveArea.transform.position.y - MoveArea.transform.localScale.y / 2, MoveArea.transform.position.y + MoveArea.transform.localScale.y / 2);

		return new Vector2(randomX, randomY);
    }

    public void Walking(GameObject animal)                                                  //Двигает панду к рандомно сгенерированной точке
    {
        IsMoving = true;
        AnimalPosition = new Vector2(animal.transform.position.x, animal.transform.position.y);
        RandomPosition = GetRandomPointWithinBounds();
        WalkingTime.SetMaxTimeAndReset(UnityEngine.Random.Range(3, 8));                      //Продолжительность этого действия
        Speed = Vector2.Distance(AnimalPosition, RandomPosition) / WalkingTime.MaxTime;
		return;
    }
}