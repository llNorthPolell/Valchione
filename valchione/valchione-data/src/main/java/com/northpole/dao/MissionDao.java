package com.northpole.dao;

import java.util.List;

public interface MissionDao {
	public String getById(Long id);	
	public int getMaxStoryProgress();
	public List<String>getAllStoryQuestNames(int chapter);
}
