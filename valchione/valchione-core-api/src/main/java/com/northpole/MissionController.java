package com.northpole;

import java.util.List;

import com.northpole.dto.MissionDto;

public interface MissionController extends Controller {
	public MissionDto getById(Long id);
	public int getMaxStoryProgress();
	public List<String> getAllStoryQuestNames(int chapter);
}
