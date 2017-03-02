
public static var b_openMenu : boolean;

public var customSkin : GUISkin;
public var t_hero : Texture;
public var t_statusBox1 : Texture;
public var t_statusBox2 : Texture;
public var t_skillBox : Texture;
public var fullHP : int = 9999;
public var fullMP : int = 999;
public var currentHP : int = 9999;
public var baseWeaponHP : int = 9999;
public var currentMP : int = 999;
public var baseWeaponMP : int = 9999;
public var currentLV : int = 99;
public var currentEXP : int = 9999999;
public var currentNEXT : int = 99999;
public var currentATK : int = 999;
public var baseWeaponATK : int = 9999;
public var baseArmorATK : int = 9999;
public var baseHelmATK : int = 9999;
public var currentDEF : int = 999;
public var baseWeaponDEF : int = 9999;
public var currentAGI : int = 999;
public var baseWeaponAGI : int = 9999;
public var baseArmorAGI : int = 9999;
public var baseHelmAGI : int = 9999;
public var currentINT : int = 999;
public var baseWeaponINT : int = 9999;
public var baseArmorINT : int = 9999;
public var baseHelmINT : int = 9999;
public var currentLUC : int = 999;
public var baseWeaponLUC : int = 9999;
public var baseArmorLUC : int = 9999;
public var baseHelmLUC : int = 9999;
public var hasSword : boolean = false;
public var hasArmor : boolean = false;
public var hasHelm : boolean = false;
public var hasBow : boolean = false;
public var hasStaff : boolean = false;
public var hasNothing : boolean = true;
public var inventorySize : int = 0;
public var currentGold : int = 0;
public var itemlistSwordName : String;
public var itemlistBowName : String;
public var itemlistStaffName : String;
public var itemlistArmorName : String;
public var itemlistHelmName : String;
//strength
public var itemlistSwordStrength : int;
public var itemlistBowStrength : int;
public var itemlistStaffStrength : int;
public var itemlistArmorStrength : int;
public var itemlistHelmStrength : int;
//agil
public var itemlistSwordAgil : int;
public var itemlistBowAgil : int;
public var itemlistStaffAgil : int;
public var itemlistArmorAgil : int;
public var itemlistHelmAgil : int;
//intel
public var itemlistSwordIntel : int;
public var itemlistBowIntel : int;
public var itemlistStaffIntel : int;
public var itemlistArmorIntel : int;
public var itemlistHelmIntel : int;
//luck
public var itemlistSwordLuck : int;
public var itemlistBowLuck : int;
public var itemlistStaffLuck : int;
public var itemlistArmorLuck : int;
public var itemlistHelmLuck : int;
public var equipped : boolean;

public var a_weapons : Item[];
public var a_armors : Item[];
public var a_accessories : Item[];
public var a_items : Item[];
public var a_skills : Texture[];

private var currentWeapon : Item;
private var currentArmor : Item;
private var currentAccessory : Item;
private var currentItem: Item;
private var currentSkill : Texture;

private var s_unequip : String = "UNEQUIP";
private var s_none : String = "NONE";

//Status Tab
private var maxHP : int = 9999;
private var maxMP : int = 999;
private var maxLV : int = 99;
private var maxEXP : int = 9999999;
private var maxNEXT : int = 99999;
private var maxATK : int = 999;
private var maxDEF : int = 999;
private var maxAGI : int = 999;
private var maxINT : int = 999;
private var maxLUC : int = 999;

