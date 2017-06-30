package com.northpole;

import static org.junit.Assert.*;

import org.junit.BeforeClass;
import org.junit.Test;

//import com.northpole.controllers.JsonController;
import com.northpole.dto.PlayerCardDtoList;
import com.northpole.dto.PlayerDto;
import com.northpole.dto.UnitDtoList;

public class CoreControllerTest {
	private static CoreControllerImpl coreController;
	
	@BeforeClass
	public static void init(){
		coreController = new CoreControllerImpl();
	}
	
	@Test
	public void loginTest(){
		PlayerDto playerDto = coreController.login("testUser", "1234");
		
		assertNotNull(playerDto);
	}
	
	@Test
	public void getPlayerCardsTest() {
		PlayerCardDtoList playerCards = coreController.getPlayerCards("testUser");
		
		assertNotNull(playerCards);
		
		System.out.println(playerCards.getItems());
		
	}
	
	@Test
	public void loadUnitInfoTest(){
		UnitDtoList unitDtoList = coreController.loadUnitInfo();
		
		System.out.println(unitDtoList);
		//System.out.println(JsonController.toJsonString(unitDtoList));
	}
}
