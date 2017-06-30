package com.northpole.dao;

import static org.junit.Assert.*;

import java.util.List;

import org.junit.BeforeClass;
import org.junit.Test;

import com.northpole.dao.enums.queries.ProfileCardQueries;
import com.northpole.dao.impl.ProfileCardDaoImpl;
import com.northpole.entity.ProfileCard;

public class ProfileCardTest {
	private static ProfileCardDao profileCardDao;
	
	
	@BeforeClass
	public static void init(){
		profileCardDao = new ProfileCardDaoImpl();
	}
	
	@Test
	public void getAllByProfileIdTest(){
		List<ProfileCard> resultProfileCardList = profileCardDao.read(ProfileCardQueries.BYPROFILEID,881L);
		System.out.println(resultProfileCardList);
		assertNotNull(resultProfileCardList);
	}

}
