package com.northpole.dto;

public class MissionDto implements Dto {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private String missionJson;

	public MissionDto(String missionJson) {
		super();
		this.missionJson = missionJson;
	}

	public String getMissionJson() {
		return missionJson;
	}

	public void setMissionJson(String missionJson) {
		this.missionJson = missionJson;
	}
	
	
}
