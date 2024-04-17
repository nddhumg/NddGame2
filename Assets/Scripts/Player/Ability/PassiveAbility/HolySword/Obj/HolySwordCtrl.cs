using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolySwordCtrl : NddBehaviour {
	[SerializeField] protected HolySwordMove holySwordMove;
	[SerializeField] protected DmgSenderHolySword dmgSenderHolySword;
	public HolySwordMove HolySwordMove{
		get{ 
			return holySwordMove;
		}
	}
	public DmgSenderHolySword DmgSenderHolySword{
		get{ 
			return dmgSenderHolySword;
		}
	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		LoadHolySwordMove ();
		LoadDmgSenderHolySword ();
	}
	protected virtual void LoadHolySwordMove(){
		if (holySwordMove != null)
			return;
		holySwordMove = transform.GetComponentInChildren<HolySwordMove> ();
		Debug.LogWarning ("Add HolySwordMove", gameObject);
	}
	protected virtual void LoadDmgSenderHolySword(){
		if (dmgSenderHolySword != null)
			return;
		dmgSenderHolySword = transform.GetComponentInChildren<DmgSenderHolySword> ();
		Debug.LogWarning ("Add DmgSenderHolySword", gameObject);
	}
}
