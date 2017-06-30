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
@Table(name = "VAL_TERRAIN")
@NamedQueries({
	@NamedQuery(name = "terrain.getAll", query = "SELECT t FROM Terrain t"),		
	@NamedQuery(name = "terrain.getByTerrainName", query = "SELECT t FROM Terrain t WHERE t.terrainName = :tname")	
})
public class Terrain implements IStorable{
	@Id
	@Column(name="terrain_id")
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "terrain_id_seq")
	@SequenceGenerator(name="terrain_id_seq", sequenceName="VAL_TERRAIN_ID_SEQ")
	private long terrainId;
	
	@Column (name = "terrain_name")
	private String terrainName;
	
	@Column (name = "is_walkable")
	private char walkable;
	
	
	public Terrain() {
		super();
	}
	
	
	public Terrain(String terrainName, char walkable) {
		this();
		this.terrainName = terrainName;
		this.walkable = walkable;
	}


	public Terrain(long terrainId, String terrainName, char walkable) {
		this(terrainName,walkable);
		this.terrainId = terrainId;
	}


	public long getTerrainId() {
		return terrainId;
	}
	public void setTerrainId(long terrainId) {
		this.terrainId = terrainId;
	}
	public String getTerrainName() {
		return terrainName;
	}
	public void setTerrainName(String terrainName) {
		this.terrainName = terrainName;
	}
	public char getWalkable() {
		return walkable;
	}
	public void setWalkable(char walkable) {
		this.walkable = walkable;
	}


	@Override
	public String toString() {
		return "Terrain [terrainId=" + terrainId + ", terrainName=" + terrainName + ", walkable=" + walkable + "]";
	}


	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + (int) (terrainId ^ (terrainId >>> 32));
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
		Terrain other = (Terrain) obj;
		if (terrainId != other.terrainId)
			return false;
		return true;
	}
	
	
	
}
