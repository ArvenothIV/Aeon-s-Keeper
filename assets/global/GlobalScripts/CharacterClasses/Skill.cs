public class Skill : ModifiedStat {
	private bool known;							//if char knows skill

	public Skill(){
		known = false;							//all skills are not known at start
	}

	public bool Known{
		get{return known;}
		set{known = value;}
	}
}

public enum SkillName{
	Melee_Offence,								//temporary names
	Melee_Defence,
	Ranged_Offence,
	Ranged_Defence,
	Magic_Offence,
	Magic_Defence
}
