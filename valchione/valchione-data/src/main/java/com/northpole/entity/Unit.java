package com.northpole.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;


@Entity
@Table(name = "VAL_UNIT")
@NamedQueries({
	@NamedQuery(name = "unit.getAll", query="SELECT un FROM Unit un")
})
public class Unit implements IStorable {
	@Id
	@Column(name="unit_id")
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "unit_id_seq")
	@SequenceGenerator(name="unit_id_seq", sequenceName="VAL_UNIT_ID_SEQ")
	private long unitId;
	
	@Column(name="unit_name")
	private String unitName;
	
	@Column(name="unit_type_code")
	private String unitType;
	
	@Column(name="unit_hp")
	private int hp;
	
	@Column(name="unit_str")
	private int str;
	
	@Column(name="unit_spr")
	private int spr;
	
	@Column(name="unit_agi")
	private int agi;
	
	@Column(name="unit_spd")
	private int spd;
	
	public Unit() {
		super();
	}

	

	public Unit(String unitName, String unitType, int hp, int str, int spr, int agi, int spd) {
		super();
		this.unitName = unitName;
		this.unitType = unitType;
		this.hp = hp;
		this.str = str;
		this.spr = spr;
		this.agi = agi;
		this.spd = spd;
	}



	public String getUnitType() {
		return unitType;
	}



	public void setUnitType(String unitType) {
		this.unitType = unitType;
	}



	public long getUnitId() {
		return unitId;
	}

	public void setUnitId(long unitId) {
		this.unitId = unitId;
	}

	public String getUnitName() {
		return unitName;
	}

	public void setUnitName(String unitName) {
		this.unitName = unitName;
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



	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + (int) (unitId ^ (unitId >>> 32));
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Unit other = (Unit) obj;
		if (unitId != other.unitId)
			return false;
		return true;
	}

	@Override
	public String toString() {
		return "Unit [unitId=" + unitId + ", unitName=" + unitName + ", unitType=" + unitType + ", hp=" + hp + ", str="
				+ str + ", spr=" + spr + ", agi=" + agi + ", spd=" + spd + "]";
	}
}
