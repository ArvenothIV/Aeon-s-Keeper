using UnityEngine;
using System.Collections;
using System;									//access enum class

public class BaseCharacter : MonoBehaviour {
	private string name1;
	private int level;
	private uint freeExp;

	private Attribute[] primaryAttribute;
	private Vital[] vital;
	private Skill[] skill;

	public void Awake(){
		name1 = string.Empty;
		level = 0;
		freeExp = 0;

		primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills();
	}

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	public string Name{
		get{return name1;}
		set{name1 = value;}
	}

	public int Level{
		get{return level;}
		set{level = value;}
	}

	public uint FreeExp{
		get{return freeExp;}
		set{freeExp = value;}
	}

	public void AddExp(uint exp){
		freeExp += exp;

		CalculateLevel();
	}

	//figure this one out later
	public void CalculateLevel(){

	}

	private void SetupPrimaryAttributes(){
		for(int cnt = 0; cnt < primaryAttribute.Length; cnt++){
			primaryAttribute[cnt] = new Attribute();
		}
	}

	private void SetupVitals(){
		for(int cnt = 0; cnt < vital.Length; cnt++){
			vital[cnt] = new Vital();
		}
	}

	private void SetupSkills(){
		for(int cnt = 0; cnt < skill.Length; cnt++){
			skill[cnt] = new Skill();
		}
	}

	public Attribute GetPrimaryAttribute(int index){
		return primaryAttribute[index];
	}

	public Vital GetVital(int index){
		return vital[index];
	}

	public Skill GetSkill(int index){
		return skill[index];
	}

	private void SetupVitalModifiers(){
		//health
		GetVital((int)VitalName.Health).AddModifer(new ModifyingStats(GetPrimaryAttribute((int)AttributeName.Vitality), 1.0f));
		//MP or energy whatever we call it
		GetVital((int)VitalName.Health).AddModifer(new ModifyingStats(GetPrimaryAttribute((int)AttributeName.Vitality), 1.0f));
	}

	private void SetupSkillModifiers(){
		//however we want to modify offence/defence
		//setup how you want the stat to modify offence/defence
		//which offence/defence it modifies
		//sample below
		GetSkill((int)SkillName.Melee_Offence).AddModifer(new ModifyingStats(GetPrimaryAttribute((int)AttributeName.Strength), 0.25f));
	}

	public void StatUpdate(){
		for(int cnt = 0; cnt < vital.Length; cnt++){
			vital[cnt].Update();
		}

		for(int cnt = 0; cnt < skill.Length; cnt++){
			skill[cnt].Update();
		}
	}
}
