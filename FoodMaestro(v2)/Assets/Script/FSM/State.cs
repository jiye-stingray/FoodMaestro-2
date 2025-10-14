using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    protected StateMachine<T> _stateMachine;
    protected T _context;

    public void SetMachineAndContext(StateMachine<T> stateMachine, T context)
    { 
        _stateMachine = stateMachine;
        _context = context;
    }

    public abstract void OnEnter();
    public abstract void Update();
    public abstract void OnExit();
}
