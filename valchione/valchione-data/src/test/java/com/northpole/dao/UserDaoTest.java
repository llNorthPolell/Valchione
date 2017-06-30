package com.northpole.dao;

import static org.junit.Assert.*;

import org.junit.BeforeClass;
import org.junit.Test;

import com.northpole.dao.impl.UserDaoImpl;
import com.northpole.entity.User;

public class UserDaoTest {
	private static UserDao userDao;
	
	private static User user;
	
	@BeforeClass
	public static void init(){
		userDao = new UserDaoImpl();
		user = new User(881, "testUser", "qwerty",null);
	}
	
	/*@Test
	public void aCreateTest() {
		User expected = new User("testUser2", "asdfdfdf");
		User result = userDao.create(expected);
		
		assertEquals(expected, result);
		System.out.println(expected+":"+ result);
	}*/
	
	@Test
	public void bGetByIdTest() {
		User expected =  user;
		User result = userDao.getById(881L);
		
		assertEquals(expected, result);
		System.out.println(expected+":"+ result);
	}
	
	@Test 
	public void cGetByUsernameTest(){
		User expected = user;
		User result = userDao.getByUsername("testUser");
		System.out.println(expected+":"+ result);
		assertEquals(expected, result);	
	}

	@Test
	public void dCheckDecksTest(){
		User user = userDao.getByUsername("testUser");
		
		System.out.println(user.getProfile().getDecks());
	}
}
