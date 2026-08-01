using Animal;
using UnityEngine;

public interface IAnimal
{
	public PandaLevelsConfig LevelsConfig { get;}
	public AnimalLevel CurrentLevel { get;}
	public GameObject Barn { get; set; }
	public SpriteRenderer CurrentSprite { get; set; }
	public Animator CurrentAnimator { get; set; }
}
