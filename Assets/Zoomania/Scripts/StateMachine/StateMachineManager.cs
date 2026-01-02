using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager
{
	private Dictionary<int, StateMachineState> States = new Dictionary<int, StateMachineState>();
	private StateMachineState CurrentState;

	public void AddState(int id, StateMachineState state) => States.Add(id, state);

	public void SetState(int id)
	{
		if (CurrentState != null && CurrentState.ID == id) return;

		CurrentState?.Exit();

		CurrentState = States[id];

		CurrentState.Enter();
	}
}
