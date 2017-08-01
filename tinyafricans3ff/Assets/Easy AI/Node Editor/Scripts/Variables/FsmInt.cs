﻿using UnityEngine;
using System.Collections;

namespace AxlPlay{
	[System.Serializable]
	public class FsmInt : FsmVariable{
		[SerializeField]
		private int value;
		public int Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}
		
		public override System.Type VariableType {
			get {
				return typeof(int);
			}
		}
		
		public override void SetValue (object value)
		{
			this.value = System.Convert.ToInt32(value);
			if (m_OnVariableChange != null) {
				m_OnVariableChange.Invoke (this.value);
			}
		}
		
		public override object GetValue ()
		{
			return this.value;
		}
		
		public static implicit operator int(FsmInt value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmInt(int value) { 
			var variable = ScriptableObject.CreateInstance<FsmInt>();
			variable.SetValue(value);
			return variable; 
		}
	}
 
 
}