//Rect position on the GUI
private var r_statTexture1 : Rect = new Rect(252, 77, 331, 125);
private var r_statTexture2 : Rect = new Rect (252, 244, 331, 142);
private var r_hpLabel : Rect = new Rect(313, 75, 120, 25);
private var r_mpLabel : Rect = new Rect(313, 100, 120, 25);
private var r_lvLabel : Rect = new Rect (313, 124, 120, 25);
private var r_expLabel : Rect = new Rect (313, 150, 120, 25);
private var r_nextLabel : Rect = new Rect (313, 177, 120, 25);
private var r_atkLabel : Rect = new Rect (529, 75, 50, 25);
private var r_defLabel : Rect = new Rect (529, 100, 50, 25);
private var r_agiLabel : Rect = new Rect (529, 124, 50, 25);
private var r_intLabel : Rect = new Rect (529, 150, 50, 25);
private var r_lucLabel : Rect = new Rect (529, 177, 50, 25);
private var r_statBox : Rect = new Rect (237, 67, 360, 147);
private var r_weaponBox : Rect = new Rect (237, 230, 360, 207);
private var r_weaponLabel : Rect = new Rect (252, 264, 180, 40);
private var r_armorLabel : Rect = new Rect (252, 324, 180, 40);
private var r_accessLabel : Rect = new Rect (252, 386, 180, 40);
private var r_skillTexture : Rect = new Rect (464, 288, 119, 117);
private var r_skillBox : Rect = new Rect (460, 284, 127, 125);
//GUIContent
private var gui_weaponCon : GUIContent;
private var gui_armorCon : GUIContent;
private var gui_accessCon : GUIContent;
private var gui_skillCon : GUIContent;


public var in_toolbar : int = 0;
private var s_toolbars : String[] = ["STATUS", "INVENTORY", "EQUIPMENT"];
private var r_hero : Rect = new Rect (19, 50, 200, 400);
private var r_window : Rect = new Rect (10, 10, 640, 480);
private var r_closeBtn : Rect = new Rect (598, 8, 26, 22);
private var r_tabButton : Rect = new Rect (35, 15, 480, 40);

private var r_itemBox : Rect = new Rect (237, 67, 360, 247);
private var r_tipBox : Rect = new Rect (237, 330, 360, 107);
private var r_itemsButton : Rect = Rect (257, 87, 340, 227);
private var r_tipButton : Rect = new Rect (257, 350, 340, 87);
private var r_verScroll : Rect = new Rect (600, 87, 20, 227);
private var f_scrollPos : float = 1.0;
private var scrollPosition : Vector2 = Vector2.zero;
private var scrollPosition2 : Vector2 = Vector2.zero;
private var in_toolItems : int = 0;

//Equipment
private var r_equipBox : Rect = new Rect (237, 67, 360, 207);
private var r_equipWeaponBox : Rect = new Rect (237, 280, 360, 157);
private var r_statTextureEquip : Rect = new Rect (252, 81, 331, 142);
private var r_skillBoxEquip : Rect = new Rect (460, 121, 127, 125);

//Position of each equip button from 0-weapon 1-armor 2-accessory 3-skill
private var r_equipRect : Rect[] = [new Rect (252, 101, 180, 40), new Rect (252, 161, 180, 40), new Rect (252, 221, 180, 40), new Rect (464, 125, 119, 117)];
private var r_equipWindow : Rect = new Rect (500, 0, 70, 100);
private var scrollPosition3 : Vector2 = Vector2.zero;
private var scrollPosition4 : Vector2 = Vector2.zero;
private var scrollPosition5 : Vector2 = Vector2.zero;
private var scrollPosition6 : Vector2 = Vector2.zero;
private var a_equipBoolean : boolean[] = new boolean[4];
private var in_toolWeapons : int = 0;
private var in_toolArmors : int = 0;
private var in_toolAccess : int = 0;
private var in_toolskill : int = 0; 
private var toggled : boolean = false;

function Awake() : void{
	DontDestroyOnLoad (this.gameObject);
}
function Start () : void {
	b_openMenu = false;
	
	gui_weaponCon = GUIContent(s_unequip);
	gui_armorCon = GUIContent(s_unequip);
	gui_accessCon = GUIContent(s_unequip);
	gui_skillCon = GUIContent("");
	
	if(a_items.Length > 0){
		a_items[0].setUpItemName();
		currentItem = a_items[0];
	}
	
	//boolean equipment
	for (var i : int = 0; i<a_equipBoolean.length;i++){
		a_equipBoolean[i] = false;
	}
}


