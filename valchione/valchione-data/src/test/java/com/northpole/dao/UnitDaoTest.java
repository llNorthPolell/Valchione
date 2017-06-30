package com.northpole.dao;

import static org.junit.Assert.*;

import java.util.List;

import org.junit.BeforeClass;
import org.junit.Test;

import com.northpole.dao.impl.UnitDaoImpl;
import com.northpole.entity.Unit;

public class UnitDaoTest {
	private static UnitDao unitDao;
	
	@BeforeClass
	public static void init(){
		unitDao = new UnitDaoImpl();
	}
	
	@Test
	public void bGetByIdTest() {
		Unit resultUnit = unitDao.getById(1L);
		
		System.out.println(resultUnit);
		assertNotNull(resultUnit);
	}
	
	@Test
	public void getAllUnitsTest(){
		List<Unit> unitList = unitDao.getAllUnits();
		
		System.out.println(unitList);
	}

}
