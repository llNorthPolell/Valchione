package com.northpole.dao;

import static org.junit.Assert.*;

import org.junit.BeforeClass;
import org.junit.Test;

import com.northpole.dao.impl.CardDaoImpl;
import com.northpole.entity.Card;

public class CardDaoTest {

	private static CardDao cardDao;
	
	
	@BeforeClass
	public static void init(){
		cardDao = new CardDaoImpl();
	}
	
	@Test
	public void getByIdTest(){
		Card resultCard = cardDao.getById(2L);
		
		System.out.println(resultCard);
		assertNotNull(resultCard);
	}
}
