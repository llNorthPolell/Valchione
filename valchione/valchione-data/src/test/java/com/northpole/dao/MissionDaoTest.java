package com.northpole.dao;

import static org.junit.Assert.*;

import java.util.List;

import org.junit.BeforeClass;
import org.junit.Test;

import com.northpole.dao.impl.MissionDaoImpl;

public class MissionDaoTest {
	private static MissionDao missionDao;
	
	private static String mission;
	
	@BeforeClass
	public static void init(){
		missionDao = new MissionDaoImpl();
	}
	
	@Test
	public void getByIdTest() {
		mission = missionDao.getById(1L);
		
		System.out.println(mission);
		
		assertNotNull(mission);
	}
	
	@Test
	public void getMaxStoryProgressTest(){
		int resultMaxStory = missionDao.getMaxStoryProgress();
		int expectedMaxStory = 2;
		assertEquals(expectedMaxStory, resultMaxStory);
	}

	@Test
	public void getAllStoryQuestNamesTest(){
		List<String> storyNames = missionDao.getAllStoryQuestNames(0);
		System.out.println(storyNames);
	}
}