function Update () : void {
	if(Input.GetKeyDown(KeyCode.M)){
		b_openMenu = !b_openMenu;
	}
	
	if(currentNEXT <= 0){
		currentNEXT = 100;
		fullHP += 50;
		fullMP += 50;
		baseWeaponATK += 10;
		baseWeaponAGI += 10;
		baseWeaponINT += 10;
		baseWeaponLUC += 1;
		baseArmorATK += 10;
		baseArmorAGI += 10;
		baseArmorINT += 10;
		baseArmorLUC += 1;
		baseHelmATK += 10;
		baseHelmAGI += 10;
		baseHelmINT += 10;
		baseHelmLUC += 1;
		
		currentLV++;
		
	}
}

public function OnGUI () : void {
	GUI.skin = customSkin;
	if(b_openMenu){
		r_window = GUI.Window(0, r_window, DoMyWindow, "");
		r_window.x = Mathf.Clamp(r_window.x, 0.0, Screen.width - r_window.width);
		r_window.y = Mathf.Clamp(r_window.y, 0.0, Screen.height - r_window.height);
	}
}

class Item{
	public var icon : Texture;
	public var name : String;
	public var amount : int;
	
	private var itemName : String;
	
	public function setUpItemName () : void {
		var in_length : int = (this.name.length + this.amount.ToString().Length);
			if(in_length < 25) {
				while (this.name.Length < 17){
					this.name += " ";
				}
			}
			if(this.amount < 10) {
				itemName = (this.name + " " + this.amount.ToString());
			} else{
				itemName = (this.name + this.amount.ToString());
			}
		}
		
		public function get itemNA () : String{
			return itemName;
		}
	}
	

private function DoMyWindow (windowID : int) : void {
	in_toolbar = GUI.Toolbar (r_tabButton, in_toolbar, s_toolbars, GUI.skin.GetStyle("Tab Button"));
	
	switch (in_toolbar) {
		case 0 :
			StatusWindow();
			break;
		case 1 :
			ItemWindow();
			break;
		case 2:
			EquipWindow();
			break;
	}
	
	GUI.DrawTexture(r_hero, t_hero);
	
	if (GUI.Button (r_closeBtn, "", GUI.skin.GetStyle("Exit Button"))) {
		b_openMenu = false;
	}
	
	GUI.DragWindow();
}

//create arrays to hold info about weapons in inventory
//include info about if it's equipped or not
//add to these methods the object argument to grab all the parameters
public function getSword() : void{
	hasSword = true;
	hasBow = false;
	hasStaff = false;
	
}
public function getArmor() : void{
	hasArmor = true;
	//set name

}
public function getHelm() : void{
	hasHelm = true;
	//set name

}
public function getBow() : void {
	hasBow = true;
	hasSword = false;
	hasStaff = false;

}
public function getStaff() : void {
	hasStaff = true;
	hasBow = false;
	hasSword = false;
}

