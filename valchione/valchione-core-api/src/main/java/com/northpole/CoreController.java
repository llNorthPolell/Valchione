package com.northpole;

import java.util.List;

import com.northpole.dto.*;

public interface CoreController extends Controller{
	public PlayerDto login(String username, String password);
	
	public PlayerDto register(String username, String password);
	
	public UnitDto getUnitInfo(Long id);
	
	public MissionDto getMission(Long id);
	
	public int getMaxStoryProgress();
	
	public List<String> getAllStoryQuestNames(int chapter);
	
	public PlayerCardDtoList getPlayerCards(String username);
	
	public UnitDtoList loadUnitInfo();

	public DeckDtoList getDecks(String username);
	
}
