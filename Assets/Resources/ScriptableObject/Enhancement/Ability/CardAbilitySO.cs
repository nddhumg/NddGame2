using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "SO/EnhancementCard/Ability" +"")]
public class CardAbilitySO : ScriptableObject {
	public UnlockAbilityPlayer.NameAbilityLock nameAbility ;
	public int level = 1;
	public string explain;
}