private function StatusWindow() : void {
	GUI.Box (r_statBox, "");
	GUI.Box (r_weaponBox, "");
	GUI.DrawTexture(r_statTexture1, t_statusBox1);
	GUI.DrawTexture(r_statTexture2, t_statusBox2);
	GUI.DrawTexture(r_skillBox, t_skillBox);
	
	CheckMax();
	
	GUI.Label(r_hpLabel, currentHP.ToString() + "/" + fullHP.ToString(), "Text Amount");
	GUI.Label(r_mpLabel, currentMP.ToString() + "/" + fullMP.ToString(), "Text AMount");
	GUI.Label(r_lvLabel, currentLV.ToString(), "Text Amount");
	GUI.Label(r_expLabel, currentEXP.ToString(), "Text Amount");
	GUI.Label(r_nextLabel, currentNEXT.ToString(), "Text Amount");
	GUI.Label(r_atkLabel, currentATK.ToString(), "Text Amount");
	GUI.Label(r_defLabel, currentDEF.ToString(), "Text Amount");
	GUI.Label(r_agiLabel, currentAGI.ToString(), "Text Amount");
	GUI.Label(r_intLabel, currentINT.ToString(), "Text Amount");
	GUI.Label(r_lucLabel, currentLUC.ToString(), "Text Amount");
	
	GUI.Label(r_weaponLabel, gui_weaponCon, "Text Item");
	GUI.Label(r_armorLabel, gui_armorCon, "Text Item");
	GUI.Label(r_accessLabel, gui_accessCon, "Text Item");
	GUI.Label(r_skillTexture, gui_skillCon, "Text Item");
}

private function CheckMax () : void {
	fullHP = Mathf.Clamp(fullHP, 0.0, maxHP);
	fullMP = Mathf.Clamp(fullMP, 0.0, maxMP);
	currentHP = Mathf.Clamp(currentHP, 0.0, fullHP);
	currentMP = Mathf.Clamp(currentMP, 0.0, fullMP);
	currentLV = Mathf.Clamp(currentLV, 0.0, maxLV);
	currentEXP = Mathf.Clamp(currentEXP, 0.0, maxEXP);
	currentNEXT = Mathf.Clamp(currentNEXT, 0.0, maxNEXT);
	currentATK = Mathf.Clamp(currentATK, 0.0, maxATK);
	currentDEF = Mathf.Clamp(currentDEF, 0.0, maxDEF);
	currentAGI = Mathf.Clamp(currentAGI, 0.0, maxAGI);
	currentINT = Mathf.Clamp(currentINT, 0.0, maxINT);
	currentLUC = Mathf.Clamp(currentLUC, 0.0, maxLUC);
}


