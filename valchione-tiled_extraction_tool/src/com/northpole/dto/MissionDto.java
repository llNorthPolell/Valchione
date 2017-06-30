package com.northpole.dto;


public class MissionDto implements Dto {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	
	private int height;
	private int width;
	
	private int numOfPlayers;
	private String missionObjectives;
	
	private String altitudes;
	private String tiles;
	
	private String structureLocations;
	private String structures;
	private String owners;
	
	private String gids;
	private String tileNames;

	
	public MissionDto() {
		super();
	}


	public int getHeight() {
		return height;
	}


	public void setHeight(int height) {
		this.height = height;
	}


	public int getWidth() {
		return width;
	}


	public void setWidth(int width) {
		this.width = width;
	}


	public String getMissionObjectives() {
		return missionObjectives;
	}


	public void setMissionObjectives(String missionObjectives) {
		this.missionObjectives = missionObjectives;
	}


	public String getAltitudes() {
		return altitudes;
	}


	public void setAltitudes(String altitudes) {
		this.altitudes = altitudes;
	}


	public String getTiles() {
		return tiles;
	}


	public void setTiles(String tiles) {
		this.tiles = tiles;
	}


	public String getStructureLocations() {
		return structureLocations;
	}


	public void setStructureLocations(String structureLocations) {
		this.structureLocations = structureLocations;
	}


	public String getStructures() {
		return structures;
	}


	public void setStructures(String structures) {
		this.structures = structures;
	}


	public String getOwners() {
		return owners;
	}


	public void setOwners(String owners) {
		this.owners = owners;
	}


	public String getGids() {
		return gids;
	}


	public void setGids(String gids) {
		this.gids = gids;
	}


	public String getTileNames() {
		return tileNames;
	}


	public void setTileNames(String tileNames) {
		this.tileNames = tileNames;
	}


	public int getNumOfPlayers() {
		return numOfPlayers;
	}


	public void setNumOfPlayers(int numOfPlayers) {
		this.numOfPlayers = numOfPlayers;
	}


	
	
}
