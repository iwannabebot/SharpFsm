﻿namespace SharpFsm
{
    using System;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;

    /// <summary>
    /// Represents a registry for conditions and side effects associated with transitions in a state machine.
    /// </summary>
    /// <typeparam name="TState">State Type</typeparam>
    /// <typeparam name="TContext">Context Type</typeparam>
    public class TransitionRegistry<TState, TContext>
    {
        /// <summary>
        /// Stores conditions that can be used to evaluate whether a transition can occur.
        /// </summary>
        public Dictionary<string, Func<TContext, bool>> Conditions { get; } = new Dictionary<string, Func<TContext, bool>>();

        /// <summary>
        /// Stores side effects that can be executed when a transition occurs.
        /// </summary>
        public Dictionary<string, Action<TContext, TState, TState>> SideEffects { get; } = new Dictionary<string, Action<TContext, TState, TState>>();

        /// <summary>
        /// Registers a condition with a name that can be used to evaluate transitions.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fn"></param>
        public void RegisterCondition(string name, Func<TContext, bool> fn) => Conditions[name] = fn;

        /// <summary>
        /// Registers a side effect with a name that can be executed when a transition occurs.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fn"></param>
        public void RegisterSideEffect(string name, Action<TContext, TState, TState> fn) => SideEffects[name] = fn;
    }
}