private function ItemWindow() : void {
	//change this to count of items in inv
	var in_items : int = 3;
	//Create Item information box
	GUI.Box (r_itemBox, "");
	GUI.Box (r_tipBox, "");
	scrollPosition = GUI.BeginScrollView (new Rect (257, 87, 320, 200), scrollPosition, new Rect(0, 0, 280, 40*in_items));
	//add label to go inside scroll view
	var itemsContent : GUIContent[] = new GUIContent[in_items];
	//create GUIContent array of key items, can use item array instead of current item
	/*for( var i: int = 0; i<in_items; i++) {
		if(a_items.Length> 0) {
			if(i == 0) {
			itemsContent[i] = GUIContent(currentItem.itemNA, a_items[0].icon, "Lorem ipsum dolor sit amet, consectetur adipicicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");
		}else{
		 itemsContent[i] = GUIContent(currentItem.itemNA, a_items[1].icon, "This is a key " + i);
		 }
		 }else{
		itemsContent[i] = GUIContent("NONE", "");
		}
	}*/
	//add conditions to see if actually in inv
	//check which item it is
	if(hasNothing){
	itemsContent[0] = GUIContent("empty",  "you have nothing");
	}
	if(hasSword){
		itemsContent[0] = GUIContent(itemlistSwordName, a_items[0].icon, "An unbelievably gorgeous and weak sword\nGives + 10 Attack ");
		hasNothing = false;
		//inventorySize++;
	}
    if(hasStaff){
		itemsContent[0] = GUIContent(itemlistStaffName, a_weapons[2].icon, "Common Staff\nGives + 10 Attack ");
		hasNothing = false;
		//inventorySize++;
	}
	if(hasBow){
		itemsContent[0] = GUIContent(itemlistBowName, a_weapons[1].icon, "Common Bow\nGives + 10 Attack ");
		hasNothing = false;
		//inventorySize++;
	}
	if(hasArmor){
		itemsContent[1] = GUIContent(itemlistArmorName, a_items[1].icon, "A sturdy armor\nGives +10 Armor ");
		hasNothing = false;
		//inventorySize++;
	}

	else{
		itemsContent[1] = GUIContent("empty", "you have nothing");
	}
	if(hasHelm){
		itemsContent[2] = GUIContent(itemlistHelmName, a_items[2].icon, "A stylish helm\nGives +10 Armor ");
		hasNothing = false;
		//inventorySize++;
	}
	else{
		itemsContent[2] = GUIContent("empty", "you have nothing");
	}
	//itemsContent[0] = GUIContent(currentItem.itemNA, a_items[0].icon, "A fairly weak sword\nGives + 10 Attack ");
	//itemsContent[1] = GUIContent(currentItem.itemNA, a_items[1].icon, "A sturdy armor\nGives +10 Armor ");
	//itemsContent[2] = GUIContent(currentItem.itemNA, a_items[2].icon, "A stylish helm\nGives +10 Armor ");
	
	//create grid button here
	//keep track of total items in inv for display of scroll
	in_toolItems = GUI.SelectionGrid (Rect (0, 0, 280, 40*in_items), in_toolItems, itemsContent, 1, GUI.skin.GetStyle("Selected Item"));
	GUI.EndScrollView();
	//Check if there is item info
	var s_info : String = itemsContent[in_toolItems].tooltip;
	if(s_info ==""){
		s_info = "Show items information here";
	}
	var style : GUIStyle = GUI.skin.GetStyle("Label");
	if(GUI.tooltip != "") {
		//Get height from this style
		var f_height : float = style.CalcHeight(GUIContent(GUI.tooltip), 330.0);
		scrollPosition2 = GUI.BeginScrollView (new Rect (257, 343, 320, 75), scrollPosition2, new Rect(0, 0, 280, f_height));
		GUI.Label(new Rect (0, 0, 280, f_height), GUI.tooltip);
	}	else{
		//Get height
		f_height = style.CalcHeight(GUIContent(s_info), 330.0);
		scrollPosition2 = GUI.BeginScrollView (new Rect (257, 343, 320, 75), scrollPosition2, new Rect (0, 0, 280, f_height));
		GUI.Label(new Rect (0, 0, 280, f_height), s_info);
	}	GUI.EndScrollView();
}

private function EquipWindow() : void {
	GUI.Box (r_equipBox, "");
	GUI.Box (r_equipWeaponBox, "");
	GUI.DrawTexture(r_statTextureEquip, t_statusBox2);
	GUI.DrawTexture(r_skillBoxEquip, t_skillBox);
	
	SetupEquipBox();
}

private function SetupEquipBox() : void {
	var equipContent : GUIContent[] = [gui_weaponCon, gui_armorCon, gui_accessCon, gui_skillCon];
		for(var i: int=0; i<a_equipBoolean.length;i++) {
			if(a_equipBoolean[i] == true) {
				GUI.Label(r_equipRect[i], equipContent[i], "Disabled Click");
				
				switch(i) {
				case 0:
					ShowWeapon();
					break;
				case 1:
					ShowArmor();
					break;
				case 2:
					ShowAccess();
					break;
				case 3:
					ShowSkill();
					break;
				}
			}else{
				if (GUI.Button(r_equipRect[i], equipContent[i], "Selected Item")){
					a_equipBoolean[i] = true; 
					
					for (var j : int = 0; j<a_equipBoolean.length;j++){
						if(i!=j){
							a_equipBoolean[j] = false;
						}
				}
			}
		}
	}
}

