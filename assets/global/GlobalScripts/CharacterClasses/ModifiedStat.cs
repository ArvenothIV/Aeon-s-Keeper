using System.Collections.Generic;

//will be used to calculate how base stats modify combat info and anything else needed
public class ModifiedStat : BaseStat {
	private List<ModifyingStats> mods;          //list of attributes that modify stat
	private int modValue;						//base value added from modifier

	public ModifiedStat(){
		mods = new List<ModifyingStats> ();
		modValue = 0;
		}

	public void AddModifer(ModifyingStats mod){
		mods.Add (mod);	
	}

	private void CalculateModValue(){
		modValue = 0;							

		if (mods.Count > 0)
			foreach (ModifyingStats att in mods)
				modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
	}

	public new int AdjustedBaseValue{
		get{return BaseValue + BuffValue + modValue;}
	}

	public void Update(){
		CalculateModValue();
	}
}

public struct ModifyingStats{
	public Attribute attribute;
	public float ratio;

	public ModifyingStats(Attribute att, float rat){
		attribute = att;
		ratio = rat;
	}
}