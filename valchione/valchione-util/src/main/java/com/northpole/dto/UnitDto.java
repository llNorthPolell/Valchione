package com.northpole.dto;

import com.northpole.entity.Unit;

/**
 * @author NorthPole
 * Stores data about individual game units.
 */
public class UnitDto implements Dto {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private long unitId;
	private String unitName;
	private String unitType;
	private int hp;
	private int str;
	private int spr;
	private int agi;
	private int spd;
	
	
	public UnitDto() {	
		super();
	}
	
	public UnitDto(Unit unit){
		unitId = unit.getUnitId();
		unitName = unit.getUnitName();
		unitType = unit.getUnitType();
		hp = unit.getHp();
		str = unit.getStr();
		spr = unit.getSpr();
		agi = unit.getAgi();
		spd = unit.getSpd();
	}

	

	public String getUnitName() {
		return unitName;
	}

	public void setUnitName(String unitName) {
		this.unitName = unitName;
	}

	public String getUnitType() {
		return unitType;
	}

	public void setUnitType(String unitType) {
		this.unitType = unitType;
	}

	public int getHp() {
		return hp;
	}

	public void setHp(int hp) {
		this.hp = hp;
	}

	public int getStr() {
		return str;
	}

	public void setStr(int str) {
		this.str = str;
	}

	public int getSpr() {
		return spr;
	}

	public void setSpr(int spr) {
		this.spr = spr;
	}

	public int getAgi() {
		return agi;
	}

	public void setAgi(int agi) {
		this.agi = agi;
	}

	public int getSpd() {
		return spd;
	}

	public void setSpd(int spd) {
		this.spd = spd;
	}

	public long getUnitId() {
		return unitId;
	}

	public void setUnitId(long unitId) {
		this.unitId = unitId;
	}

	@Override
	public String toString() {
		return "UnitDto [unitId=" + unitId + ", unitName=" + unitName + ", unitType=" + unitType + ", hp=" + hp
				+ ", str=" + str + ", spr=" + spr + ", agi=" + agi + ", spd=" + spd + "]";
	}
}
