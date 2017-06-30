package com.northpole;

import java.util.List;

import com.northpole.dto.*;

public class CoreControllerImpl extends BaseController implements CoreController{
	private UserController userController = new UserControllerImpl();
	private UnitController unitController = new UnitControllerImpl();
	private MissionController missionController = new MissionControllerImpl();
	private ProfileController profileController = new ProfileControllerImpl();
	
	public PlayerDto login(String username, String password){
		return userController.login(username, password);
	}
	
	public PlayerDto register(String username, String password){
		return userController.register(username, password);
	}
	
	public UnitDto getUnitInfo(Long id){
		return unitController.getUnitInfo(id);
	}
	
	public MissionDto getMission(Long id){
		return missionController.getById(id);
	}
	
	public int getMaxStoryProgress(){
		return missionController.getMaxStoryProgress();
	}
	
	public List<String> getAllStoryQuestNames(int chapter){
		return missionController.getAllStoryQuestNames(chapter);
	}
	
	public PlayerCardDtoList getPlayerCards(String username){
		return profileController.getPlayerCards(username);
	}

	public UnitDtoList loadUnitInfo(){
		return unitController.getAllUnitInfo();
	}

	public DeckDtoList getDecks(String username) {
		return profileController.getDecks(username);
	}
}
