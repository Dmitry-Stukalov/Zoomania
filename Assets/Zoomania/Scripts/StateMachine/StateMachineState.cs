using UnityEngine;

public abstract class StateMachineState
{
	protected StateMachineManager StateManager;
	public int ID { get; set; }

	public StateMachineState(int id, StateMachineManager stateManager)
	{
		ID = id;
		StateManager = stateManager;
	}


	public virtual void Enter() { }

	public virtual void Exit() { }

	public virtual void Update() { }
}