private function ShowWeapon () : void {
	var in_items : int = 2;
	var itemsContent : GUIContent[] = new GUIContent[in_items];
	
	for(var i: int = 0;i<in_items;i++){
		if(i==0){
		itemsContent[i] = GUIContent(s_unequip, "");
		}else{
			if(hasSword){
				itemsContent[i] = GUIContent(itemlistSwordName, a_weapons[0].icon);
				
			}
			else if(hasBow){
				itemsContent[i] = GUIContent(itemlistBowName, a_weapons[1].icon);
			}
			else if(hasStaff){
				itemsContent[i] = GUIContent(itemlistStaffName, a_weapons[2].icon);
			}
			else{
			itemsContent[i] = GUIContent("empty", "you have nothing");
			}
		}
	}
	scrollPosition3 = GUI.BeginScrollView (new Rect (257, 300, 320, 120), scrollPosition3, new Rect (0, 0, 280, 40*in_items));
	
	in_toolWeapons = GUI.SelectionGrid (Rect (0, 0, 280, 40*in_items), in_toolWeapons, itemsContent, 1, GUI.skin.GetStyle("Selected Item"));
	GUI.EndScrollView();
	
	gui_weaponCon = itemsContent[in_toolWeapons];
}

private function ShowArmor () : void {
	var in_items : int = 2;
	var itemsContent : GUIContent[] = new GUIContent[in_items];
	
	for(var i: int = 0; i<in_items; i++){
		if(i==0){
		itemsContent[i] = GUIContent(s_unequip, "");
		}else{
			if(hasArmor){
				itemsContent[i] = GUIContent(itemlistArmorName, a_armors[0].icon);
			}else{
			itemsContent[i] = GUIContent("empty", "you have nothing");
			}
		}
	}
	scrollPosition3 = GUI.BeginScrollView (new Rect (257, 300, 320, 120), scrollPosition3, new Rect (0, 0, 280, 40*in_items));
	
	in_toolArmors = GUI.SelectionGrid(Rect (0, 0, 280, 40*in_items), in_toolArmors, itemsContent, 1, GUI.skin.GetStyle("Selected Item"));
	
	GUI.EndScrollView ();
	
	gui_armorCon = itemsContent[in_toolArmors];
}

private function ShowAccess () : void {
	var in_items : int = 2;
	var itemsContent : GUIContent[] = new GUIContent[in_items];
	
	for(var i: int = 0; i<in_items;i++){
		if(i==0){
		itemsContent[i] = GUIContent(s_unequip, "");
		}else{
			if(hasHelm){
				itemsContent[i] = GUIContent(itemlistHelmName, a_accessories[0].icon);
			}else{
			itemsContent[i] = GUIContent("empty", "you have nothing");
			}
		}
	}
	scrollPosition3 = GUI.BeginScrollView (new Rect (257, 300, 320, 120), scrollPosition3, new Rect (0, 0, 280, 40*in_items));
	in_toolAccess = GUI.SelectionGrid (Rect (0, 0, 280, 40*in_items), in_toolAccess, itemsContent, 1, GUI.skin.GetStyle("Selected Item"));
	GUI.EndScrollView();
	
	gui_accessCon = itemsContent[in_toolAccess];
}

private function ShowSkill () : void{
	var in_items : int = a_skills.length + 1;
	var itemsContent : GUIContent[] = new GUIContent[in_items];
	
	for(var i : int = 0; i<in_items; i++) {
		if(i==0){
		itemsContent[i] = GUIContent(t_skillBox);
		}else{
		itemsContent[i] = GUIContent(a_skills[i-1]);
		}
	}
	scrollPosition3 = GUI.BeginScrollView (new Rect (253, 286, 330, 140), scrollPosition3, new Rect (0, 0, 600, 117));
	
	in_toolskill = GUI.SelectionGrid (Rect (0, 4, 600, 117), in_toolskill, itemsContent, in_items, GUI.skin.GetStyle("Selected Item"));
	
	GUI.EndScrollView ();
	if(in_toolskill !=0){
		gui_skillCon = itemsContent[in_toolskill];
	}else{
	gui_skillCon = GUIContent("");
	}
}

public function getA_equipBoolean(): boolean[]{ //setting this array to public broke your inventory
	return a_equipBoolean;
}


	