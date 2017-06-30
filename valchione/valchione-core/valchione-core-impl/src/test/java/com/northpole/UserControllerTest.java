package com.northpole;

import static org.junit.Assert.*;

import org.junit.BeforeClass;
import org.junit.Test;

import com.northpole.dto.PlayerDto;

public class UserControllerTest {
	private static String username;
	private static String password;
	private static UserController userController;
	@BeforeClass
	public static void init(){
		userController = (UserController) new UserControllerImpl();
		username = "testUser";
		password = "qwerty";
	}
	
	@Test
	public void bLoginTest() {
		
		PlayerDto result = userController.login(username, password);
		
		
		System.out.println("Player: " +result);
		assertNotNull(result);
		
	}

}
