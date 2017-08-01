﻿using UnityEngine;
using System.Collections;

namespace AxlPlay {
	[System.Serializable]
	public class FsmGameObject : FsmVariable{
		[SerializeField]
		private GameObject value;
		public GameObject Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}
		
		[SerializeField]
		private string scenePath;
		public string ScenePath {
			get {
				return this.scenePath;
			}
			set {
				this.scenePath=value;
			}
		}
		
		public override System.Type VariableType {
			get {
				return typeof(GameObject);
			}
		}
		
		public override void SetValue (object value)
		{
			this.value = (GameObject)value;
			if (m_OnVariableChange != null) {
				m_OnVariableChange.Invoke (this.value);
			}
		}
		
		public override object GetValue ()
		{
			return this.value;
		}
		
		public static implicit operator GameObject(FsmGameObject value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmGameObject(GameObject value) { 
			var variable = ScriptableObject.CreateInstance<FsmGameObject>();
			variable.SetValue(value);
			return variable; 
		}
	}	
}